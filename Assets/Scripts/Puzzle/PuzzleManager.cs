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

    public void ButtonSpawnBase()
    {
        Spawn(particlesBase);
    }
    public void ButtonSpawnExtra()
    {
        Spawn(particlesExtra);
    }
    public void ButtonSpawnPosion()
    {
        Spawn(particlesPosion);
    }

    public void ButtonReset()
    {
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
}
