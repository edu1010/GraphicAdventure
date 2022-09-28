using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using System;

public class DialogueGraphView : GraphView
{
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

        node.RefreshExpandedState();//Solo es visual
        node.RefreshPorts();//Solo es visual


        node.SetPosition(new Rect(100, 200, 100, 150));
        return node;
    }
}
