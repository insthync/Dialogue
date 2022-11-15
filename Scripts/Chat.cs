using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using XNode;

namespace Dialogue
{
    [NodeTint("#CCFFCC")]
    public partial class Chat : DialogueBaseNode
    {
        public CharacterInfo character;
        public AudioClip voiceClip;
        public string title;
        public LanguageData[] titleByLanguageKeys = new LanguageData[0];

        [TextArea] public string text;
        public LanguageData[] textByLanguageKeys = new LanguageData[0];

        [Output(dynamicPortList = true)] public List<Answer> answers = new List<Answer>();

        [System.Serializable]
        public partial class Answer
        {
            public string text;
            public LanguageData[] textByLanguageKeys = new LanguageData[0];
            public BaseAnswerCondition[] showAnswerConditions = new BaseAnswerCondition[0];
            public string GetText(string languageKey)
            {
                return textByLanguageKeys.GetTextByLanguageKey(languageKey, text);
            }

            public async Task<bool> IsPassAllShowConditions()
            {
                for (int i = 0; i < showAnswerConditions.Length; ++i)
                {
                    if (!await showAnswerConditions[i].IsPass())
                        return false;
                }
                return true;
            }
        }

        public string GetTitle(string languageKey)
        {
            return titleByLanguageKeys.GetTextByLanguageKey(languageKey, title);
        }

        public string GetText(string languageKey)
        {
            return textByLanguageKeys.GetTextByLanguageKey(languageKey, text);
        }

        public void AnswerQuestion(int index)
        {
            NodePort port;
            if (answers.Count == 0)
            {
                port = GetOutputPort("output");
            }
            else
            {
                if (answers.Count <= index) return;
                port = GetOutputPort("answers " + index);
            }

            if (port == null || !port.IsConnected)
            {
                (graph as DialogueGraph).current = null;
                return;
            }
            for (int i = 0; i < port.ConnectionCount; i++)
            {
                NodePort connection = port.GetConnection(i);
                (connection.node as DialogueBaseNode).Trigger();
            }
        }

        public override void Trigger()
        {
            (graph as DialogueGraph).current = this;
        }
    }
}
