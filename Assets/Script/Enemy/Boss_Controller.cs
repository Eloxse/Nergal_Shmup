using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Controller : MonoBehaviour
{
    public float moveSpeed = 10f;
    [Range(0f, 0.2f)] public float horizontalSpeed = 0.05f;
    //Permet d'afficher dans l'inspector une jauge allant de 0 a la valeur declaree
    public float ZLimit { get; set; }

    private Player_Controller _player;

    public void Start(){
        _player = GameObject.Find("Player").GetComponent<Player_Controller>();
    }

    public void FixedUpdate(){
        Movement();
    }

    private void Movement(){
        Vector3 position = transform.position;

        if(position.z > ZLimit){
            position.z -= moveSpeed * Time.fixedDeltaTime;
        }
        //Mouvement du boss vers le joueur

        position.x = Mathf.Lerp(position.x, _player.transform.position.x, horizontalSpeed);
        //Permet au boss de suivre le mouvement du joueur horizontalement

        transform.position = position;
    }
}
