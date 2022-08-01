using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityPersianSupport;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class managertree : MonoBehaviour
{
    public static string BaseLang , DestLang;
    public static string[] desttexts , basetexts;
    public static string readThis;
    public GameObject cancas1 , canvas2;
    public GameObject movetree;
    
    public GameObject langmenu;
    public GameObject flashjump , closeb , menutree;
    public Image Flashcartimg;
    public Text Originlang , EngLang;
    public AudioSource voices; 
    public GameObject playButtons;
    int pb = 0;
    //localization
    public TextAsset textJasoneng;
    public SpeechController speechController;
    public SpeechControllerVoiceBase speechCVB;
    public TextAsset textJasonOth;
    int lenghtar;
    int i = 0 , j = 0 , s = 0;
    public string gamePath;
     ///eng
  
    [System.Serializable]
    public class Player{
        public string name;
    }

    [System.Serializable]
    public class PlayerList{
        public Player[] player;
    }
    
    public PlayerList myPlayerList = new PlayerList();
     ///
     ///origin
    [System.Serializable]
    public class Original{
        public string name;
    }

    [System.Serializable]
    public class OriginalList{
        public Original[] player;
    }
    
    public OriginalList OriginList = new OriginalList();
        ///

    
    //
    GameObject thisone , alsothis;
    // Start is called before the first frame update
    void Awake(){
        gamePath = Application.dataPath + "/Resources";
        //set the downloadfile to game path
      //  var dlpath = new DownloadHandlerFile(gamePath);
       textJasoneng = Resources.Load<TextAsset>("JASONtext");
       textJasonOth = Resources.Load<TextAsset>("JsonPer");
         myPlayerList = JsonUtility.FromJson<PlayerList>(textJasoneng.text);
         OriginList = JsonUtility.FromJson<OriginalList>(textJasonOth.text);
         BaseLang = "Persian";
         DestLang = "English";
         desttexts = new string[myPlayerList.player.Length];
         for(i = 0; i < 4 ; i++){
             desttexts[i] = myPlayerList.player[i].name;
         }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void movements(){
        cancas1.SetActive(false);
        canvas2.SetActive(true);
        movetree.SetActive(true);
        alsothis = movetree;
        pan.pann = false;
    }
    public void showjumpf(){
        Flashcartimg.sprite = Resources.Load<Sprite>("flash/jump");
        EngLang.text = myPlayerList.player[0].name;
        Originlang.text = OriginList.player[0].name;
        flashjump.SetActive(true);
        pb = 0;
        playButtons.SetActive(true);
        readThis = desttexts[0];
       // voices.clip = Resources.Load<AudioClip>("voices/Jump");
        closeb.SetActive(true);
        thisone = flashjump;
    }
    public void showwalkf(){
        Flashcartimg.sprite = Resources.Load<Sprite>("flash/walk");
        EngLang.text = myPlayerList.player[1].name;
        Originlang.text = OriginList.player[1].name;
        flashjump.SetActive(true);
        pb = 1;
        playButtons.SetActive(true);
        readThis = desttexts[1];
       // voices.clip = Resources.Load<AudioClip>("voices/Walk");
        closeb.SetActive(true);
        thisone = flashjump;
    }
    public void showsitf(){
        Flashcartimg.sprite = Resources.Load<Sprite>("flash/sitdown");
        EngLang.text = myPlayerList.player[2].name;
        Originlang.text = OriginList.player[2].name;
        flashjump.SetActive(true);
        pb = 2;
        playButtons.SetActive(true);
        readThis = desttexts[2];
      //  voices.clip = Resources.Load<AudioClip>("voices/Sitdown");
        closeb.SetActive(true);
        thisone = flashjump;
    }
    public void showrunf(){
        Flashcartimg.sprite = Resources.Load<Sprite>("flash/run");
        EngLang.text = myPlayerList.player[3].name;
        Originlang.text = OriginList.player[3].name;
        flashjump.SetActive(true);
        pb = 3;
        playButtons.SetActive(true);
        readThis = desttexts[3];
       // voices.clip = Resources.Load<AudioClip>("voices/Run");
        closeb.SetActive(true);
        thisone = flashjump;
    }
    public void closebutton(){
        closeb.SetActive(false);
        playButtons.SetActive(false);
        thisone.SetActive(false);
    }
    public void play(){

        voices.Play();
    }
    public void activemenu(){
        menutree.SetActive(true);
        pan.pann = false;
    }
    public void closemenutree(){
        menutree.SetActive(false);
        pan.pann = true;
    }
    public void GoToGame(){
        pan.pann = true;
        SceneManager.LoadScene("PlatformerL1");
    }
    public void ExitTheGame(){
        Application.Quit();
    }
    public void returntree(){
        canvas2.SetActive(false);
        cancas1.SetActive(true);
        alsothis.SetActive(false);
        pan.pann = true;
    }

    public void OpenLangMenu(){
        langmenu.SetActive(true);
        menutree.SetActive(false);
    }

    public void retunToMenu(){
        langmenu.SetActive(false);
        menutree.SetActive(true);
    }
    

    public void DropDownItemSelectOrigin(Dropdown dropdown){
        if(dropdown.value == 0){
            BaseLang = "Persian";
            textJasonOth = Resources.Load<TextAsset>("JsonPer");
            OriginList = JsonUtility.FromJson<OriginalList>(textJasonOth.text);
        }
        else if(dropdown.value == 1){
            BaseLang = "English";
            textJasonOth = Resources.Load<TextAsset>("JASONtext");
            OriginList = JsonUtility.FromJson<OriginalList>(textJasonOth.text);
        }
        else if(dropdown.value == 2){
            BaseLang = "Spanish";
            textJasonOth = Resources.Load<TextAsset>("JsonSpa");
            OriginList = JsonUtility.FromJson<OriginalList>(textJasonOth.text);
        }
    }
    public void DropDownItemSelectDestination(Dropdown dropdown){
        if(dropdown.value == 0){
            DestLang = "English";
            SpeechController.LANG_CODE = "en_US";
            speechController.Setup(SpeechController.LANG_CODE);
            SpeechControllerVoiceBase.LANG_CODE = "en_US";
            speechCVB.Setup(SpeechControllerVoiceBase.LANG_CODE);
            textJasoneng = Resources.Load<TextAsset>("JASONtext");
            myPlayerList = JsonUtility.FromJson<PlayerList>(textJasoneng.text);
            for(i = 0; i < 4 ; i++){
             desttexts[i] = myPlayerList.player[i].name;
         }
        }
        else if(dropdown.value == 1){
            DestLang = "Persian";
            SpeechController.LANG_CODE = "fa_IR";
            speechController.Setup(SpeechController.LANG_CODE);
            SpeechControllerVoiceBase.LANG_CODE = "fa_IR";
            speechCVB.Setup(SpeechControllerVoiceBase.LANG_CODE);
            textJasoneng = Resources.Load<TextAsset>("JsonPer");
            myPlayerList = JsonUtility.FromJson<PlayerList>(textJasoneng.text);
            for(i = 0; i < 4 ; i++){
             desttexts[i] = myPlayerList.player[i].name;
         }
        }
        else if(dropdown.value == 2){
            DestLang = "Spanish";
            SpeechController.LANG_CODE = "es_ES";
            speechController.Setup(SpeechController.LANG_CODE);
            SpeechControllerVoiceBase.LANG_CODE = "es_ES";
            speechCVB.Setup(SpeechControllerVoiceBase.LANG_CODE);
            textJasoneng = Resources.Load<TextAsset>("JsonSpa");
            myPlayerList = JsonUtility.FromJson<PlayerList>(textJasoneng.text);
            for(i = 0; i < 4 ; i++){
             desttexts[i] = myPlayerList.player[i].name;
         }
        }
    }
}
