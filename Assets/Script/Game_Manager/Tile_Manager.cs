using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Manager : MonoBehaviour
{
    public float speed = 3f;

    public GameObject tileSpawner;
    public Transform nextTilePosition;

    private GameObject _gm;
    private Rigidbody _rb;

    public void Start(){
        _gm = GameObject.Find("GameManager");
        _rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate(){
        _rb.MovePosition(transform.position - Vector3.forward * Time.deltaTime * speed);

    }
    //Mouvement du sol + vitesse

    public void OnTriggerEnter(Collider other){
        if(other.gameObject.layer == LayerMask.NameToLayer("Player")){
            _gm.GetComponent<Ground_Generator>().ChooseGround(nextTilePosition.position);
            tileSpawner.SetActive(false);
            /*Pour que le collider du spawn du sol ne fonctionne qu'une fois par tile
            Vu que le player est en mouvement, a chaque fois qu'il passait sur le collider
            un sol spawn = surchage inutile de la scene*/
        }
        //Faire spawn le sol

        if(other.gameObject.layer == LayerMask.NameToLayer("Destroy_Tile")){
            Destroy(gameObject);
        }
        //Detruire le sol une fois passé devant la caméra
    }
}