using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
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
    public Slider sliderTimer;
    public float MaxTime = 1;
    private float _elapsedTime=0;
    public Flowchart flowchartCombat;
    private StringVariable conversation;

    public List<String> frasesGuardia = new List<string>();
    public List<String> frasesGolpe = new List<string>();
    public List<String> frasesPatada = new List<string>(); 
    
    public List<String> frasesGuardiaEnemy = new List<string>();
    public List<String> frasesGolpeEnemy   = new List<string>();
    public List<String> frasesPatadaEnemy  = new List<string>();
    public Text butonGuardia;
    public Text butonGolpe;
    public Text butonPatada;
    public AttackType enemyAttack;
    
    //para pruebas
    public Character ch1;
    private void Awake()
    {

        ActivatePuzzle(ch1, "");
    }

    private int _decisionEnemy = 0;
    private string _fraseEnemigo;
    public void ActivatePuzzle(Character enemy,string nextNode)
    {
        _enemy = enemy;
        _nextNode = nextNode;
        hplayer = 100;
        hpenemy = 100;
        enemyName.text = enemy.NameText;
        sliderPlayer.maxValue = 100;
        sliderEnemy.maxValue = 100;
        sliderTimer.maxValue = MaxTime;
        SetHealhBar();
        BucleConversationStart();
    }

    public void BucleConversationStart()
    {
        _decisionEnemy = Random.Range(0, 3);
        Debug.Log("decision enemy "+_decisionEnemy);
        switch (_decisionEnemy)
        {
            case 0:
                _fraseEnemigo = frasesGuardiaEnemy[Random.Range(0,frasesGuardiaEnemy.Count)];
                SetConversation(AttackType.Guardia, _fraseEnemigo);
                break;
            case 1:
                _fraseEnemigo = frasesGolpeEnemy[Random.Range(0,frasesGolpeEnemy.Count)];
                SetConversation(AttackType.Golpe, _fraseEnemigo);
                break;
            case 2:
                _fraseEnemigo = frasesPatadaEnemy[Random.Range(0,frasesPatadaEnemy.Count)];
                SetConversation(AttackType.Patada, _fraseEnemigo);
                break;
        }
    }

    public void DesactivatePuzle()
    {
        _nextNode = "";
        gameObject.SetActive(false);
    }


    public void SetConversation(AttackType attack, string frase)
    {
        string txt = _enemy.NameText + ":" + frase;
        
        //flowchartCombat.GetVariable<StringVariable>("Conversation").Value = $"Reinhard Mittermeyer reinhard_test: Holi";
        flowchartCombat.GetVariable<StringVariable>("Conversation").Value = txt;
        flowchartCombat.ExecuteBlock("EnemyText");
        SetAnswers();
    }

    public void SetAnswers()
    {
        butonGuardia.text = frasesGuardia[Random.Range(0, frasesGuardia.Count-1)];
        butonGolpe.text = frasesGolpe[Random.Range(0, frasesGuardia.Count-1)];
        butonPatada.text = frasesPatada[Random.Range(0, frasesGuardia.Count-1)];
        _elapsedTime = 0f;
       
        sliderTimer.value = MaxTime;
        restTime = true;

    }

    private bool restTime = false;
    public void Update()
    {
        if (restTime)
        {
            _elapsedTime += Time.deltaTime;
            sliderTimer.value -= Time.deltaTime;
            if (_elapsedTime > MaxTime)
            {
                _elapsedTime = 0;
                restTime = false;
            }
        }
    }

  
    public void PlayerAnswer(int decision)//Button call thiis function
    {
        switch (decision)
        {
            case 0:
                PlayerAnswer(AttackType.Guardia);
                break;
            case 1:
                PlayerAnswer(AttackType.Golpe);
                break;
            case 2:
                PlayerAnswer(AttackType.Patada);
                break;
        }
    }
    private void PlayerAnswer(AttackType playerAttack)
    {
        restTime = false;
        _elapsedTime = 0;
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
                    //hpenemy -= 10;
                    //hplayer -= 10;
                    //nada
                }
                break;
        }

        SetHealhBar();
        if (hpenemy > 0 && hplayer > 0)
        {
            BucleConversationStart();
        }
        else
        {
            if (hplayer > 0)
            {
                //win
                PlayerWin();
            }
            else
            {
                ResetCombat();
            }
        }
    }

    public void PlayerWin()
    {
        FlowChartManager.Instance.CallBlock(_nextNode);
        DesactivatePuzle();
    }

    public void ResetCombat()
    {
        ActivatePuzzle(_enemy,_nextNode);
    }
    public void SetHealhBar()
    {
        sliderPlayer.value = hplayer;
        sliderEnemy.value = hpenemy;
    }

    public void prueba()
    {
        flowchartCombat.GetVariable<StringVariable>("Conversation").Value=" Reinhard Mittermeyer reinhard_test  Hide Reinhard: chao";
        flowchartCombat.GetVariable<StringVariable>("Conversation").Value=" Erberk Demir: chao";
        flowchartCombat.ExecuteBlock("EnemyText");
    }   
}
public enum AttackType
{
    Guardia,
    Golpe,
    Patada
}
