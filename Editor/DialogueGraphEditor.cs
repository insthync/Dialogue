using Dialogue;
using XNodeEditor;

namespace DialogueEditor
{
	[CustomNodeGraphEditor(typeof(DialogueGraph))]
	public class DialogueGraphEditor : NodeGraphEditor
	{
		public override string GetNodeMenuName(System.Type type)
		{
			if (type.IsSubclassOf(typeof(DialogueBaseNode))) return base.GetNodeMenuName(type);
			else return null;
		}
	}
}