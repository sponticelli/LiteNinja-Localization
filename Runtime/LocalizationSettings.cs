using System.Linq;
using UnityEngine;

namespace LiteNinja.Localization
{
    [CreateAssetMenu(menuName = "LiteNinja/Localization/Settings", fileName = "LocalizationSettings", order = 0)]
    /// <summary>
    /// A scriptable object that contains the localization settings for the application.
    /// It contains the default language and the dictionaries for each language.
    /// </summary>
    public class LocalizationSettings : ScriptableObject
    {
        public SystemLanguage DefaultLanguage;
        public LocalizationDictionary[] Dictionaries;

        public LocalizationDictionary GetDictionary(SystemLanguage language)
        {
            return Dictionaries.FirstOrDefault(dictionary => dictionary.Language == language);
        }

        public LocalizationDictionary GetDefaultDictionary()
        {
            return GetDictionary(DefaultLanguage);
        }

        public SystemLanguage[] AvailableLanguages => Dictionaries.Select(dictionary => dictionary.Language).ToArray();


        #region Validation

        private void OnValidate()
        {
            if (Dictionaries == null || Dictionaries.Length == 0)
            {
                return;
            }

            CheckDefaultDictionary();
            CheckTerms();
        }

        private void CheckTerms()
        {
            // Check for that all dictionaries have the same Terms of the DefaultLanguage
            var defaultDictionary = GetDictionary(DefaultLanguage);
            foreach (var dictionary in Dictionaries)
            {
                if (dictionary.Language == DefaultLanguage)
                {
                    continue;
                }

                foreach (var term in defaultDictionary.Terms)
                {
                    if (dictionary.Terms.All(t => t.Key != term.Key))
                    {
                        Debug.LogError($"Term {term.Key} not found in dictionary {dictionary.Language}");
                    }
                }
            }
        }

        private void CheckDefaultDictionary()
        {
            var defaultLanguageFound = Dictionaries.Any(dictionary => dictionary.Language == DefaultLanguage);

            if (!defaultLanguageFound)
            {
                Debug.LogError($"Default language {DefaultLanguage} not found in dictionaries");
            }
        }

        #endregion
    }
}