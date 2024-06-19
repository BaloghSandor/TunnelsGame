using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_second_level_script : MonoBehaviour
{
    public bool player_collided = false;
    public GameObject Trigger;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player_collided = true;
        }
    }

    void Update()
    {
        if(player_collided)
        {
            Trigger.transform.gameObject.SetActive(false);
        }
    }
}
