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
    private String _nextNodeWin;
    private String _nextNodeLose;
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
    private bool _james;
    public List<String> frasesGuardia = new List<string>();
    public List<String> frasesGolpe = new List<string>();
    public List<String> frasesPatada = new List<string>(); 
    
    private List<String> frasesGuardiaEnemy = new List<string>();
    private List<String> frasesGolpeEnemy   = new List<string>();
    private List<String> frasesPatadaEnemy  = new List<string>();
    
    public List<String> frasesGuardiaJames = new List<string>();
    public List<String> frasesGolpeJames   = new List<string>();
    public List<String> frasesPatadaJames  = new List<string>();
    
    public List<String> frasesGuardiaRyusuke  = new List<string>();
    public List<String> frasesGolpeRyusuke = new List<string>();
    public List<String> frasesPatadaRyusuke   = new List<string>();
    
    
    public Text butonGuardia;
    public Text butonGolpe;
    public Text butonPatada;
    public AttackType enemyAttack;
    
    //para pruebas
    public Character ch1;
  
    private int _decisionEnemy = 0;
    private string _fraseEnemigo;
    public void ActivatePuzzle(Character enemy,string nextNodeWinBattle,string nextNodeLoseBattle,bool James, float MaxTimeToAnswer)
    {
        gameObject.SetActive(true);
        _enemy = enemy;
        _nextNodeWin = nextNodeWinBattle;
        _nextNodeLose = nextNodeLoseBattle;
        hplayer = 102;
        hpenemy = 102;
        enemyName.text = enemy.NameText;
        sliderPlayer.maxValue = 102;
        sliderEnemy.maxValue = 102;
        sliderTimer.maxValue = MaxTime;
        _james = James;
        if (James)
        { 
            frasesGuardiaEnemy  = frasesGuardiaJames; 
            frasesGolpeEnemy = frasesGolpeJames  ;
            frasesPatadaEnemy   = frasesPatadaJames ;
        }
        else
        {
            frasesGuardiaEnemy  = frasesGuardiaRyusuke; 
            frasesGolpeEnemy = frasesGolpeRyusuke  ;
            frasesPatadaEnemy   = frasesPatadaRyusuke ;
        }
        ChangeMaxTimeFromFlowchart(MaxTimeToAnswer);
        SetHealhBar();
        BucleConversationStart();
    }

    public void BucleConversationStart()
    {
        _decisionEnemy = Random.Range(0, 3);
        restTime = true;
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
        _nextNodeWin = "";
        gameObject.SetActive(false);
    }


    public void SetConversation(AttackType attack, string frase)
    {
        string txt = _enemy.NameText + ":" + frase;
        
        //flowchartCombat.GetVariable<StringVariable>("Conversation").Value = $"Reinhard Mittermeyer reinhard_test: Holi";
        flowchartCombat.GetVariable<StringVariable>("Conversation").Value = txt;
        if (flowchartCombat.SelectedBlock.name != "EnemyText")
        {
            flowchartCombat.ExecuteBlock("EnemyText");
            SetAnswers();
        }
            
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

    public void ChangeMaxTimeFromFlowchart(float t)
    {
        sliderTimer.maxValue = t;
        MaxTime = t;
        sliderTimer.value = MaxTime;
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
                PlayerAnswer(Random.Range(0, 3));
                _elapsedTime = 0;
                //restTime = false;
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
                    hpenemy -= 34;
                }

                if (enemyAttack == AttackType.Patada)
                {
                    hplayer -= 34;
                }
                break;
            case AttackType.Golpe:

                if (enemyAttack == AttackType.Guardia)
                {
                    hplayer -= 34;
                }

                if (enemyAttack == AttackType.Golpe)
                {
                    //nada
                }

                if (enemyAttack == AttackType.Patada)
                {
                    hpenemy -= 34;
                }
                break;
            case AttackType.Patada:

                if (enemyAttack == AttackType.Guardia)
                {
                    hpenemy -= 34;
                }

                if (enemyAttack == AttackType.Golpe)
                {
                    hplayer -= -34;
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
                //ResetCombat();
                PlayerLose();
            }
        }
    }

    public void PlayerWin()
    {
        FlowChartManager.Instance.CallBlock(_nextNodeWin);
        DesactivatePuzle();
    }

    public void PlayerLose()
    {
        FlowChartManager.Instance.CallBlock(_nextNodeLose);
        DesactivatePuzle();
    }
    public void ResetCombat()
    {
        ActivatePuzzle(_enemy,_nextNodeWin,_nextNodeLose,_james,MaxTime);
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
