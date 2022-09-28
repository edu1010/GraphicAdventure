using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;
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
        ContructGraphView();
        GenerateToolBar();
    }
    private void OnDisable()
    {
        rootVisualElement.Remove(graphView);
    }

    private void ContructGraphView()
    {
        graphView = new DialogueGraphView
        {
            name = "Dialogue graph"
        };
        graphView.StretchToParentSize();
        rootVisualElement.Add(graphView);
    }
    private void GenerateToolBar()
    {
        var toolBar = new Toolbar();
        var nodeCreateButton = new Button(()=>
        {
            graphView.CreateNode("Dialogue node");
        });
        nodeCreateButton.text = "Create Node";
        toolBar.Add(nodeCreateButton);
        rootVisualElement.Add(toolBar);
    }
}
