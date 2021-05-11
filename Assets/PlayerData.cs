using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//PlayerData change it to GameData
public class PlayerData : MonoBehaviour
{
    public int attempts;

    public PlayerData(Magic8Ball magic8ball)
    {
        attempts = magic8ball.attempts;
    }
}
