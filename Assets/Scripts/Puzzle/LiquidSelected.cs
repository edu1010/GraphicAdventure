using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LiquidSelected : MonoBehaviour
{ 
    [SerializeField]
    Sprite image;
    [SerializeField]
    private string drinkName, drinkDescription; 
    Button button;
    [SerializeField] private Material liquidMat;
    [SerializeField,Tooltip("Change the material of the base or of the extra")]
    private bool isBase=true;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChangeSelected);
    }

    public void ChangeSelected()
    {
        BlackBoardPuzzle1.Instance.drinksNameText.text = drinkName;
        BlackBoardPuzzle1.Instance.drinksNameText.text = drinkDescription;
        if (isBase)
        {
            BlackBoardPuzzle1.Instance.quadBase.GetComponent<Renderer>().material = liquidMat;
        }
        else
        {
            BlackBoardPuzzle1.Instance.quadExtra.GetComponent<Renderer>().material = liquidMat;
        }
    }
}
