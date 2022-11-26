using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class BlackBoardPuzzle1 : MonoBehaviour
{
    public static BlackBoardPuzzle1 Instance;

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

    public TextMeshProUGUI drinksDescriptionText;
    public TextMeshProUGUI drinksNameText;
    public GameObject quadBase, quadExtra, quadPosion;
    public DrinkBase selectedBase;
    public DrinkExtra selectedExtra;
    public bool possion;
    public ActualMenu actualMenu;

    #region Canvas

    [FormerlySerializedAs("baseButtons")] public GameObject baseDrinks;
    [FormerlySerializedAs("extraButtons")] public GameObject extraDrinks;
    [FormerlySerializedAs("possionButtons")] public GameObject possionDrinks;
    

    #endregion
    public enum DrinkBase
    {
        Tequila
    }  
    public enum DrinkExtra
    {
        Extra1,
        Extra2
    }
    public enum ActualMenu
    {
        Base,
        Extra,
        Posion
    }

    public void ChangeToBase()
    {
        SetActualMenu(ActualMenu.Base);
    }

    public void ChangeToExtra()
    {
        SetActualMenu(ActualMenu.Extra);
    }

    public void ChangeToPossion()
    {
        SetActualMenu(ActualMenu.Posion);
    }

    private void SetActualMenu(ActualMenu newMenu)
    {
        actualMenu = newMenu;
        switch (actualMenu)
        {
            case (ActualMenu.Base):
                baseDrinks.SetActive(true);
                extraDrinks.SetActive(false);
                possionDrinks.SetActive(false);
                break;
            case (ActualMenu.Extra):
                baseDrinks.SetActive(false);
                extraDrinks.SetActive(true);
                possionDrinks.SetActive(false);
                break;
            case (ActualMenu.Posion):
                baseDrinks.SetActive(false);
                extraDrinks.SetActive(false);
                possionDrinks.SetActive(true);
                break;
        }
    }

}
