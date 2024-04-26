using System;
using UnityEngine;

namespace LiteNinja.Localization
{
    [Serializable]
    /// <summary>
    /// A term represents a key-value pair for a localized text.
    /// </summary>
    public class Term
    {
        [SerializeField] private string _key;
        [SerializeField] public string _value;

        public string Key => _key;
        public string Value => _value;
    }
}