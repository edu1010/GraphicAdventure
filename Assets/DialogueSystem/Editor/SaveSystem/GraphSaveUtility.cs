using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using System.Linq;

public class GraphSaveUtility 
{
    private DialogueGraphView m_targetGrapView;

    private List<Edge> edges => m_targetGrapView.edges.ToList();
    private List<DialogueNode> Nodes=> m_targetGrapView.nodes.ToList().Cast<DialogueNode>().ToList();
    public static GraphSaveUtility GetInstance(DialogueGraphView targetGraphView)
    {
        return new GraphSaveUtility
        {
            m_targetGrapView = targetGraphView
        };
    }
    public void SaveGraph(string fileName)
    {
        if (!edges.Any()) { return; }
        var dialogueContainer = ScriptableObject.CreateInstance<DialogueContainer>();
        var conectedPorts = edges.Where(x => x.input.node != null).ToArray();
        
    }
    public void LoadGraph(string fileName)
    {

    }
}
