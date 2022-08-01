using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestWriting : MonoBehaviour
{
    [System.Serializable]
    public class Player{
        public string name;
    }

    [System.Serializable]
    public class PlayerList{
        public Player[] player;
    }
    
    public PlayerList myPlayerList = new PlayerList();
    public string gamePath;
    public TextAsset textJasoneng;
    public Text reader;
    public Transform thiss , thatt;
    // Start is called before the first frame update
    void Start()
    {
        gamePath = Application.dataPath + "/Resources";
        textJasoneng = Resources.Load<TextAsset>("JASONtext3");
        myPlayerList = JsonUtility.FromJson<PlayerList>(textJasoneng.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void writej(){
        myPlayerList.player[0].name = thiss.ToString();
    }
    public void Readj(){
        reader.text = myPlayerList.player[0].name;
    }   
}
