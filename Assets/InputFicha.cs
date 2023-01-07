using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InputFicha : MonoBehaviour
{

    public GameObject fichas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            if (fichas.activeSelf)
            {
                fichas.SetActive(false);
            }
            else
            {
                fichas.SetActive(true);
            }
        }
    }
}
