using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FichaDescriptionText : MonoBehaviour
{
    public static FichaDescriptionText Instance;

    public TextMeshProUGUI textDesc;
    // Start is called before the first frame update
    void Awake()
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

  
}
