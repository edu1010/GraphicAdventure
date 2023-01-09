using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public Transform[] particlesBase;
    public Transform[] particlesExtra;
    public Transform[] particlesPosion;
    [SerializeField] private Transform spawnPos;
    //[SerializeField] private GameObject poolBase, poolExtra, poolPosion;
    public OutputPuzzle solution;
    public static PuzzleManager Instance;
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

    // Start is called before the first frame update
    void Start()
    {
        //particlesBase =  poolBase.GetComponentsInChildren<Transform>();
        //particlesExtra = poolExtra.GetComponentsInChildren<Transform>();
        //particlesPosion = poolPosion.GetComponentsInChildren<Transform>();
    }

    public void OnEnable()
    {
        StartCoroutine(ResetPuzzle());
    }

    IEnumerator ResetPuzzle()
    {
        yield return null;
        ButtonReset();
    }

    private void Spawn(Transform[] gameObjectsToSpawn)
    {
        foreach (var particlesBase in gameObjectsToSpawn)
        {
            particlesBase.position = spawnPos.position;
            particlesBase.gameObject.SetActive(true);
        }
    }

    public bool servedBase, servedExtra, servedPossion = false;
    public void ButtonSpawn()
    {
        switch (BlackBoardPuzzle1.Instance.actualMenu)
        {
            case (BlackBoardPuzzle1.ActualMenu.Base):

                if (!servedBase && BlackBoardPuzzle1.Instance.selectedBase!=BlackBoardPuzzle1.DrinkBase.noSelected)
                {
                    Spawn(particlesBase);
                    BlackBoardPuzzle1.Instance.DesactiveBase();
                    servedBase = true;
                }
                break;
            case (BlackBoardPuzzle1.ActualMenu.Extra):

                if (!servedExtra && BlackBoardPuzzle1.Instance.selectedExtra!=BlackBoardPuzzle1.DrinkExtra.noSelected)
                {
                    Spawn(particlesExtra);
                    
                    BlackBoardPuzzle1.Instance.DesactiveExtra();
                    servedExtra = true;
                }
                break;
            case (BlackBoardPuzzle1.ActualMenu.Posion):
                if (!servedPossion && !BlackBoardPuzzle1.Instance.possionNoSelected)
                {
                    Spawn(particlesPosion);
                    
                    BlackBoardPuzzle1.Instance.DesactivePosion();
                    servedPossion = true;
                    BlackBoardPuzzle1.Instance.possion = servedPossion;
                }
                break;
        }
       
    }

    public void ButtonReset()   
    {
        BlackBoardPuzzle1.Instance.ActiveBase();
        BlackBoardPuzzle1.Instance.ActiveExtra();
        BlackBoardPuzzle1.Instance.ActivePossion();
        servedBase   = false;
        servedExtra  = false;
        servedPossion= false;
        BlackBoardPuzzle1.Instance.selectedBase = BlackBoardPuzzle1.DrinkBase.noSelected;
        BlackBoardPuzzle1.Instance.selectedExtra =BlackBoardPuzzle1.DrinkExtra.noSelected;
        BlackBoardPuzzle1.Instance.possion =false;
        BlackBoardPuzzle1.Instance.possionNoSelected = true; 
        foreach (var go in particlesBase)
        {
            go.gameObject.SetActive(false);
        }
        foreach (var go in particlesExtra)
        {
            go.gameObject.SetActive(false);
        }
        foreach (var go in particlesPosion)
        {
            go.gameObject.SetActive(false);
        }
    }

    public void ButtonIncrementDrink()
    {
        BlackBoardPuzzle1.Instance.DrinkSize += 1;
        if (BlackBoardPuzzle1.Instance.DrinkSize > 2)
        {
            BlackBoardPuzzle1.Instance.DrinkSize = 2;
        }

        BlackBoardPuzzle1.Instance.sizeDrinks.text = BlackBoardPuzzle1.Instance.DrinkSize+"";
    }
    public void ButtonDecrementDrink()
    {
        BlackBoardPuzzle1.Instance.DrinkSize -= 1;
        if (BlackBoardPuzzle1.Instance.DrinkSize < 1)
        {
            BlackBoardPuzzle1.Instance.DrinkSize = 1;
        }
        BlackBoardPuzzle1.Instance.sizeDrinks.text = BlackBoardPuzzle1.Instance.DrinkSize+"";
    }

    public void Entregar()
    {
        if (BlackBoardPuzzle1.Instance.selectedBase == solution.drinkBase 
            && BlackBoardPuzzle1.Instance.selectedExtra == solution.drinkExtra
            && BlackBoardPuzzle1.Instance.DrinkSize == solution.cantidad)
        {

            FlowChartManager.Instance.ResultPuzzle(true,BlackBoardPuzzle1.Instance.possion, solution.resultadoPositivo);
            
        }
        else
        {
            FlowChartManager.Instance.ResultPuzzle(false,false, solution.resultadoNegativo);
          
        }
    }
}
