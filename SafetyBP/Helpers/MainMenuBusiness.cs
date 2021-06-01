using SafetyBP.Data;
using SafetyBP.Domain.Entities;
using SafetyBP.Domain.Enums;
using SafetyBP.Interfaces;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SafetyBP.Helpers
{
    public class MainMenuBusiness : IMainMenuBusiness
    {
        private readonly ITranslateBusiness _translateBusiness;
        public MainMenuBusiness()
        {
            _translateBusiness = DependencyService.Get<ITranslateBusiness>();
        }

        public List<HomeMenuItem> GetMenu()
        {
            return new List<HomeMenuItem>
            {
                new HomeMenuItem { Id = HomeMenu.CheckList,
                                    Text = _translateBusiness.GetText(ApplicationWordsEnum.MainMenuCheckList),
                                    BackgroundColor = Application.Current.Resources["Amarillo"],
                                    TextColor = Application.Current.Resources["Blanco"],
                                    Imagen = Application.Current.Resources["CHECKLISTICON"],
                Enabled = true},

                new HomeMenuItem { Id = HomeMenu.ControlObjetos,
                                    Text = _translateBusiness.GetText(ApplicationWordsEnum.MainMenuControlObjects),
                                    BackgroundColor = Application.Current.Resources["Azul"],
                                    TextColor = Application.Current.Resources["Blanco"],
                                    Imagen = Application.Current.Resources["BALLOT"],
                Enabled = true},


                new HomeMenuItem { Id = HomeMenu.TaskBoard,
                                    Text = _translateBusiness.GetText(ApplicationWordsEnum.MainMenuBoardTasks),
                                    BackgroundColor = Application.Current.Resources["AzulFrancia"],
                                    TextColor = Application.Current.Resources["Blanco"],
                                    Imagen = Application.Current.Resources["TASK"],
                Enabled = true},

                new HomeMenuItem { Id = HomeMenu.AccionesCorrectivas,
                                    Text = _translateBusiness.GetText(ApplicationWordsEnum.MainMenuCorrectiveActions),
                                    BackgroundColor = Application.Current.Resources["Naranja"],
                                    TextColor = Application.Current.Resources["Blanco"],
                                    Imagen = Application.Current.Resources["INPUT"],
                Enabled = true},

                new HomeMenuItem { Id = HomeMenu.SpontaneousDeflection,
                                    Text = _translateBusiness.GetText(ApplicationWordsEnum.MainMenuSpontaneousDiversions),
                                    BackgroundColor = Application.Current.Resources["Rojo"],
                                    TextColor = Application.Current.Resources["Blanco"],
                                    Imagen = Application.Current.Resources["DEICON"],
                Enabled = true},

                new HomeMenuItem { Id = HomeMenu.AddObjects,
                                    Text = _translateBusiness.GetText(ApplicationWordsEnum.MainMenuAddObjects),
                                    BackgroundColor = Application.Current.Resources["Negro"],
                                    TextColor = Application.Current.Resources["Blanco"],
                                    Imagen = Application.Current.Resources["INPUT"]}
            };
        }
    }
}
