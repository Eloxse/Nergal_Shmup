using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalKill = 10;
    public static bool gameIsPaused = false;

    public AudioSource winSound;
    public GameObject resumeUI;
    public GameObject winUI;
    public Player_Controller player;
    public static GameManager instance;

    private int coins;
    private int kills;

    private UI_Manager _ui;

    public void Start(){
        _ui = UI_Manager.instance;

        player = GameObject.Find("Player").GetComponent<Player_Controller>();
    }

    public void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            Resume();
        }
    }
    //Mettre le jeu en pause avec la touche escape

    public void Awake(){
        if(instance != null){
            Destroy(gameObject);
        }

        instance = this;
    }

    public void Resume(){
        resumeUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    //freeze le jeu pendant qu'il est en pause

    public void AddCoins(){
        coins++;
        _ui.UpdateCoinText(coins);
    }

    public void AddKill(){
        kills++;
        _ui.UpdateKillText(kills);
    }
    //Compter le nombre d'ennemis tués

    public void Win(){
        if(kills >= totalKill){
            winUI.SetActive(true);
            winSound.Play();
            Time.timeScale = 0f;
            gameIsPaused = true;
        }
    }
    //Activer la scene you win lorsque 10 ennemis ont été tués
}