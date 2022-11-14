using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(menuName = "Dialogue/CharacterInfo")]
    public partial class CharacterInfo : ScriptableObject
    {
        public Sprite icon;
        public string title;
        public LanguageData[] titleByLanguageKeys = new LanguageData[0];
        public string GetTitle(string languageKey)
        {
            return titleByLanguageKeys.GetTextByLanguageKey(languageKey, title);
        }
    }
}
