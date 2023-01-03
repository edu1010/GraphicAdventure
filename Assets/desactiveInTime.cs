using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desactiveInTime : MonoBehaviour
{
    public float timeActive;
    private float _elapsedTime;
    private void OnEnable()
    {
        _elapsedTime = 0;
    }
    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > timeActive)
        {
            gameObject.SetActive(false);
        }
    }
}
