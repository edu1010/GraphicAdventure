using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
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
    
}
