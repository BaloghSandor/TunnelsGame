using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator_script : MonoBehaviour
{
    public bool gen_failure = false;
    public bool launch_new_coroutine = true;
    public int min_time = 60;
    public int max_time = 60;

    public Demo_Drop_off_script demo_level;

    // Update is called once per frame
    void Update()
    {
        if(!demo_level.first_demo_level_finished)
        {
            if (launch_new_coroutine)
            {
                StartCoroutine(GeneratorFailTimer(Random.Range(min_time, max_time)));
            }
        }else{
            gen_failure = false;
        }
    }

    IEnumerator GeneratorFailTimer(int time_until_failure)
    {
        launch_new_coroutine = false;

        yield return new WaitForSeconds(time_until_failure);

        gen_failure = true;
    }
}
