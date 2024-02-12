using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    // Update is called once per frame
    void Start()
    {
        if (GameObject.Find("Player").GetComponent<PlayerEnemyCollide>().isAlive == false)
        {
            GameObject.Find("GameOver").SetActive(true);
        }
    }
}
