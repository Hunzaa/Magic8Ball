using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public static bool isGameOver;

    void Start()
    {
        isGameOver = false;
        Invoke("GameOver", 2.0f);   
    }

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("Timer!! Showing Interstitial AD");
    }
}
