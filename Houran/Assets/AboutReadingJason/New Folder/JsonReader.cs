using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;


public class JsonReader : MonoBehaviour
{
    public TextAsset textJason;
    public Text names;
    [System.Serializable]
    public class Player{
        public string name;
        public int health;
        public int mana;
    }

    [System.Serializable]
    public class PlayerList{
        public Player[] player;
    }

    public PlayerList myPlayerList = new PlayerList();
    // Start is called before the first frame update
    void Start()
    {
        myPlayerList = JsonUtility.FromJson<PlayerList>(textJason.text);
       names.text = myPlayerList.player[0].name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
