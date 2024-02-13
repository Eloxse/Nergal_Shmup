using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Controller : MonoBehaviour
{
    public int health;
    public int nbCoinMax, nbCoinMin;
    public int probBonusMax = 2;
    public float removeLifeCoolDown = 1f;
    public float timeOfShield = 5f;
    public float timeOfBomb = 1f;
    public static bool gameIsPaused = false;

    public AudioSource gameOverSound;
    public AudioSource deathEnemySound;
    public AudioSource losedLifeSound;
    public GameObject bombDamageArea;
    public GameObject coin;
    public GameObject gameOverUI;
    public GameObject shieldOnPlayer;
    public GameObject[] powerUp;

    private int _currentHealth;
    private float _currentCoolDown = 0;
    private float _timeBeforeLoad = 0.2f;
    private static bool _asShield = false;

    private GameManager _gm;

    public void Start(){
        _currentHealth = health;
        _gm = GameManager.instance;
    }

    public void Update(){
        if(_currentCoolDown > 0){
            _currentCoolDown -= Time.deltaTime;
        }
        //faire un cool down pour ne pas prendre de degat, apres avoir pris -1 de degat
    }

    public void RemoveLifeEnemy(int damageEnemy){
        if(_currentCoolDown > 0) return;
        //si le cooldown est egale ou inferieur a zero, le reste de la fonction ne s'exectue pas
        _currentCoolDown = removeLifeCoolDown;
        //reinitialise le cooldown
        _currentHealth -= damageEnemy;
        if(_currentHealth <= 0){
            DeathEnemy();
        }
    }

    public void DeathEnemy(){
        if(coin){
            int nbCoinRand = Random.Range(nbCoinMin, nbCoinMax);
            for(int i = 0; i < nbCoinRand; i++){
                Instantiate(coin, transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity);
            }
        }
        if(powerUp.Length > 0){
            if(Random.Range(0, probBonusMax) == 0){
                Instantiate(powerUp[Random.Range(0, powerUp.Length)], transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity);
            }
        }
        StartCoroutine(DelayBeforeDeathEnemy());
    }

    IEnumerator DelayBeforeDeathEnemy(){
        deathEnemySound.Play();
        yield return new WaitForSeconds(_timeBeforeLoad);
        Destroy(gameObject);
        _gm.AddKill();
        _gm.Win();
    }
    //Faire un delai avant le destroy de l'ennemis pour que le son de la mort puisse etre entendu

    public void RemoveLifePlayer(int damagePlayer){
        if(_asShield == false){
            if(_currentCoolDown > 0) return;
            _currentCoolDown = removeLifeCoolDown;
            _currentHealth -= damagePlayer;
            losedLifeSound.Play();
            if(_currentHealth <= 0){
                DeathPlayer();
            }
        }else{
            StartCoroutine(TimeForActivedShield());
            //lorsque _asShield est vrai, le player ne prend pas de degats
        }
    }
    //Enlever de la vie au player

    public void DeathPlayer(){
        gameOverSound.Play();
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    //Afficher le game over une fois que le player est mort + freeze game

    public void ActiveShield(){
        shieldOnPlayer.SetActive(true);
        _asShield = true;
    }
    //Activer le shield sur le player

    IEnumerator TimeForActivedShield(){
        yield return new WaitForSeconds(timeOfShield);
        shieldOnPlayer.SetActive(false);
        _asShield = false;
    }
    //Duree de l'activation du shield

    public void ActiveDamageArea(){
        bombDamageArea.SetActive(true);
        StartCoroutine(TimeForActiveDamageArea());
    }
    //Activer la zone de degat quand le joeur prend le power up bomb

    IEnumerator TimeForActiveDamageArea(){
        yield return new WaitForSeconds(timeOfBomb);
        bombDamageArea.SetActive(false);
    }
    //Duree de la bombe
}