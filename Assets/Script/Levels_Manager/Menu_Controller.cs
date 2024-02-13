using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Controller : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public AudioSource btn_Clic;
    public GameObject resumeUI;

    private float _timeBeforeLoad = 0.3f;

    IEnumerator DelayBeforeLoadPlay(){
        btn_Clic.Play();
        yield return new WaitForSeconds(_timeBeforeLoad);
        SceneManager.LoadScene("Level_One", LoadSceneMode.Single);
    }
    //Permettre de jouer le son du boutton avant le chargement d'une scene

    public void LoadPLay(){
        StartCoroutine(DelayBeforeLoadPlay());
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    //Bouton Play

    IEnumerator DelayBeforeLoadLevelSelection(){
        btn_Clic.Play();
        yield return new WaitForSeconds(_timeBeforeLoad);
        SceneManager.LoadScene("Level_Selection", LoadSceneMode.Single);
    }

    public void LoadLevelSelection(){
        StartCoroutine(DelayBeforeLoadLevelSelection());
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    //Bouton Level Selection

    IEnumerator DelayBeforeExit(){
        btn_Clic.Play();
        yield return new WaitForSeconds(_timeBeforeLoad);
        Application.Quit();
    }

    public void ExitGame(){
        Debug.Log("Exit game");
        StartCoroutine(DelayBeforeExit());
    }
    //Quitter le jeu, fonctionne uniquement dans l'exe

    IEnumerator DelayBeforeLoadLevelTwo(){
        btn_Clic.Play();
        yield return new WaitForSeconds(_timeBeforeLoad);
        SceneManager.LoadScene("Level_Two", LoadSceneMode.Single);
    }

    public void LoadLevelTwo(){
        StartCoroutine(DelayBeforeLoadLevelTwo());
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    //Chargement du Level 2

    IEnumerator DelayBeforeLoadLevelThree(){
        btn_Clic.Play();
        yield return new WaitForSeconds(_timeBeforeLoad);
        SceneManager.LoadScene("Level_Three", LoadSceneMode.Single);
    }

    public void LoadLevelThree(){
        StartCoroutine(DelayBeforeLoadLevelThree());
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    //Chargement du level 3

    IEnumerator DelayBeforeLoadMenu(){
        btn_Clic.Play();
        yield return new WaitForSeconds(_timeBeforeLoad);
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void LoadMenu(){
        StartCoroutine(DelayBeforeLoadMenu());
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    //Chargement du menu

    public void Resume(){
        resumeUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    //Annule le freeze du jeu 
}