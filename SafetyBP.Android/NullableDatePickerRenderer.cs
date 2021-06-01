using Android.App;
using Android.Content;
using Android.Widget;
using NullableDatePicker.Droid;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SafetyBP.Controls.NullableDatePicker), typeof(NullableDatePickerRenderer))]
namespace NullableDatePicker.Droid
{
    public class NullableDatePickerRenderer : ViewRenderer<SafetyBP.Controls.NullableDatePicker, EditText>
    {
        DatePickerDialog _dialog;
        private bool _dialogClose;
        public NullableDatePickerRenderer(Context context) : base(context)
        {
            _dialogClose = false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SafetyBP.Controls.NullableDatePicker> e)
        {
            base.OnElementChanged(e);

            this.SetNativeControl(new Android.Widget.EditText(Context));
            if (Control == null || e.NewElement == null)
                return;

            var entry = (SafetyBP.Controls.NullableDatePicker)this.Element;

            this.Control.Click += OnPickerClick;
            this.Control.Text = !entry.NullableDate.HasValue ? entry.PlaceHolder : Element.Date.ToString(Element.Format);
            this.Control.KeyListener = null;
            this.Control.FocusChange += OnPickerFocusChange;
            this.Control.Enabled = Element.IsEnabled;

        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Xamarin.Forms.DatePicker.DateProperty.PropertyName || e.PropertyName == Xamarin.Forms.DatePicker.FormatProperty.PropertyName)
            {
                SetDate(Element.Date);
            }
        }

        void OnPickerFocusChange(object sender, Android.Views.View.FocusChangeEventArgs e)
        {
            if (e.HasFocus) {
                ShowDatePicker();
            }
        }



        protected override void Dispose(bool disposing)
        {
            if (Control != null)
            {
                this.Control.Click -= OnPickerClick;
                this.Control.FocusChange -= OnPickerFocusChange;

                if (_dialog != null)
                {
                    _dialog.Hide();
                    _dialog.Dispose();
                    _dialog = null;
                }
            }

            base.Dispose(disposing);
        }

        void OnPickerClick(object sender, EventArgs e)
        {
            _dialogClose = false;
            ShowDatePicker();
        }

        void SetDate(DateTime date)
        {
            this.Control.Text = date.ToString(Element.Format);
            Element.Date = date;
        }

        private void ShowDatePicker()
        {
            if (!_dialogClose)
            {
                CreateDatePickerDialog(this.Element.Date.Year, this.Element.Date.Month - 1, this.Element.Date.Day);
                _dialog.Show();
            }
        }

        void CreateDatePickerDialog(int year, int month, int day)
        {
            SafetyBP.Controls.NullableDatePicker view = Element;
            _dialog = new DatePickerDialog(Context, (o, e) =>
            {
                view.Date = e.Date;
                ((IElementController)view).SetValueFromRenderer(VisualElement.IsFocusedProperty, false);
                Control.ClearFocus();

                _dialog = null;
            }, year, month, day);

            _dialog.SetButton("Aceptar", (sender, e) =>
            {
                SetDate(_dialog.DatePicker.DateTime);
                this.Element.Format = this.Element._originalFormat;
                this.Element.AssignValue();
                _dialogClose = true;
            });

            _dialog.SetButton2("Cerrar", (sender, e) =>
            {
                _dialogClose = true;
                this.Element.CleanDate();
                Control.Text = this.Element.Format;
            });
        }
    }
}