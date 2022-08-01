using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class VoidCanvas : MonoBehaviour
{
    public string CorrectWord , CurrentWord;
    public string[] WordsS , WordsBase;
    public PlayerCont playerCont;
    public Animator NextWord , ThisIsCor , SpriteBox;
    public Animator[] buttons;
    int i = 0 , l = 4;
    public static bool CorrectChoice = false;
    public Image FillHealth;
    public static int Health = 4;
    public MoveLight CharMove;
    public MoveLight DarkMove;
   // public _2dxFX_BurnFX burneffects;
   // public string[] wordsWhole;

    ///For Reading From Json
    public TextAsset textJasoneng;
    public Text texts; 
    public Text[] buttonText;
    public string gamePath;
    
  
    [System.Serializable]
    public class Words{
        public string en;
        public string per;
        public string cor;
    }
    [System.Serializable]
    public class Winsent{
        public string sent;
        public string psent;
    }

    [System.Serializable]
    public class WordsList{
        public Words[] words;
        public Winsent[] winsent;
    }
    
    public WordsList myWordsList = new WordsList();

    ///

    ///For the End
     public GameObject Character;
     public ParticleSystem Lost , glow , spiral;
     public AudioSource LostSound;
     public static bool LostB = false , ByCanvas = false , Losted = false;
     public Light2D lightt;
     public Animator bookanim;
     public GameObject BookMenu , darkness;
     public GameObject Destiny;
     int Score = 0;
     bool StopInvoke = false;
     public static bool NowWin = false;
     public GameObject Nozha;
     public Rigidbody2D darky;
     public GameObject winlooseMenu;
     public Text sentforEnd;
     public string[] EndSents;
     public Animator endAnim;
     public AudioSource finished;
     public string namescene;
    // Start is called before the first frame update

    void Awake(){
        ForStatics();
        gamePath = Application.dataPath + "/Resources";
        //set the downloadfile to game path
      //  var dlpath = new DownloadHandlerFile(gamePath);
       textJasoneng = Resources.Load<TextAsset>("JSONVoid");
         myWordsList = JsonUtility.FromJson<WordsList>(textJasoneng.text);
         for(int j=0; j < 4 ; j++){
             WordsS[j] = myWordsList.words[j].en;
             WordsBase[j] = myWordsList.words[j].per;
             buttonText[j].text = myWordsList.words[j].en;
             EndSents[j] = myWordsList.winsent[j].sent;
         }
    }
    void Start()
    {
        CorrectWord = WordsS[0];
        CurrentWord = WordsBase[0];
        texts.text = WordsBase[0];
        ThisIsCor = buttons[0];
        VoidSlot.CorrectOne = CorrectWord;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0){
            CharMove.go = false;
            LostB = true;
            Lost.Play();
            Character.GetComponent<SpriteRenderer>().enabled = false;
            lightt.pointLightOuterRadius = 0f;
            LostSound.Play();
            bookanim.SetBool("down" , true);
            NextWord.SetBool("dis" , true);
            SpriteBox.SetBool("dis" , true);
            glow.Stop();
            spiral.Stop();
            Invoke("SetPlayerDisActive" , 2f);
            Invoke("EndMenu" , 2f);
            Losted = true;
            Health = 4;
        }
        if(Losted == false && Score >= 4){
         //  InvokeRepeating("DecreaseSpeed" , 0.1f , 0.2f);
         Instantiate(Destiny , Character.transform.position + new Vector3(26.39f , -5.57f, 0), Quaternion.identity);
            Health = 4;
            Losted = true;
        }
        if(NowWin == true){
            finished.Play();
            Character.SetActive(false);
            DarkMove.go = false;
            darky.AddForce(transform.up * 5f , ForceMode2D.Force );
            Invoke("EndMenu" , 2f);
            bookanim.SetBool("down" , true);
            NextWord.SetBool("dis" , true);
            SpriteBox.SetBool("dis" , true);
            Invoke("SetPlayerDisActive" , 3f);
            NowWin = false;
        }
    }
    void SetPlayerDisActive(){
        Character.SetActive(false);
        BookMenu.SetActive(false);
        darkness.SetActive(false);
    }
    void DecreaseSpeed(){
        if(StopInvoke == false){
            if(CharMove.speed > 0){
            CharMove.speed -= 1;
        }
        else{
            NowWin = true;
            StopInvoke = true;
        }
        }
        
        
    }
    void EndMenu(){
        winlooseMenu.SetActive(true);
           if(Score == 2){
               sentforEnd.text = EndSents[0];
               endAnim.SetInteger("stars" , 1);
           }
           else if(Score == 3){
               sentforEnd.text = EndSents[1];
               endAnim.SetInteger("stars" , 2);
           }
           else if(Score == 4){
               sentforEnd.text = EndSents[2];
               endAnim.SetInteger("stars" , 3);
           }
           else if(Score < 2){
               sentforEnd.text = EndSents[3];
               endAnim.SetInteger("stars" , 4);
           }
    }

    public void WordActive( string thisSWord){
        if(thisSWord == CorrectWord){
            GameObject.FindGameObjectWithTag(thisSWord).SetActive(false);
            NextWord.SetTrigger("next");
            i += 1;
            Score += 1;
            CorrectWord = WordsS[i];
            CurrentWord = WordsBase[i];
            texts.text = WordsBase[i];
            DarknessDetection.HittedByDark = false;
            CorrectChoice = true;
            playerCont.lessen = false;
        }
        else {
            if(LostB == false){
                ByCanvas = true;
                FillHealth.fillAmount -= 0.25f;
                Health -= 1;
                GameObject.FindGameObjectWithTag(CorrectWord).GetComponent<Animator>().SetTrigger("this");
                WordsS[l] = CorrectWord;
                WordsBase[l] = CurrentWord;
                l += 1;
                i += 1;
                CurrentWord = WordsBase[i];
                CorrectWord = WordsS[i];
                texts.text = WordsBase[i];
                NextWord.SetTrigger("next");
                DarknessDetection.HittedByDark = true;
                playerCont.lessen = false;
            }
        }
    }


    public void CorrectAnswer(string thisword){
        GameObject.FindGameObjectWithTag(thisword).SetActive(false);
         //   NextWord.SetTrigger("next");
       //     SpriteBox.SetTrigger("next");
       texts.text = myWordsList.words[i].cor;
            i += 1;
            Score += 1;
            CorrectWord = WordsS[i];
            VoidSlot.CorrectOne = CorrectWord;
            CurrentWord = WordsBase[i];
            
           // texts.text = WordsBase[i];
           Invoke("ChangeText" , 1f);
            DarknessDetection.HittedByDark = false;
            CorrectChoice = true;
            playerCont.lessen = false;
    }
    void ChangeText(){
        texts.text = WordsBase[i];
    }

    public void WrongAnswer(string thisword){
        if(LostB == false){
                ByCanvas = true;
                FillHealth.fillAmount -= 0.25f;
                Health -= 1;
                GameObject.FindGameObjectWithTag(CorrectWord).GetComponent<Animator>().SetTrigger("this");
                WordsS[l] = CorrectWord;
                WordsBase[l] = CurrentWord;
                texts.text = myWordsList.words[i].cor;
                l += 1;
                i += 1;
                CurrentWord = WordsBase[i];
                
                CorrectWord = WordsS[i];
                VoidSlot.CorrectOne = CorrectWord;
                //texts.text = WordsBase[i];
                Invoke("ChangeText" , 1f);
              //  NextWord.SetTrigger("next");
              //  SpriteBox.SetTrigger("next");
                DarknessDetection.HittedByDark = true;
                playerCont.lessen = false;
            }
    }


    void ForStatics(){
        CorrectChoice = false;
        Health = 4;
        LostB = false ;
        ByCanvas = false ;
        Losted = false;
        NowWin = false;
        DarknessDetection.HittedByDark = false;
        VoidDrag.DragBegan = false;
        VoidDrag.Incorrect = false;
        VoidSlot.here = false;
//        burneffects.Destroyed = 0;
    }

    public void Restart(){
        SceneManager.LoadScene(namescene);
    }
}
