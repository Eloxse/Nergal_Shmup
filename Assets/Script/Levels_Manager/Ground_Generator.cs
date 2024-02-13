using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Generator : MonoBehaviour
{
    public List<GameObject> grounds;

    public void Start(){
        ChooseGround(new Vector3(0, 0, 0));
    }

    public void ChooseGround(Vector3 spawnPosition){
        int groundID = Random.Range(0, grounds.Count);
        GameObject.Instantiate(grounds[groundID], spawnPosition, Quaternion.identity);
    }
    //Choisir aleatoirement un sol quand il spawn
}