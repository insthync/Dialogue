using Dialogue;
using UnityEditor;
using XNodeEditor;

namespace DialogueEditor
{
    [CustomNodeEditor(typeof(Branch))]
    public class BranchEditor : NodeEditor
    {

        public override void OnBodyGUI()
        {
            serializedObject.Update();

            NodeEditorGUILayout.PortField(target.GetInputPort("input"));
            EditorGUILayout.Space();
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("conditions"));
            NodeEditorGUILayout.PortField(target.GetOutputPort("pass"));
            NodeEditorGUILayout.PortField(target.GetOutputPort("fail"));

            serializedObject.ApplyModifiedProperties();
        }

        public override int GetWidth()
        {
            return 336;
        }
    }
}
