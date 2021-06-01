using SafetyBP.Domain.Entities;
using System.Collections.Generic;

namespace SafetyBP.Helpers
{
    public interface IMainMenuBusiness
    {
        List<HomeMenuItem> GetMenu();
    }
}