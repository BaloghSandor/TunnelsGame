using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Collsion : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision!");
    }
}
