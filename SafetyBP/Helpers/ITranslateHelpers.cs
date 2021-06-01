using SafetyBP.Data;
using System.Collections.Generic;

namespace SafetyBP.Helpers
{
    public interface ITranslateHelpers
    {
        IDictionary<ApplicationWordsEnum, string> GetEnglishWords();
        IDictionary<ApplicationWordsEnum, string> GetSpanishWords();
        IDictionary<ApplicationWordsEnum, string> GetPortuguesWords();

        IDictionary<LanguagesEnum, string> GetLanguages(LanguagesEnum language);
    }
}
