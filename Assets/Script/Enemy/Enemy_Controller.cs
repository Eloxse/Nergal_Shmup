using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public float amplitudeWave = 2;
    public float waveFrequency = 2;
    public float moveSpeed = 10;
    public float timeBeforeDestroy = -2;
    
    private float sinCenterX;

    public void Start(){
        sinCenterX = transform.position.x;
    }

    public void FixedUpdate(){
        Movement();
    }

    public void Movement(){
        Vector3 position = transform.position;
        position.z -= moveSpeed * Time.fixedDeltaTime;
        transform.position = position;
        if(position.z < timeBeforeDestroy){
            Destroy(gameObject);
        }
        MovementSin();
    }
    //Deplacement vers l'avant de l'ennemis

    public void MovementSin(){
        Vector3 position = transform.position;
        float sinMove = Mathf.Sin(position.z * waveFrequency) * amplitudeWave;
        position.x = sinCenterX + sinMove;
        transform.position = position;
    }
    //Deplacement en vague
}