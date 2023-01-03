using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReorderCanvas : MonoBehaviour
{
    public static ReorderCanvas Instance;
    int m_IndexNumber;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }else{Destroy(gameObject);}
        m_IndexNumber = 0;
        //Set the Sibling Index
        m_IndexNumber = transform.GetSiblingIndex();
    }

    public void GoToFront()
    {
    }
}
