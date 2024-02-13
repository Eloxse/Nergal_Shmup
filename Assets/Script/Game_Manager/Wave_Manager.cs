using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Manager : MonoBehaviour
{
    public float timeAfterAllSpawn = 180f;
    public float timeBetweenLineMin, timeBetweenLineMax;
    public float spawnIntervalMin, spawnIntrevalMax;
    public int nbSpawnEnemyMax, nbSpawnEnemyMin;
    public static bool gameIsPaused = false;

    public AudioSource gameOverSound;
    public GameObject enemy;
    public GameObject gameOverUI;

    public void Start(){
        StartCoroutine(TimeBetweenSpawn());
    }

    IEnumerator SpawnEnemy(){
        GameObject newEnemyLeft = Instantiate(enemy);
        newEnemyLeft.transform.position = new Vector3(50, transform.position.y, 200);
        yield return new WaitForSeconds(Random.Range(timeBetweenLineMin, timeBetweenLineMax));
        GameObject newEnemyRight = Instantiate(enemy);
        newEnemyRight.transform.position = new Vector3(-50, transform.position.y, 200);
        StartCoroutine(AllEnemiesAsSpawned());
    }
    //Faire spawn deux lignes d'ennemis
    //Les deux lignes d'ennemis ne spawn pas en meme temps

    IEnumerator TimeBetweenSpawn(){
        for(int i = 0; i < Random.Range(nbSpawnEnemyMin, nbSpawnEnemyMax); i++){
            StartCoroutine(SpawnEnemy());
            yield return new WaitForSeconds(Random.Range(spawnIntervalMin, spawnIntrevalMax));
        }
    }
    //Faire spawn aleatoirement le nombre d'ennemis, a un interval aleatoire

    public IEnumerator AllEnemiesAsSpawned(){
        yield return new WaitForSeconds(timeAfterAllSpawn);
        gameOverSound.Play();
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    //Game Over si tous les ennemis ont spawn et que le player les a pas tués
}