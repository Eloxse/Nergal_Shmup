using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float range = 5;
    public float attractionForce;

    public LayerMask layerToAttract;

    private Collider[] colsToAttract = new Collider[300];

    public void FixedUpdate()
    {
        Attract();
    }

    public void Attract(){
        Physics.OverlapSphereNonAlloc(transform.position, range, colsToAttract, layerToAttract);
        //overlaspherenonalloc se limite a la taillle du tableau / nonalloc va au dela du tableau

        if(colsToAttract == null) return;

        for(int i = 0; i < colsToAttract.Length; i++){
            if(colsToAttract[i] == null) continue;
            //verifie que les colliders des spieces sont bien presentes

            float distance = Vector3.Distance(colsToAttract[i].transform.position, transform.position);
            distance = Mathf.Clamp(distance, 0, range);

            Vector3 force = ((transform.position - colsToAttract[i].transform.position).normalized * (range - distance) / range) * attractionForce;
            //partie 1 c'est le vecteur. partie 2 calcule la range. Partie 3 calcule la puissance du magnet

            colsToAttract[i].GetComponent<Rigidbody>().AddForce(force);
        }
    }
    //permet au vaisseau d'attirer les pieces comme un aimant
}