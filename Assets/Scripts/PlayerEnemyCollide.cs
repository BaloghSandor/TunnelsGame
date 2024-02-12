using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyCollide : MonoBehaviour
{
    static bool isAlive = true;
    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Ennemy")
        {
            isAlive = false;
        }
    }
}
