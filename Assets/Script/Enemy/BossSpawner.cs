using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private float timeBeforeSpawnBoss = 5f;

    [SerializeField] private Boss_Controller bossPrefab;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Transform limitPos;

    private IEnumerator Start(){
        yield return new WaitForSeconds(timeBeforeSpawnBoss);
        Boss_Controller instance = Instantiate(bossPrefab, spawnPosition.position, spawnPosition.rotation);
        instance.ZLimit = limitPos.position.z;
    }
    //Faire spawn le boss en haut de l'ecran et limiter sa posiiton

    /*
    - Preferable de mettre en [SerializedField] private: accessible dans l'inspector mais pas dans les
      autres scripts
    - public uniquement si l'on veut avoir acces a une donnee dans un autre script
    - Si dans le start il n'y a que la coroutine, on peut directement transfromer le start en coroutine
    */
}