using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleVeneno : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private String _solutionCode;
    private String _nextNode;
    public void OpenPage()
    {
        _animator.SetTrigger("Open");
    }
 public void ClosePage()
    {
        _animator.SetTrigger("Close");
    }

    public void ActivatePuzzle(String code,string nextNode)
    {
        gameObject.SetActive(true);
        _animator.SetTrigger("Init");
        _solutionCode = code;
        _nextNode = nextNode;
    }

    public void DesactivatePuzle()
    {
        _nextNode = "";
        gameObject.SetActive(false);
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
  
}
