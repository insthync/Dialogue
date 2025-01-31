using XNode;

namespace Dialogue
{
    [NodeTint("#3333FF")]
    public class RandomNode : DialogueBaseNode
    {
        [Output(dynamicPortList = true)] public string[] randomEntries = new string[0];

        public override void Trigger()
        {
            int index = UnityEngine.Random.Range(0, randomEntries.Length);

            NodePort port;
            if (randomEntries.Length == 0)
            {
                port = GetOutputPort("output");
            }
            else
            {
                if (randomEntries.Length <= index) return;
                port = GetOutputPort("randomEntries " + index);
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
    }
}
