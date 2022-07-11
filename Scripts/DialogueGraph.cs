using System.Linq;
using UnityEngine;
using XNode;

namespace Dialogue
{
    [CreateAssetMenu(menuName = "Dialogue/Graph", order = 0)]
    public class DialogueGraph : NodeGraph
    {
        [HideInInspector]
        public DialogueBaseNode current;

        public void Restart()
        {
            // Find the first DialogueNode without any inputs. This is the starting node.
            current = nodes.Find(x => x.Inputs.All(y => !y.IsConnected)) as DialogueBaseNode;
            if (current != null)
                current.Trigger();
        }
    }
}