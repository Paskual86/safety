using SafetyBP.Data;
using SafetyBP.Views;
using System.Threading.Tasks;

namespace SafetyBP.ViewModels.ControlObjects
{
    public class ControlObjectBaseViewModel : BaseViewModel
    {
        public ControlObjectBaseViewModel():base()
        {

        }

        public ControlObjectBaseViewModel(ApplicationWordsEnum appType):base(appType)
        { 
        
        }

        public override async Task ProcessQR(string qrValue)
        {
            if (qrValue.Trim().Length > 0)
            {
                if (qrValue.Contains("oid"))
                {
                    var startPosition = qrValue.IndexOf("oid");

                    var objectId = qrValue.Substring(startPosition + 4, qrValue.Length - (startPosition + 4));

                    int.TryParse(objectId, out int objId);

                    var result = await HardwareBusiness.GetSurveyByObjectIdAsync(objId);

                    if (result!=null)
                    {
                        var viewModel = new ControlObjetosPreguntasViewModel(result);
                        
                        await Navigation.PushAsync(new ControlObjetosPreguntasPage(viewModel));
                    }
                    else
                    {
                        await base.ProcessQR($"El id {objectId} no fue encontrado en los objetos asignados.");
                    }

                }
                else
                {
                    await base.ProcessQR("No se encontro el id del Objeto en el QR");
                }
            }
            else
            {
                await base.ProcessQR("No se encontro el id del Objeto en el QR");
            }
        }
    }
}
