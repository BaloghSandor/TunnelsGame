using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_test : MonoBehaviour
{
    private float Trigger = -1.0f;
    public Transform player;
    private UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.C))
        {
            Trigger = Trigger * -1.0f;
        }
        if (Trigger == 1.0f)
        {
            agent.destination = player.position; 
        }
    }
}
