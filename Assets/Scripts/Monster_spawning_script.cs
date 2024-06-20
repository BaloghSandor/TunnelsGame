using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_spawning_script : MonoBehaviour
{
    private int idle_position_x = 65;
    private int idle_position_z = 42;

    private int position_x_1 = 48;
    private int position_z_1 = 45;

    private int position_x_2 = 96;
    private int position_z_2 = 12;

    private int position_x_3 = 96;
    private int position_z_3 = -12;
    
    public int min_spawn_time = 1;
    public int max_spawn_time = 26;

    private int spawn_location = 0;

    public int monster_speed = -4;

    private float step;

    public bool launch_spawn_timer = true;
    public bool monster_spawn = false;
    private bool monster_engaging = false;

    public First_Demo_Level_Doors_script demo_level;

    private bool interaction = false;

    public GameObject SecurityDoor1;
    public GameObject SecurityDoor2;
    public GameObject SecurityDoor3;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == SecurityDoor1 || collision.gameObject == SecurityDoor2 || collision.gameObject == SecurityDoor3)
        {
            interaction = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == SecurityDoor1 || collision.gameObject == SecurityDoor2 || collision.gameObject == SecurityDoor3)
        {
            interaction = false;
        }
    }  

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(idle_position_x, 0, idle_position_z);
        step = monster_speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(demo_level.Second_level)
        {
            if(launch_spawn_timer)
            {
                StartCoroutine(MonsterSpawnTimer(Random.Range(min_spawn_time, max_spawn_time)));
            }

            if(interaction)
            {
                monster_spawn = false;
            }

            if(monster_spawn && spawn_location == 0)
            {
                int random_number = Random.Range(1, 4);
                Debug.Log(random_number);
                spawn_location = random_number;
            }
            
            if(!monster_spawn)
            {
                monster_engaging = false;
                launch_spawn_timer = true;
                spawn_location = 0;
            }

            if(spawn_location == 0)
            {
                gameObject.transform.position = new Vector3(idle_position_x, 5, idle_position_z);
            }
            else if(spawn_location == 1 && !monster_engaging)
            {
                gameObject.transform.position = new Vector3(position_x_1, 5, position_z_1);
                monster_engaging = true;
            }
            else if(spawn_location == 2 && !monster_engaging)
            {
                gameObject.transform.position = new Vector3(position_x_2, 5, position_z_2);
                monster_engaging = true;
            }
            else if(spawn_location == 3 && !monster_engaging)
            {
                gameObject.transform.position = new Vector3(position_x_3, 5, position_z_3);
                monster_engaging = true;
            }
        }
    }

    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if(monster_engaging)
        {
            if(spawn_location == 1)
            {
                rb.velocity = new Vector3(0, 0, monster_speed);
            }else if(spawn_location == 2 || spawn_location == 3)
            {
                rb.velocity = new Vector3(monster_speed, 0, 0);
            }
        }
        else{
            rb.velocity = new Vector3(0,0,0);
        }
    }

    IEnumerator MonsterSpawnTimer(int time_until_spawn)
    {
        launch_spawn_timer = false;

        yield return new WaitForSeconds(time_until_spawn);

        monster_spawn = true;
    }
}
