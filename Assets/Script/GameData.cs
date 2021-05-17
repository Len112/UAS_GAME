using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData {
    public int level;
    public int playerhealth;
    public int score;
    public float[] position;
    
    public GameData(NewPlayerMovement playerPosition, PlayerHealth healthplayer, ScoreSystem scoregame)
    {
        playerhealth = healthplayer.CurrentHealth;
        score = scoregame.playerScore;

        position = new float[3];
        position[0] = playerPosition.transform.position.x;
        position[1] = playerPosition.transform.position.y;
        position[2] = playerPosition.transform.position.z;
    }
}
