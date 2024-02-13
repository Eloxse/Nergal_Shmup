using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds_Manager : MonoBehaviour
{
    public AudioSource menuAmbianceSound;
    public AudioSource gameAmbianceSound;

    public void Start(){
        menuAmbianceSound.Play();
        gameAmbianceSound.Play();
    }
}