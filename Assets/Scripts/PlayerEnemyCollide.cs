using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyCollide : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Ennemy Collision!");
        }
    }
}
