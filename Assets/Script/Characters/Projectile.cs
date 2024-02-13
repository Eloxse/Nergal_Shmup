using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int projectileDamages = 0;

    public ProjectileType projectileType;
    public enum ProjectileType{
        EnemyHit,
        PlayerHit
    }

    public void OnTriggerEnter(Collider other){
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy") && projectileType == ProjectileType.EnemyHit){
            other.GetComponent<Health_Controller>().RemoveLifeEnemy(projectileDamages);
            Destroy(gameObject);
        }        
        if(other.gameObject.layer == LayerMask.NameToLayer("Player") && projectileType == ProjectileType.PlayerHit){
            other.GetComponent<Health_Controller>().RemoveLifePlayer(projectileDamages);
            Destroy(gameObject);
        }
    }
}