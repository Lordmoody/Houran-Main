using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveDatasPlayer
{
    public static bool notFound;


    public static void SavePlayer(NewPlayerMovementP player){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.main";
        FileStream stream = new FileStream(path , FileMode.Create);
        PlayerDatas data = new PlayerDatas(player);
        formatter.Serialize(stream , data);
        stream.Close();
    }

    public static PlayerDatas LoadPlayer(){
        string path = Application.persistentDataPath + "/player.main";
        if(File.Exists(path)){
            notFound = false;
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path , FileMode.Open);

            PlayerDatas data = formatter.Deserialize(stream) as PlayerDatas;
            stream.Close();
            return data;
        }
        else{
            Debug.LogError("Save File Not Found In " + path);
            notFound = true;
            return null;
        }
    }

    public static void LoadItToThem(NewPlayerMovementP player){
        PlayerDatas datas = LoadPlayer();
        if(notFound == false){
            Vector3 ForPosition;
            ForPosition.x = datas.position[0];
            ForPosition.y = datas.position[1];
            ForPosition.z = datas.position[2];
            player.transform.position = ForPosition;

            player.healthInstance.healthPlayer = datas.PlayerHealth;

            CoinManager.CurrentLevel = datas.PlayerLevel;

            LangController.Lang = datas.LangCode;

            ControlGuide.FirstTime = datas.FirstTime;

            LevelEnvController.LevelNumber = datas.LevelEnvNum;

            for(int i = 0 ; i < player.itemControllerInstance.ItemsCollected.Length ; i++){
                player.itemControllerInstance.ItemsCollected[i] = datas.wordsTillNow[i];
            }

            for(int i = 0; i < player.itemControllerInstance.AllMissions.Length ; i++){
                player.itemControllerInstance.AllMissions[i].ThisisDone = datas.MissionsDone[i];
                player.itemControllerInstance.MissionsDone[i] = datas.MissionsDone[i];
            }
        }
    }

}
