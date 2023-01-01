using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class FlowChartManager : MonoBehaviour
{
    public Flowchart fl;
    public GameObject[] goToActivegoToActive;

    public static FlowChartManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ActivePuzzle(OutputPuzzle ou)
    {
       
        print(ou.drinkBase);
        foreach (var go in goToActivegoToActive)
        {
            go.SetActive(true);
        }
        PuzzleManager.Instance.solution = ou;
    }

    [SerializeField] private GameObject _puzleVenenoGameObject;
    [SerializeField] private PuzzleVeneno _puzleVeneno;
    public void ActivatePuzzleVeneno(String code,string nextNode)
    {
        _puzleVenenoGameObject.SetActive(true);
        _puzleVeneno.ActivatePuzzle(code,nextNode);
    }

    public void SetFlowChart(Flowchart flowchart)
    {
        fl = flowchart;
    }
    public void ResultPuzzle(bool correctDrink,bool possion,string nextNode)
    {
        if (correctDrink)
        {
            fl.SetBooleanVariable("correctDrink",correctDrink);
            fl.SetBooleanVariable("possion",possion);
            fl.SetBooleanVariable("finishPreparation",true);
            
        }
        else
        {
            fl.SetBooleanVariable("possion",possion);
            fl.SetBooleanVariable("correctDrink",correctDrink); 
            fl.SetBooleanVariable("finishPreparation",true);
        }
        foreach (var go in goToActivegoToActive)
        {
            go.SetActive(false);
        }
        fl.ExecuteBlock(nextNode);

    }
    
    public  void CallBlock (String nextNode)
    {
        fl.ExecuteBlock(nextNode);
    }

    public void SetDescription(Fungus.Character character,String descripcion)
    {
        character.description = descripcion;
        Debug.Log(character.description);
    }
}
