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
    


    public void ActivePuzzle(OutputPuzzle ou)
    {
        print(ou.drinkBase);
        foreach (var go in goToActivegoToActive)
        {
            go.SetActive(true);
        }
    }
}
