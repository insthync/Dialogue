using System.Collections.Generic;
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
        [TextArea] public string text;
        [Output(dynamicPortList = true)] public List<Answer> answers = new List<Answer>();

        [System.Serializable]
        public partial class Answer
        {
            public string text;
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
