using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerDatas
{
    public float[] position;
    public float PlayerHealth;
    public int PlayerLevel;
    public bool[] MissionsDone;
    public string[] wordsTillNow;
    public string LangCode;
    public bool FirstTime;
    public int LevelEnvNum;


    public PlayerDatas (NewPlayerMovementP player){
        PlayerHealth = player.healthInstance.healthPlayer;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        LevelEnvNum = LevelEnvController.LevelNumber;

        PlayerLevel = player.Lvlsave;
        LangCode = player.langCodeSave;
        FirstTime = false;


        wordsTillNow = new string[player.itemControllerInstance.ItemsCollected.Length];
        for(int i = 0; i < player.itemControllerInstance.ItemsCollected.Length ; i++){
            wordsTillNow[i] = player.itemControllerInstance.ItemsCollected[i];
        }

        MissionsDone = new bool[player.itemControllerInstance.MissionsDone.Length];
        for(int i = 0; i < player.itemControllerInstance.MissionsDone.Length ; i++){
            MissionsDone[i] = player.itemControllerInstance.MissionsDone[i];
        }
    }



}
