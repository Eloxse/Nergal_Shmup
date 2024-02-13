using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    public int bulletDamages;
    public int powerUpFireRateCoef = 2;
    public float powerUpFireRateTimer = 3;
    public float baseFireRate = 0.3f;
    public float speedBullet = 10;

    public AudioSource shootPlayerSound;
    public GameObject bullet;
    public Transform[] bulletSpawners;

    private float _currentFireRate;

    void Start(){
        _currentFireRate = baseFireRate;

        for(int i = 0; i < bulletSpawners.Length; i++){
            StartCoroutine(Shoot(i));
        }
    }

    IEnumerator Shoot(int weaponID){
        while(true){
            GameObject newBullet = Instantiate(bullet, bulletSpawners[weaponID].position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * speedBullet;
            newBullet.GetComponent<Projectile>().projectileDamages = bulletDamages;
            newBullet.GetComponent<Projectile>().projectileType = Projectile.ProjectileType.EnemyHit;
            Destroy(newBullet, 2f);
            shootPlayerSound.Play();
            yield return new WaitForSeconds(_currentFireRate);
        }
    }

    public IEnumerator UpgradeFireRate(){
        StopCoroutine(UpgradeFireRate());
        _currentFireRate = _currentFireRate/powerUpFireRateCoef;
        yield return new WaitForSeconds(powerUpFireRateTimer);
        _currentFireRate = baseFireRate;
    }
    //Power_up augmenter le fire rate
}
