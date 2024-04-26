using System;
using UnityEngine;

namespace LiteNinja.Localization
{
    /// <summary>
    /// This class provides localization services for the application.
    /// It implements the ILocalizationService interface.
    /// </summary>
    public class LocalizationService : ILocalizationService
    {
        private readonly LocalizationSettings _settings;
        private SystemLanguage _currentLanguage;
        private LocalizationDictionary _currentDictionary;

        public LocalizationService(LocalizationSettings settings)
        {
            _settings = settings;
            CurrentLanguage = _settings.DefaultLanguage;
            _currentDictionary = _settings.GetDictionary(CurrentLanguage);
        }


        public string GetText(string key, params object[] args)
        {
            var text = _currentDictionary?.GetText(key);
            return string.Format(text, args);
        }

        public SystemLanguage CurrentLanguage
        {
            get => _currentLanguage;
            set
            {
                if (_currentLanguage == value)
                {
                    return;
                }

                _currentLanguage = value;
                _currentDictionary = _settings.GetDictionary(value);
                _currentDictionary?.Initialize();
                LanguageChanged?.Invoke();
            }
        }

        public SystemLanguage DefaultLanguage => _settings.DefaultLanguage;

        public SystemLanguage[] AvailableLanguages => _settings.AvailableLanguages;
        public event Action LanguageChanged;
    }
}