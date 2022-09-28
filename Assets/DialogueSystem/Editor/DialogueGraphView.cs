using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using System;

public class DialogueGraphView : GraphView
{
    private readonly Vector2 defaultSize = new Vector2(150,200);
    public DialogueGraphView()
    {
        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new RectangleSelector());
        AddElement(GenerateEntryPointNode());
    }
    private Port GeneratePort(DialogueNode node,Direction portDirection,Port.Capacity capacity = Port.Capacity.Single)
    {
        return node.InstantiatePort(Orientation.Horizontal, portDirection, capacity, typeof(string));
    }
    private DialogueNode GenerateEntryPointNode()
    {
        var node = new DialogueNode
        {
            title = "Start",
            GUID = Guid.NewGuid().ToString(),
            DialogueText = "ENTRYPOINT",
            EntryPoint = true
        };
        var generatedPort = GeneratePort(node, Direction.Output);
        generatedPort.name = "Next";
        node.outputContainer.Add(generatedPort);

        

        node.RefreshPorts();//Solo es visual
        node.RefreshExpandedState();//Solo es visual
        


        node.SetPosition(new Rect(100, 200, 100, 150));
        return node;
    }

    private void AddChoicePort(DialogueNode node)
    {
        var generatedPort = GeneratePort(node,Direction.Output);
        var outputPortCount = node.outputContainer.Query("connector").ToList().Count;
        generatedPort.portName= $"Choice {outputPortCount}";
        node.outputContainer.Add(generatedPort);
        node.RefreshExpandedState();//Solo es visual
        node.RefreshPorts();//Solo es visual
        
        
    }

    public void CreateNode(string nodeName) 
    {
        AddElement(createDialogueNode(nodeName));
    }
    public DialogueNode createDialogueNode(string nodeName)
    {
        var dialogeNode = new DialogueNode
        {
            title = nodeName,
            DialogueText = nodeName,
            GUID = Guid.NewGuid().ToString()
        };
        var inputPort = GeneratePort(dialogeNode,Direction.Input,Port.Capacity.Multi);
        inputPort.name = "Input";

        dialogeNode.inputContainer.Add(inputPort);
        var button = new Button(() => { AddChoicePort(dialogeNode); });
        button.text = "New answer";
        dialogeNode.titleContainer.Add(button);

        dialogeNode.RefreshExpandedState();//Solo es visual
        dialogeNode.RefreshPorts();//Solo es visual

        dialogeNode.SetPosition(new Rect(Vector2.zero,defaultSize));

        return dialogeNode;
    }
    public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
    {//este metodo es el que acepta que al arrastrar la flecha se atache al puerto, util en shader graph aqui solo miraremos de conectarnos a nosotros
        var compatiblePorts = new List<Port>();
        ports.ForEach(port => 
        {
            if(startPort!=port && startPort.node != port.node)
            {
                compatiblePorts.Add(port);
            }
        });
        return compatiblePorts;
    }
}
