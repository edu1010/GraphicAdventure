using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using TMPro;
using UnityEngine;

public class puzzleCombat : MonoBehaviour
{
    private String _nextNode;
    private Character _enemy;
    public TextMeshProUGUI enemyName;
    private float hplayer = 100;
    private float henemy = 100;
    public Flowchart flowchartCombat;
    private StringVariable conversation;

    public List<String> frasesGuardia = new List<string>();
    public List<String> frasesGolpe = new List<string>();
    public List<String> frasesPatada = new List<string>();
    private void Awake()
    {
        
        SetConversation();
    }

    [SerializeField]
    public void ActivatePuzzle(Character enemy,string nextNode)
    {
        _enemy = enemy;
        _nextNode = nextNode;
        hplayer = 100;
        henemy = 100;
        enemyName.text = enemy.NameText;
    }
    

    public void DesactivatePuzle()
    {
        _nextNode = "";
        gameObject.SetActive(false);
    }

    private float f=0;
    public void SetConversation()
    {


        flowchartCombat.GetVariable<StringVariable>("Conversation").Value = "Reinhard Mittermeyer reinhard_test: Holi";
        f = Time.time;
    }

    private void Update()
    {
        if (Time.time > 2)
        {
            prueba();
        }
    }

    public void prueba()
    {
        flowchartCombat.GetVariable<StringVariable>("Conversation").Value=" Reinhard Mittermeyer reinhard_test clear: chao";
        flowchartCombat.ExecuteBlock("EnemyText");

    }
}
