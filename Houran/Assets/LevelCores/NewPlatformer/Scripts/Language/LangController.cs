using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LangController : MonoBehaviour
{
    public static string Lang = "Eng";
    public GameObject langMenu , MainMenu;
    public TextAsset textJasoneng;
    
    [System.Serializable]
    public class Player{
        public string name;
        public string trans;
        public string fr;
    }

    [System.Serializable]
    public class PlayerList{
        public Player[] player;
    }
    
    public PlayerList myPlayerList = new PlayerList();
    public string gamePath;
    void Awake(){
        gamePath = Application.dataPath + "/Resources";
        //set the downloadfile to game path
      //  var dlpath = new DownloadHandlerFile(gamePath);
       textJasoneng = Resources.Load<TextAsset>("JSONTree");
        myPlayerList = JsonUtility.FromJson<PlayerList>(textJasoneng.text);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLang(string code){
        Lang = code;
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void Close(){
        langMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void Open(){
        langMenu.SetActive(true);
        MainMenu.SetActive(false);
    }
}
