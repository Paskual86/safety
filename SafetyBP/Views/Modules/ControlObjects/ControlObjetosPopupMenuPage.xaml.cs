using SafetyBP.Domain.Models.Modules.ControlObjects;
using SafetyBP.Domain.Models.Modules.CorrectiveAction;
using SafetyBP.ViewModels.ControlObjects;
using SafetyBP.ViewModels.CorrectiveActions;
using SafetyBP.Views.Common;
using System.Windows.Input;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views.Modules.ControlObjects
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlObjetosPopupMenuPage : PopupMenuPage
    {
        public ControlObjetosPopupMenuPage(ControlObjectsCheckList checklists, ICommand callbackNAEvent) : base(new ControlObjectPopupMenuViewModel(checklists, callbackNAEvent))
        {
            InitializeComponent();
        }

        public ControlObjetosPopupMenuPage(ControlObjectsQuestion question) : base(new ControlObjetosPreguntasPopupViewModel(question))
        {
            InitializeComponent();
        }

        /// <summary>
        /// TODO :: ESTO LO DEBO MOVER A UNA CLASE COMMUN PERO NO HAY TIEMPO
        /// </summary>
        /// <param name="question"></param>
        public ControlObjetosPopupMenuPage(CorrectiveActionTask task) : base(new AccionesCorrectivasTareasPopupViewModel(task))
        {
            InitializeComponent();
        }
    }
}