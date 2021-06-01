using SafetyBP.Data;
using SafetyBP.Helpers;
using SafetyBP.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SafetyBP.Core
{
    public class TranslateBusiness : ITranslateBusiness
    {
        private readonly ITranslateHelpers translateHelpers;
        public LanguagesEnum Language { get; set; }

        private Dictionary<ApplicationWordsEnum, string> _words;

        public TranslateBusiness()
        {
            translateHelpers = DependencyService.Get<ITranslateHelpers>();
            GetLanguage().Wait();
            SetWords();
        }

        private void SetWords() 
        {
            switch (Language)
            {
                case LanguagesEnum.Spanish:
                    _words = new Dictionary<ApplicationWordsEnum, string>(translateHelpers.GetSpanishWords());
                    break;
                case LanguagesEnum.English:
                    _words = new Dictionary<ApplicationWordsEnum, string>(translateHelpers.GetEnglishWords());
                    break;
                case LanguagesEnum.Portugues:
                    _words = new Dictionary<ApplicationWordsEnum, string>(translateHelpers.GetPortuguesWords());
                    break;
            }
        }
        public string GetText(ApplicationWordsEnum textId)
        {
            return _words[textId];
        }

        public async void SetLanguage(LanguagesEnum language)
        {
            Language = language;
            await SecureStorage.SetAsync("Language", ((byte)Language).ToString());
            SetWords();
        }

        public async Task<LanguagesEnum> GetLanguage()
        {
            var language = await SecureStorage.GetAsync("Language");

            if (language == null || (language.Trim().Length == 0)) {
                Language = LanguagesEnum.Spanish;
            }
            else {
                if (!byte.TryParse(language, out byte result)) {
                    Language = LanguagesEnum.Spanish;
                }
                else {
                    Language = (LanguagesEnum)result;
                }
            }
            return Language;
        }

        public async Task<IDictionary<LanguagesEnum, string>> GetLanguageList() 
        {
            return translateHelpers.GetLanguages(await GetLanguage());
        }
    }
}
