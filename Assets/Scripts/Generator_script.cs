using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator_script : MonoBehaviour
{
    public bool gen_failure = false;
    public bool launch_new_coroutine = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GeneratorFailTimer(Random.Range(10, 120)));
    }

    // Update is called once per frame
    void Update()
    {
        if (launch_new_coroutine)
        {
            StartCoroutine(GeneratorFailTimer(Random.Range(10, 120)));
        }
    }

    IEnumerator GeneratorFailTimer(int time_until_failure)
    {
        launch_new_coroutine = false;

        Debug.Log("Waiting Time:" + time_until_failure);

        yield return new WaitForSeconds(time_until_failure);

        gen_failure = true;
    }
}
