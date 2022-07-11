using UnityEditor;
using UnityEngine;
using XNode;
using XNodeEditor;

namespace Dialogue
{
    [CustomNodeEditor(typeof(Chat))]
    public class ChatEditor : NodeEditor
    {

        public override void OnBodyGUI()
        {
            serializedObject.Update();

            Chat node = target as Chat;

            EditorGUILayout.PropertyField(serializedObject.FindProperty("character"), GUIContent.none);
            if (node.answers.Count == 0)
            {
                GUILayout.BeginHorizontal();
                NodeEditorGUILayout.PortField(GUIContent.none, target.GetInputPort("input"), GUILayout.MinWidth(0));
                NodeEditorGUILayout.PortField(GUIContent.none, target.GetOutputPort("output"), GUILayout.MinWidth(0));
                GUILayout.EndHorizontal();
            }
            else
            {
                NodeEditorGUILayout.PortField(GUIContent.none, target.GetInputPort("input"));
            }
            GUILayout.Space(-30);

            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("title"), GUIContent.none);
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("titleByLanguageKeys"), GUIContent.none);
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("text"), GUIContent.none);
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("textByLanguageKeys"), GUIContent.none);
            NodeEditorGUILayout.DynamicPortList("answers", typeof(DialogueBaseNode), serializedObject, NodePort.IO.Output, Node.ConnectionType.Override);

            serializedObject.ApplyModifiedProperties();
        }

        public override int GetWidth()
        {
            return 300;
        }
    }
}