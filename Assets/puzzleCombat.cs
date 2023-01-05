using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


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
    public TextMeshProUGUI butonGuardia;
    public TextMeshProUGUI butonGolpe;
    public TextMeshProUGUI butonPatada;
    public AttackType enemyAttack;
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


    public void SetConversation()
    {
        flowchartCombat.GetVariable<StringVariable>("Conversation").Value = "Reinhard Mittermeyer reinhard_test: Holi";
    }

    public void SetAnswers()
    {
        butonGuardia.text = frasesGuardia[Random.Range(0, frasesGuardia.Count)];
        butonGolpe.text = frasesGolpe[Random.Range(0, frasesGuardia.Count)];
        butonPatada.text = frasesPatada[Random.Range(0, frasesGuardia.Count)];
    }

    public void prueba()
    {
        flowchartCombat.GetVariable<StringVariable>("Conversation").Value=" Reinhard Mittermeyer reinhard_test  Hide Reinhard: chao";
        flowchartCombat.GetVariable<StringVariable>("Conversation").Value=" Erberk Demir: chao";
        flowchartCombat.ExecuteBlock("EnemyText");

    }

    public void PlayerAnswer(AttackType player)
    {
        
    }
    public enum AttackType
    {
        Guardia,
        Golpe,
        Patada
    }
}
