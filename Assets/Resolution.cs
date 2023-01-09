using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    private int w = 1920;
    private int H = 1080;
    // Start is called before the first frame update
    void Awake()
    {
        Screen.SetResolution(w,H,FullScreenMode.FullScreenWindow);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
