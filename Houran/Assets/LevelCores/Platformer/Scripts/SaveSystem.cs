using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static bool notFound;
    public static void SavePlayer(PlayerMovementInPlatformer player){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path , FileMode.Create);
        PlayerData data = new PlayerData(player);
        formatter.Serialize(stream , data);
        stream.Close();
    }

    public static PlayerData LoadPlayer(){
        string path = Application.persistentDataPath + "/player.fun";
        if(File.Exists(path)){
            notFound = false;
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path , FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else{
            Debug.LogError("Save File Not Found In " + path);
            notFound = true;
            return null;
        }
    }

}
