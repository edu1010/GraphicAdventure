using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class puzzleHackPC : MonoBehaviour
{
    private String _solutionCode;
    private String _nextCorrectNode;
    private String _nextFailNode;
    private int numberoftries = 0;
    public void ActivatePuzzle(String passwordPoliceApp,string nextNodeDeleteFicha,string nextNodeFailDelete)
    {
        gameObject.SetActive(true);
        _solutionCode = passwordPoliceApp;
        _nextCorrectNode = nextNodeDeleteFicha;
        _nextFailNode = nextNodeFailDelete;
    }

    [SerializeField] private GameObject MaxNumberOfErrors;
    [SerializeField] private GameObject fichas;
    [SerializeField] private TextMeshProUGUI textoNumErrores;
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
                textoNumErrores.text = "3 de 3 intentos";
                MaxNumberOfErrors.SetActive(true);
            }
            else
            {
                textoNumErrores.gameObject.SetActive(true);
                textoNumErrores.text = numberoftries + " de 3 intentos";
            }
            
        }
    }

    public void FailPuzzle()
    {
        FlowChartManager.Instance.CallBlock(_nextFailNode);
       
        DesactivatePuzle();
    }
    public void FinishPuzzle()
    {
        FlowChartManager.Instance.CallBlock(_nextCorrectNode);
       
        DesactivatePuzle();
    }
    public void DesactivatePuzle()
    {
        _nextCorrectNode = "";
        gameObject.SetActive(false);
    }
}
