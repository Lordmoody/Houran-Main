using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;

public class TextController : MonoBehaviour
{

    public static Sprite WordSprite;
    public GameObject WordPanel;
    public Text WordMaintxt ,  translationtxt;
    public Image WordImage;
    public TreeSpeechController treeSpeech;

    //json
    public TextAsset textJasoneng;
    public static int i = 0;
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
    public GameObject Blocker;

    
    // Start is called before the first frame update

    void Awake(){
        gamePath = Application.dataPath + "/Resources";
        //set the downloadfile to game path
      //  var dlpath = new DownloadHandlerFile(gamePath);
       textJasoneng = Resources.Load<TextAsset>("JSONTree");
         myPlayerList = JsonUtility.FromJson<PlayerList>(textJasoneng.text);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if(LangController.Lang == "Eng"){
            WordMaintxt.text = myPlayerList.player[i].name;
            translationtxt.text = myPlayerList.player[i].trans;
            WordImage.sprite = WordSprite;
            treeSpeech.Setup("en_US");
        }
        else if(LangController.Lang == "Fa"){
            WordMaintxt.text = myPlayerList.player[i].trans;
            translationtxt.text = myPlayerList.player[i].name;
            WordImage.sprite = WordSprite;
            treeSpeech.Setup("fa_IR");
        }
        else if(LangController.Lang == "Spa"){
            WordMaintxt.text = myPlayerList.player[i].fr;
            translationtxt.text = myPlayerList.player[i].trans;
            WordImage.sprite = WordSprite;
            treeSpeech.Setup("fr_FR");
        }*/
        
    }

    public void ShowWord(){
        if(LangController.Lang == "Eng"){
            WordMaintxt.text = myPlayerList.player[i].name;
            translationtxt.text = myPlayerList.player[i].trans;
            WordImage.sprite = WordSprite;
            treeSpeech.Setup("en_US");
        }
        else if(LangController.Lang == "Fa"){
            WordMaintxt.text = myPlayerList.player[i].trans;
            translationtxt.text = myPlayerList.player[i].name;
            WordImage.sprite = WordSprite;
            treeSpeech.Setup("fa_IR");
        }
        else if(LangController.Lang == "Fr"){
            WordMaintxt.text = myPlayerList.player[i].fr;
            translationtxt.text = myPlayerList.player[i].trans;
            WordImage.sprite = WordSprite;
            treeSpeech.Setup("fr_FR");
        }
    }

    public void PlaySound(){
        if(LangController.Lang == "Eng"){
            treeSpeech.Setup("en_US");
            treeSpeech.StartSpeaking(myPlayerList.player[i].name);
        }
        else if(LangController.Lang == "Fr"){
            treeSpeech.Setup("fr_FR");
            treeSpeech.StartSpeaking(myPlayerList.player[i].fr);
        }
    }
    public void closeWordPanel(){
        Blocker.SetActive(false);
        pan.pann = true;
        WordPanel.SetActive(false);
    }
}
