using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class puzzleCombat : MonoBehaviour
{
    private String _nextNode;
    private Character _enemy;
    public TextMeshProUGUI enemyName;
    private float hplayer = 100;
    private float hpenemy = 100;
    public Slider sliderPlayer;
    public Slider sliderEnemy;
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
        hpenemy = 100;
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

    public void PlayerAnswer(AttackType playerAttack)
    {
        switch (playerAttack)
        {
            case AttackType.Guardia:
                if (enemyAttack == AttackType.Guardia)
                {
                    //nada
                }

                if (enemyAttack == AttackType.Golpe)
                {
                    hpenemy -= 20;
                }

                if (enemyAttack == AttackType.Patada)
                {
                    hplayer -= 20;
                }
                break;
            case AttackType.Golpe:

                if (enemyAttack == AttackType.Guardia)
                {
                    hplayer -= 20;
                }

                if (enemyAttack == AttackType.Golpe)
                {
                    hplayer -= 20;
                    hpenemy -= 20;
                }

                if (enemyAttack == AttackType.Patada)
                {
                    hpenemy -= 20;
                }
                break;
            case AttackType.Patada:

                if (enemyAttack == AttackType.Guardia)
                {
                    hpenemy -= 20;
                }

                if (enemyAttack == AttackType.Golpe)
                {
                    hplayer -= -20;
                }

                if (enemyAttack == AttackType.Patada)
                {
                    //nada
                }
                break;
        }

        SetHealhBar();
    }

    public void SetHealhBar()
    {
        sliderPlayer.value = hplayer;
        sliderEnemy.value = hpenemy;
    }
    public enum AttackType
    {
        Guardia,
        Golpe,
        Patada
    }
}
