using LiteNinja.Injection;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace LiteNinja.Localization
{
    /// <summary>
    /// This class is responsible for localizing TextMeshProUGUI components.
    /// It listens to language change events from the localization service and updates the text accordingly.
    /// </summary>
    public class LocalizeTextMeshProUGUI : MonoBehaviour
    {
        [SerializeField] private string _key;
        [SerializeField] private TextMeshProUGUI _textField;
        
        [Inject] private ILocalizationService _localizationService;
        
        private void Start()
        {
            _localizationService.LanguageChanged += OnLanguageChanged;
            UpdateText();
        }
        
        private void OnDestroy()
        {
            if (_localizationService != null)
            {
                _localizationService.LanguageChanged -= OnLanguageChanged;
            }
        }
        
        private void OnLanguageChanged()
        {
            UpdateText();
        }
        
        private void UpdateText()
        {
            _textField.text = _localizationService.GetText(_key);
        }
    }
}