using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator_script : MonoBehaviour
{
    public bool gen_failure = false;
    public bool launch_new_coroutine = true;
    public int min_time = 60;
    public int max_time = 60;

    public First_Demo_Level_Doors_script demo_level;

    // Update is called once per frame
    void Update()
    {
        if(demo_level.Demo_level_one)
        {
            if (launch_new_coroutine)
            {
                StartCoroutine(GeneratorFailTimer(Random.Range(min_time, max_time)));
            }
        }else{
            gen_failure = false;
            launch_new_coroutine = false;
            StopCoroutine("GeneratorFailTimer");
        }
    }

    IEnumerator GeneratorFailTimer(int time_until_failure)
    {
        launch_new_coroutine = false;

        yield return new WaitForSeconds(time_until_failure);

        gen_failure = true;
    }
}
