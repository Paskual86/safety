using SafetyBP.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafetyBP.Interfaces
{
    public interface ITranslateBusiness
    {
        LanguagesEnum Language { get; set ; }
        string GetText(ApplicationWordsEnum textId);
        void SetLanguage(LanguagesEnum language);
        Task<LanguagesEnum> GetLanguage();
        Task<IDictionary<LanguagesEnum, string>> GetLanguageList();
    }
}
