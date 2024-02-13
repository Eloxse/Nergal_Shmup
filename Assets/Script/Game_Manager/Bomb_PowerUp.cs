using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_PowerUp : MonoBehaviour
{
    private Health_Controller _hc;

    void Start(){
        _hc = GetComponent<Health_Controller>();
    }

    public void OnTriggerEnter(Collider other){
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy")){
            other.GetComponent<Health_Controller>().DeathEnemy();
        }
    }
    //Detecter les ennemis quand ils entrent dans la zone de degat de la bombet les tuer
    //Recuperer le DeathEnemy pour obtenir les pieces et les power up lorsque l'ennemis meurt
}
