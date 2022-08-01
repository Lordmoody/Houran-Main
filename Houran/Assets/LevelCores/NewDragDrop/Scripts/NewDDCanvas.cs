using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class NewDDCanvas : MonoBehaviour
{
    public GameObject Book , bookIcon;
    public Animator bookanim;
    public static int evilScore = 0 , lightScore = 5;
    public static bool win = false , loose = false;
    public Animator global;
    public static float score = 0;
    public Text scoret;
    public Image hourglass;
    bool stopTime = false , stopOff = false;

    int i = 0 , o = 0 , offLength , burntLength , SBurntLength;
    public float TimeBase;
    public GameObject winlooseMenu;
    public Animator endAnim;
    public _2dxFX_BurnFX[] burneffect;
    public string sceneName;


    /// for json reader func
    public TextAsset textJasoneng;
    public string gamePath;
  
    [System.Serializable]
    public class Words{
        public string en;
        public string per;
    }
    [System.Serializable]
    public class Winsent{
        public string sent;
        public string psent;
    }

    [System.Serializable]
    public class WordList{
        public Words[] words;
        public Winsent[] winsent;
    }
    
    public WordList myWordList = new WordList();

    public Text[] BoxWords , CorrectBoxWords , BookWords ;
    public Text sentforEnd;
    public string[] EndSents , WordsToRead; 

    ///
  //  public GameObject[] firstt , secondd;
    // Start is called before the first frame update
    void Awake(){
        ForControllingStatics();
        JsonReaderFunc();
    }
    void Start()
    {
        InvokeRepeating("GuidThem" , 5f , 5f);
        Book.SetActive(true);
        bookanim.SetBool("up" , true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(stopTime == false){
            if(Time.timeSinceLevelLoad <= TimeBase){
            hourglass.fillAmount = 1 - Time.timeSinceLevelLoad / TimeBase;
             }
             else if(Time.timeSinceLevelLoad > TimeBase){
               EndGame();
               Invoke("EndMenu" , 2.5f);
               stopTime = true;
             }

        }
        scoret.text = score.ToString();
        if(lightScore <= 0){
           EndGame();
           Invoke("EndMenu" , 2.5f);
           stopTime = true;
           lightScore = 5;
       }
       
        
    }


    void EndGame(){
        if(evilScore < 3 && score >= 3 || score >=3){
             string otherbox;
             win = true;
             global.SetBool("light" , true);
             bookanim.SetBool("down" , true);
             Invoke("DisBook" , 1.1f);
             if(GameObject.FindGameObjectsWithTag("darkened").Length > 0){
                 for( i =0; i >= evilScore; i++){
                     GameObject.FindGameObjectsWithTag("darkened")[i].GetComponent<Animator>().SetBool("golight" , true);
                 }

             }
             if(GameObject.FindGameObjectsWithTag("off").Length > 0){
                 offLength = GameObject.FindGameObjectsWithTag("off").Length;
                 burntLength = GameObject.FindGameObjectsWithTag("notburnt").Length;
               //  SBurntLength = GameObject.FindGameObjectsWithTag("SNotburnt").Length;
                 for(o = 0; o < offLength ; o++){
                     GameObject.FindGameObjectsWithTag("off")[o].GetComponent<Animator>().SetBool("light" , true);
                 }
                 for(int j = 0; j < burntLength ; j++){
                     GameObject.FindGameObjectsWithTag("notburnt")[j].GetComponent<Animator>().SetBool("notb" , true);
                     otherbox = GameObject.FindGameObjectsWithTag("notburnt")[j].name;
                     GameObject.FindGameObjectWithTag(otherbox).GetComponent<Animator>().SetBool("notb" , true);
                 }
        }
             
        }
            else if(evilScore >= 3 && score < 3 || score < 3 || evilScore >= 3){
                string otherbox;
            loose = true;
            global.SetBool("dark" , true);
            bookanim.SetBool("down" , true);
            Invoke("DisBook" , 1.1f);
            if(GameObject.FindGameObjectsWithTag("lightened").Length > 0){
                for(i=0; i >= 5 - evilScore; i++){
                    GameObject.FindGameObjectsWithTag("lightened")[i].GetComponent<Animator>().SetBool("godark" , true);
                }
            }
            if(GameObject.FindGameObjectsWithTag("off").Length > 0){
                 offLength = GameObject.FindGameObjectsWithTag("off").Length;
                 burntLength = GameObject.FindGameObjectsWithTag("notburnt").Length;
               //  SBurntLength = GameObject.FindGameObjectsWithTag("SNotburnt").Length;
                 for(o = 0; o < offLength ; o++){
                     GameObject.FindGameObjectsWithTag("off")[o].GetComponent<Animator>().SetBool("dark" , true);
                 }
                 for(int j = 0; j < burntLength ; j++){
                     GameObject.FindGameObjectsWithTag("notburnt")[j].GetComponent<Animator>().SetBool("notb" , true);
                     otherbox = GameObject.FindGameObjectsWithTag("notburnt")[j].name;
                     GameObject.FindGameObjectWithTag(otherbox).GetComponent<Animator>().SetBool("notb" , true);
                 }
        }
        }
    }

    void EndMenu(){
        winlooseMenu.SetActive(true);
           if(score == 3){
               sentforEnd.text = EndSents[0];
               endAnim.SetInteger("stars" , 1);
           }
           else if(score == 4){
               sentforEnd.text = EndSents[1];
               endAnim.SetInteger("stars" , 2);
           }
           else if(score == 5){
               sentforEnd.text = EndSents[2];
               endAnim.SetInteger("stars" , 3);
           }
           else if(score < 3){
               sentforEnd.text = EndSents[3];
               endAnim.SetInteger("stars" , 4);
           }
    }

    void GuidThem(){
        if(lightScore > 0 && stopTime == false){
           int lengthNB = GameObject.FindGameObjectsWithTag("notburnt").Length;
        //   int SPlengthNB = GameObject.FindGameObjectsWithTag("SNotburnt").Length;
           int ForRandom;
           string secondName;
           ForRandom = Random.Range(0,lengthNB);
           GameObject.FindGameObjectsWithTag("notburnt")[ForRandom].GetComponent<Animator>().SetTrigger("guide");
           secondName = GameObject.FindGameObjectsWithTag("notburnt")[ForRandom].name;
           GameObject.FindGameObjectWithTag(secondName).GetComponent<Animator>().SetTrigger("guide");
          /*  if(firstt[ForRandom] != null && secondd[ForRandom] != null){
               firstt[ForRandom].GetComponent<Animator>().SetTrigger("guide");
               secondd[ForRandom].GetComponent<Animator>().SetTrigger("guide");
           }
           else{
               ForRandom = Random.Range(0,5);
               firstt[ForRandom].GetComponent<Animator>().SetTrigger("guide");
               secondd[ForRandom].GetComponent<Animator>().SetTrigger("guide");
           }*/
       }
    }

    
    void DisBook(){
        Book.SetActive(false);
    }
    public void BookIconButton(){
        bookIcon.SetActive(false);
        Book.SetActive(true);
        bookanim.SetBool("up" , true);
    }


    void JsonReaderFunc(){
        gamePath = Application.dataPath + "/Resources";
        //set the downloadfile to game path
        //  var dlpath = new DownloadHandlerFile(gamePath);
         textJasoneng = Resources.Load<TextAsset>("JSONNewDD");
         myWordList = JsonUtility.FromJson<WordList>(textJasoneng.text);
         for(int w = 0; w < 5 ; w++){
             BoxWords[w].text = myWordList.words[w].per;
             CorrectBoxWords[w].text = myWordList.words[w].en;
             BookWords[w].text = myWordList.words[w].en;
             WordsToRead[w] = myWordList.words[w].en;
         }
         for(int s = 0; s < 4 ; s++){
             EndSents[s] = myWordList.winsent[s].sent;
         }
    }

    public void Restart(){
        SceneManager.LoadScene(sceneName);
    }



    void ForControllingStatics(){
        score = 0;
        win = false;
        loose = false;
        evilScore = 0 ;
        lightScore = 5;
        NewItemSlot.here = false ;
        NewItemSlot.darkness = false;
        for(int e = 0; e < 5; e++){
            burneffect[e].Destroyed = 0;
        }
    }
}
