using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    private Transform[] particlesBase;
    private Transform[] particlesExtra;
    private Transform[] particlesPosion;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private GameObject poolBase, poolExtra, poolPosion;
    public OutputPuzzle solution;

    // Start is called before the first frame update
    void Start()
    {
        particlesBase =  poolBase.GetComponentsInChildren<Transform>();
        particlesExtra = poolExtra.GetComponentsInChildren<Transform>();
        particlesPosion = poolPosion.GetComponentsInChildren<Transform>();
    }

    private void Spawn(Transform[] gameObjectsToSpawn)
    {
        foreach (var particlesBase in gameObjectsToSpawn)
        {
            particlesBase.position = spawnPos.position;
            particlesBase.gameObject.SetActive(true);
        }
    }

    private bool servedBase, servedExtra, servedPossion = false;
    public void ButtonSpawn()
    {
        switch (BlackBoardPuzzle1.Instance.actualMenu)
        {
            case (BlackBoardPuzzle1.ActualMenu.Base):

                if (!servedBase)
                {
                    Spawn(particlesBase);
                    
                    servedBase = true;
                }
                break;
            case (BlackBoardPuzzle1.ActualMenu.Extra):

                if (!servedExtra)
                {
                    Spawn(particlesExtra);
                    servedExtra = true;
                }
                break;
            case (BlackBoardPuzzle1.ActualMenu.Posion):
                if (!servedPossion)
                {
                    Spawn(particlesPosion);
                    
                    servedPossion = true;
                }
                break;
        }
       
    }

    public void ButtonReset()
    {
        servedBase   = false;
        servedExtra  = false;
        servedPossion= false;
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

    public bool Entregar()
    {
        if (BlackBoardPuzzle1.Instance.selectedBase != solution.drinkBase && BlackBoardPuzzle1.Instance.selectedExtra != solution.drinkExtra)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
