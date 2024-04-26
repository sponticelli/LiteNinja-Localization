using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LiteNinja.Localization
{
    /// <summary>
    /// This class represents a localization dictionary for a specific language.
    /// </summary>
    [CreateAssetMenu(menuName = "LiteNinja/Localization/Dictionary", fileName = "LocalizationDictionary")]
    public class LocalizationDictionary : ScriptableObject
    {
        [SerializeField] private SystemLanguage _language;

        [SerializeField] private Term[] _terms;

        public SystemLanguage Language => _language;

        public Term[] Terms => _terms;

        private Dictionary<string, string> _termsDictionary;
        private bool _initialized;

        public void Initialize()
        {
            _termsDictionary = new Dictionary<string, string>();
            foreach (var term in _terms)
            {
                _termsDictionary[term.Key] = term.Value;
            }

            _initialized = true;
        }

        public string GetText(string key)
        {
            if (_termsDictionary == null || !_initialized)
            {
                Initialize();
            }

            return _termsDictionary.GetValueOrDefault(key, key);
        }

        private void OnValidate()
        {
            if (_terms == null || _terms.Length == 0)
            {
                return;
            }

            var keys = _terms.Select(term => term.Key).ToArray();
            var distinctKeys = keys.Distinct().ToArray();

            if (keys.Length != distinctKeys.Length)
            {
                Debug.LogError($"Duplicate keys found in dictionary {Language}");
            }

            Initialize();
        }
    }
}