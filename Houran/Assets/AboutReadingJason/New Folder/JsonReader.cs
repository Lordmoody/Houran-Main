using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityPersianSupport;
using UnityEngine.Networking;


public class JsonReader : MonoBehaviour
{
    public TextAsset textJasoneng;
    public Image flag;
   // public TextAsset textJasonSp;
    public Text names;
    
    int i = 0 , j = 0;
     int lenghtar;
    public string[] texts;
    public string gamePath;
  
    [System.Serializable]
    public class Player{
        public string name;
    }

    [System.Serializable]
    public class PlayerList{
        public Player[] player;
    }
    
    public PlayerList myPlayerList = new PlayerList();
  

    void Awake(){
        gamePath = Application.dataPath + "/Resources";
        //set the downloadfile to game path
      //  var dlpath = new DownloadHandlerFile(gamePath);
       textJasoneng = Resources.Load<TextAsset>("JASONtext");
         myPlayerList = JsonUtility.FromJson<PlayerList>(textJasoneng.text);
       names.text = myPlayerList.player[0].name;
       //lenghtar = myPlayerList.player.Length;
       
    }
    // Start is called before the first frame update
    void Start()
    {
        flag.sprite = Resources.Load<Sprite>("flags/eng");
       texts = new string[myPlayerList.player.Length];
       for(j = 0 ; j < myPlayerList.player.Length ; j++){
           texts[j] = myPlayerList.player[j].name;
       }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextText(){
        i += 1;
        names.text =  texts[i];
    }

    public void changeLanguageSpanish(){
        flag.sprite = Resources.Load<Sprite>("flags/spa");
         textJasoneng = Resources.Load<TextAsset>("JASONtext2");
        myPlayerList = JsonUtility.FromJson<PlayerList>(textJasoneng.text);
        names.text = myPlayerList.player[i].name;
        texts = new string[myPlayerList.player.Length];
        for(j = 0 ; j < myPlayerList.player.Length ; j++){
           texts[j] = myPlayerList.player[j].name;
       }
    }

    public void changeLanguagePersian(){
        flag.sprite = Resources.Load<Sprite>("flags/per");
        textJasoneng = Resources.Load<TextAsset>("JASONtext1");
        myPlayerList = JsonUtility.FromJson<PlayerList>(textJasoneng.text);
        names.text = myPlayerList.player[i].name;
        texts = new string[myPlayerList.player.Length];
        for(j = 0 ; j < myPlayerList.player.Length ; j++){
           texts[j] = myPlayerList.player[j].name;
       }
    }
}
