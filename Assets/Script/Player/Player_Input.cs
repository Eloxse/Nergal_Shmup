using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    public float horizontal, vertical;

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }
}
