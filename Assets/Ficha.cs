using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ficha : MonoBehaviour
{
    public string _nombre;
    public string _description;
    public Image _image;
    public TextMeshProUGUI _nombteTMP;
    public void setParameters(string nombre,string description,Sprite sprite)
    {
        _nombre = nombre;
        _nombteTMP.text = nombre;
        _description = description;
        _image.sprite = sprite;

    }
    public void ChangeDescription()
    {
        FichaDescriptionText.Instance.textDesc.text = _description;
    }


}
