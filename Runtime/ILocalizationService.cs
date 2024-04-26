using System;
using UnityEngine;

namespace LiteNinja.Localization
{
    /// <summary>
    /// Interface for localization services.
    /// </summary>
    public interface ILocalizationService
    {
        /// <summary>
        /// Retrieves the localized text for the given key.
        /// </summary>
        /// <param name="key">The key for the localized text.</param>
        /// <param name="args">Optional arguments for formatting the localized text.</param>
        /// <returns>The localized text.</returns>
        string GetText(string key, params object[] args);

        /// <summary>
        /// Gets or sets the current language for the localization service.
        /// </summary>
        SystemLanguage CurrentLanguage { get; set; }

        /// <summary>
        /// Gets the default language for the localization service.
        /// </summary>
        SystemLanguage DefaultLanguage { get; }

        /// <summary>
        /// Get the available languages for the localization service.
        /// </summary>
        SystemLanguage[] AvailableLanguages { get; }

        /// <summary>
        /// Event triggered when the current language is changed.
        /// </summary>
        event Action LanguageChanged;
    }
}