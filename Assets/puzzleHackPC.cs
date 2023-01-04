using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class puzzleHackPC : MonoBehaviour
{
    private String _solutionCode;
    private String _nextNode;
    public void ActivatePuzzle(String code,string nextNode)
    {
        _solutionCode = code;
        _nextNode = nextNode;
    }
    public void CheckCode(TMP_InputField input)
    {
         
        if (string.Equals(input.text, _solutionCode, StringComparison.OrdinalIgnoreCase))
        {
            FlowChartManager.Instance.CallBlock(_nextNode);
            input.text = "";
            DesactivatePuzle();


        }
        else
        {
            
        }
    }
    public void DesactivatePuzle()
    {
        _nextNode = "";
        gameObject.SetActive(false);
    }
}
