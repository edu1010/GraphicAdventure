using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    [SerializeField] private GameObject fichaPrefab;
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject alerta;
    private List<Fungus.Character> fichasAñadidas = new List<Character>();
    private List<GameObject> fichasAñadidasGo = new List<GameObject>();
    public void SetDescription(Fungus.Character character,String descripcion)
    {
        if (fichasAñadidas.Contains(character))
        {
            GameObject tempGO = fichasAñadidasGo.Where(x=> x.GetComponent<Ficha>()._nombre == character.NameText).ToArray()[0];
            print(tempGO);
            Ficha tempFicha = tempGO.GetComponent<Ficha>(); 
             print(tempFicha._nombre);
            tempFicha.setParameters(character.NameText,descripcion,character.Portraits[0]);
            tempFicha.ChangeDescription();
             print(tempFicha._nombre);   
            //foreach (var f in fichasAñadidasGo)
            //{
            //    print(f.GetComponent<Ficha>()._nombre +" uwu "+character.NameText);
            //    if (f.GetComponent<Ficha>()._nombre == character.NameText)
            //    {
            //        print("nombre coincide");
            //        f.GetComponent<Ficha>().setParameters(character.NameText,descripcion,character.Portraits[0]);
            //        f.GetComponent<Ficha>().ChangeDescription();
            //    }
            //    
            //}
        }
        else
        {
            GameObject go = Instantiate(fichaPrefab,parent.transform);
            go.GetComponent<Ficha>().setParameters(character.NameText,descripcion,character.Portraits[0]);
            character.description = descripcion;
            fichasAñadidas.Add(character);
            fichasAñadidasGo.Add(go);
            alerta.SetActive(true);
            Debug.Log(character.description);
        }
        
        
    }
}
