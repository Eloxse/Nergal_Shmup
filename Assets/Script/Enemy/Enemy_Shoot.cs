using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shoot : MonoBehaviour
{
    public int bulletDamages;
    public int timeBeforeBulletDestroy = 2;
    public float fireRate = 1f;
    public float speedBullet = 20f;

    public AudioSource shootEnemySound;
    public GameObject bulletEnemy;
    public Transform[] bulletSpawnersEnemy;

    void Start(){
        for(int i = 0; i < bulletSpawnersEnemy.Length; i++){
            StartCoroutine(ShootPlayer(i));
        }
    }

    IEnumerator ShootPlayer(int weaponID){
        while(true){
            GameObject newBulletEnemy = Instantiate(bulletEnemy, bulletSpawnersEnemy[weaponID].position, Quaternion.identity);
            newBulletEnemy.GetComponent<Rigidbody>().velocity = -transform.forward * speedBullet;
            newBulletEnemy.GetComponent<Projectile>().projectileDamages = bulletDamages;
            newBulletEnemy.GetComponent<Projectile>().projectileType = Projectile.ProjectileType.PlayerHit;
            Destroy(newBulletEnemy, timeBeforeBulletDestroy);
            shootEnemySound.Play();
            yield return new WaitForSeconds(fireRate);
        }
    }
}