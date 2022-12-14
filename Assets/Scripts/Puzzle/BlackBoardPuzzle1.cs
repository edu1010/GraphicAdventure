using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

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
    public DrinkBase selectedBase = DrinkBase.noSelected;
    public DrinkExtra selectedExtra= DrinkExtra.noSelected;
    public bool possionNoSelected = true;
    public bool possion =false;
    public ActualMenu actualMenu = ActualMenu.Base;
    public int DrinkSize = 1;
    #region Canvas

    [FormerlySerializedAs("baseButtons")] public GameObject baseDrinks;
    [FormerlySerializedAs("extraButtons")] public GameObject extraDrinks;
    [FormerlySerializedAs("possionButtons")] public GameObject possionDrinks;
    public GameObject baseDrinksParent;
    public GameObject extraDrinksParent;
    public GameObject posionDrinksParent;
    private Button[] _desativeBaseButtons,_desactiveExtraDrinks,_desactivePossionDrinks;
    public TextMeshProUGUI sizeDrinks;
    public Image selectedImage;
    #endregion

    public void ChangeImage(Sprite sp)
    {
        selectedImage.gameObject.SetActive(true);
        selectedImage.sprite = sp;
    }
    private void Start()
    {
        _desativeBaseButtons = baseDrinks.GetComponentsInChildren<Button>();
        _desactiveExtraDrinks = extraDrinks.GetComponentsInChildren<Button>();
        _desactivePossionDrinks = possionDrinks.GetComponentsInChildren<Button>();
    }

    public enum DrinkBase
    {
        Tequila,
        Jagger,
        LicorDeManzana,
        noSelected
    }  
    public enum DrinkExtra
    {
        Menta,
        Limon,
        FrutosDelBosque,
        Pi??a,
        Nada,
        noSelected
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
                baseDrinksParent.SetActive(true);
                extraDrinksParent.SetActive(false);
                posionDrinksParent.SetActive(false);
                
                baseDrinks.SetActive(true);
                extraDrinks.SetActive(false);
                possionDrinks.SetActive(false);
                break;
            case (ActualMenu.Extra):
                baseDrinksParent.SetActive(false);
                extraDrinksParent.SetActive(true);
                posionDrinksParent.SetActive(false);
                
                baseDrinks.SetActive(false);
                extraDrinks.SetActive(true);
                possionDrinks.SetActive(false);
                break;
            case (ActualMenu.Posion):
                baseDrinksParent.SetActive(false);
                extraDrinksParent.SetActive(false);
                posionDrinksParent.SetActive(true);
                
                baseDrinks.SetActive(false);
                extraDrinks.SetActive(false);
                possionDrinks.SetActive(true);
                break;
        }
    }

    public void DesactiveBase()
    {
        foreach (var go in _desativeBaseButtons)
        {
            go.enabled = false;
        }
    }
    public void DesactiveExtra()
    {
        foreach (var go in _desactiveExtraDrinks)
        {
            go.enabled = false;
        }
    }
    public void DesactivePosion()
    {
        foreach (var go in _desactivePossionDrinks)
        {
            go.enabled = false;
        }
    }
    public void ActiveBase()
    {
        foreach (var go in _desativeBaseButtons)
        {
            go.enabled = true;
        }
    }
    public void ActiveExtra()
    {
        foreach (var go in _desactiveExtraDrinks)
        {
            go.enabled = true;
        }
    }
    public void ActivePossion()
    {
        foreach (var go in _desactivePossionDrinks)
        {
            go.enabled = true;
        }
    }

}
