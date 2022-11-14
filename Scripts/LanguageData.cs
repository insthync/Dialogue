using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{

    [System.Serializable]
    public struct LanguageData
    {
        public string key;
        [TextArea]
        public string value;
    }

    public static class LanguageDataExtensions
    {
        public static string GetTextByLanguageKey(this IEnumerable<LanguageData> langs, string languageKey, string defaultValue = "")
        {
            if (langs != null)
            {
                foreach (LanguageData entry in langs)
                {
                    if (string.IsNullOrEmpty(entry.key))
                        continue;
                    if (entry.key.Equals(languageKey))
                        return entry.value;
                }
            }
            return defaultValue;
        }
    }
}
