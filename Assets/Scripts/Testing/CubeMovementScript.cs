using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovementScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0.001f,0f,0f);
    }
}
