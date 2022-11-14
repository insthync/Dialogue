using System;
using XNode;

namespace Dialogue
{
    [NodeTint("#CCCCFF")]
    public class Branch : DialogueBaseNode
    {
        public Condition[] conditions;
        [Output] public DialogueBaseNode pass;
        [Output] public DialogueBaseNode fail;

        public override void Trigger()
        {
            // Perform condition
            bool success = true;
            for (int i = 0; i < conditions.Length; i++)
            {
                if (!conditions[i].Invoke())
                {
                    success = false;
                    break;
                }
            }

            // Trigger next nodes
            NodePort port;
            if (success) port = GetOutputPort("pass");
            else port = GetOutputPort("fail");

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
    }

    [Serializable]
    public class Condition : SerializableCallback<bool> { }
}
