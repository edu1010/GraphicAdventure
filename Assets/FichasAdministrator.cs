using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FichasAdministrator : MonoBehaviour
{
    public GameObject[] Fichas;

    private int index = 0;

    public void AddIndex()
    {
        Fichas[index].SetActive(false);
        index += 1;
        if (index >= Fichas.Length)
        {
            index = 0;
        }
        Fichas[index].SetActive(true);
    }

    public void SustractIndex()
    {
        Fichas[index].SetActive(false);
        index -= 1;
        if (index < 0)
        {
            index = Fichas.Length-1;
        }
        Fichas[index].SetActive(true);
        
    }
    
}
