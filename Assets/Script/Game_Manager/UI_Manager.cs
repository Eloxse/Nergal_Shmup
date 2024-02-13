using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public TMP_Text txt_Coins;
    public TMP_Text txt_HighScoreGameOver;
    public TMP_Text txt_HighScoreWin;
    public TMP_Text txt_EnemyKilled;
    public TMP_Text txt_HighKillGameOver;
    public TMP_Text txt_HighKillWin;
    public static UI_Manager instance;

    public void Awake(){
        if(instance != null){
            Destroy(gameObject);
        }
        instance = this;
    }

    public void UpdateCoinText(int nbCoins){
        txt_Coins.text = nbCoins.ToString();
        txt_HighScoreGameOver.text = "High Score :" + nbCoins.ToString();
        txt_HighScoreWin.text = "High Score :" + nbCoins.ToString(); 
    }

    public void UpdateKillText(int killCount){
        txt_EnemyKilled.text = killCount.ToString();
        txt_HighKillGameOver.text = "kill :" + killCount.ToString();
        txt_HighKillWin.text = "kill :" + killCount.ToString();
    }
    //Afficher le nombre d'enemis tués
}