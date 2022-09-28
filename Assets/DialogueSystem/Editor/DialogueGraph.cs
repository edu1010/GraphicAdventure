using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEditor;
using UnityEngine.UIElements;
public class DialogueGraph : EditorWindow
{
    private DialogueGraphView graphView;
    [MenuItem("Graph/Dialogue graph by Edu ;)")]
   public static void OpenDialogueGraphWindow()
    {
        var window = GetWindow<DialogueGraph>();
        window.titleContent = new GUIContent("Dialogue graph by Edu");
    }
    private void OnEnable()
    {
        graphView = new DialogueGraphView 
        {
            name = "Dialogue graph"
        };
        graphView.StretchToParentSize();
        rootVisualElement.Add(graphView);
    }
    private void OnDisable()
    {
        rootVisualElement.Remove(graphView);
    }
}
