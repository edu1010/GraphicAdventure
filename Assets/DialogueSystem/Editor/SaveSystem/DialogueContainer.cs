using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueContainer : ScriptableObject
{
    public List<NodeLinkData> nodeLinkDatas = new List<NodeLinkData>();
    public List<DialogueNodeData> dialogueNodeDatas = new List<DialogueNodeData>();
}
