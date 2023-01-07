using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class puzzleHackPC : MonoBehaviour
{
    private String _solutionCode;
    private String _nextNode;
    private int numberoftries = 0;
    public void ActivatePuzzle(String code,string nextNode)
    {
        _solutionCode = code;
        _nextNode = nextNode;
    }

    [SerializeField] private GameObject MaxNumberOfErrors;
    [SerializeField] private GameObject fichas;
    public void CheckCode(TMP_InputField input)
    {
         
        if (string.Equals(input.text, _solutionCode, StringComparison.OrdinalIgnoreCase) &&numberoftries <= 3)
        {
            input.text = "";
            fichas.SetActive(true);
        }
        else
        {
            numberoftries += 1;
            if (numberoftries > 3)
            {
                MaxNumberOfErrors.SetActive(true);
            }
        }
    }

    public void FinishPuzzle()
    {
        FlowChartManager.Instance.CallBlock(_nextNode);
       
        DesactivatePuzle();
    }
    public void DesactivatePuzle()
    {
        _nextNode = "";
        gameObject.SetActive(false);
    }
}
