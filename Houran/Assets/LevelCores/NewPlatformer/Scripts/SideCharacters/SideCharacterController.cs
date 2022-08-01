using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCharacterController : MonoBehaviour
{
    public Animator anim , Charanim;
    public GameObject taskIcon;
    public GameObject TskButton;
    public string TskForThis;
    public int CharNum;
    public int ThisChildNum;
    public TaskUIManager taskUIManager;
    public ParticleSystem ForThisChar;
     public bool ThisisDone = false , ThisTskAccepted = false;
    public Sprite[] itemsSprites;
    
    public int thisendnum , EndNumGuide;
    public GameObject ThisTarget;
    public int RequiredLevel;
    public GameObject ErrorPanel;


    //words
    [System.Serializable]
    public class WordClass{
        
        public string name;
        public string trans;
        public string fr;
    }

    [System.Serializable]
    public class WordList{
        public WordClass[] Words;
    }
    public WordList myWordList = new WordList();
    public TextAsset textJsonWords;

    string gamePath;
    public string ThiswordsJson;

    [HideInInspector]public string ENGwords , FRwords;

    ///

    public ItemController itemController;
    public int MissionNumber;

    
    
    // Start is called before the first frame update
    void Start(){
        gamePath = Application.dataPath + "/Resources";
         //set the downloadfile to game path
         //  var dlpath = new DownloadHandlerFile(gamePath);
         textJsonWords = Resources.Load<TextAsset>(ThiswordsJson);
         myWordList = JsonUtility.FromJson<WordList>(textJsonWords.text);
         int n = 0;
         for(int w = 0 ; w < myWordList.Words.Length ; w++){
            if(n < 3){
                ENGwords = ENGwords + "   " + myWordList.Words[w].name;
                FRwords = FRwords + "   " + myWordList.Words[w].fr;
                n += 1;
            }
            else if(n >= 3){
                ENGwords = ENGwords + "\n" + myWordList.Words[w].name;
                FRwords = FRwords + "\n" + myWordList.Words[w].fr;
                n = 0;
            }
             
         }
    }
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
          if(RequiredLevel == CoinManager.CurrentLevel){
            if(ThisisDone == false){
                if(ThisTskAccepted == false){
                 TaskUIManager.EnNumForThis = EndNumGuide;
                 TaskUIManager.GuideToThis = ThisTarget;
               
                 if(Charanim != null){
                       taskUIManager.CharANim = Charanim;
                 }   
                 
                 taskIcon.SetActive(true);
                  TskButton.SetActive(true);
                 anim.SetBool("Open" , true);
                 TaskUIManager.EnteredTsk = TskForThis;
                 TaskUIManager.EnteredChar = this.gameObject;
                  TaskUIManager.CharNumber = CharNum;
                 TaskUIManager.childrenNum = ThisChildNum;
             
                 }
             }
          }
          else if(RequiredLevel > CoinManager.CurrentLevel){
              taskUIManager.ErrorFunc(taskUIManager.myErrorList.Errors[0].txt , RequiredLevel.ToString() + " < " + CoinManager.CurrentLevel.ToString());

          } 
     }
    }
    void OnTriggerExit2D(Collider2D other){
        if(ThisisDone == false){
            if(ThisTskAccepted == false){
            if(other.gameObject.tag == "Player"){
                ErrorPanel.SetActive(false);
            anim.SetBool("Open" , false);
            anim.SetTrigger("Return");
            Invoke("disactive" , 0.5f);
            TskButton.SetActive(false);
            }
        }
        else if(ThisTskAccepted == true){
            if(other.gameObject.tag == "Player"){
                if(taskIcon.activeSelf == true){
                    anim.SetBool("Open" , false);
                    ErrorPanel.SetActive(false);
                    anim.SetTrigger("Return");
                    Invoke("disactive" , 0.5f);
                    TskButton.SetActive(false);
                }
                
            }
        }
        }
        
        
    }

    public void AddToList(){
        itemController.MissionsDone[MissionNumber] = true;
    }
    void disactive(){
        taskIcon.SetActive(false);
       
    }
}
