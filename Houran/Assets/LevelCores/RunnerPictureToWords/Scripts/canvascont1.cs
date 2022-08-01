using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityPersianSupport;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
public class canvascont1 : MonoBehaviour
{
    public static bool jump = false;
    public static bool sitdown = false;
    public GameObject ScoreBack;
    public static bool walk = false , sprint = false;
    public GameObject thoughtui;
    public static bool applehit = false  , setscore = false , walkhit = false , sprinthit = false , sitdownhit = false , hitted = false , diedd = false; 
    public static int score = 80 , lastscore;
   // public GameObject[] guides;
    public Text scoretx;
    public GameObject limenu;
    public Animator gorred;
    //*for setting seting animations of obstavles when characters is hitted by them
    public static bool   SitOb = false , WalkOb = false , RunOb = false;
    //*
    public AudioSource theme;
    //*  these are for controlling blury effects at slow motion
    //*

    public Text jumpt , walkt , sitt , runt , guidtxt;
    public Font[] fontss; 
    [System.Serializable]
    public class RunnerPic{
        public string word;
        public string char1;
        public string char2;
        public string char3;
    }

    [System.Serializable]
    public class RunnerList{
        public RunnerPic[] runnerpic;
    }
    [System.Serializable]
    public class RunnerListper{
        public RunnerPic[] runnerpicper;
    }
    
    public RunnerList Myrunnerpic = new RunnerList();
    public RunnerListper Myrunnerpicper = new RunnerListper();
    //

    public string gamePath;
    public TextAsset textJasoneng;
    int i = 0;
    public static string[] textsJ , charName1 , charName2 , charName3;
    public SpeechControllerPB speechother;

    //for guide
    public GameObject jumpguide , walkguide , sitguide , runguide;
    bool jumpTip = false , walkTip = false , sitTip = false , runTip = false;
    public static bool jg = false , wg = false , sg = false , rg = false;
    public Text[] textstoread;
    
    // Start is called before the first frame update
    void Awake(){
        
        gamePath = Application.dataPath + "/Resources";
        textJasoneng = Resources.Load<TextAsset>("JASONtext");
        Myrunnerpic = JsonUtility.FromJson<RunnerList>(textJasoneng.text);
        textsJ = new string[Myrunnerpic.runnerpic.Length];
        charName1 = new string[Myrunnerpic.runnerpic.Length];
        charName2 = new string[Myrunnerpic.runnerpic.Length];
        charName3 = new string[Myrunnerpic.runnerpic.Length];
        if(managertree.DestLang == "English"){
            for(i = 0; i < 4 ; i++){
            textstoread[i].text = Myrunnerpic.runnerpic[i].word;
             textsJ[i] = Myrunnerpic.runnerpic[i].word;
             charName1[i] = Myrunnerpic.runnerpic[i].char1;
             charName2[i] = Myrunnerpic.runnerpic[i].char2;
             charName3[i] = Myrunnerpic.runnerpic[i].char3;
         }
        }
        else if(managertree.DestLang == "Persian"){
            for(i = 0; i < 4 ; i++){
                textstoread[i].text = Myrunnerpicper.runnerpicper[i].word;
             textsJ[i] = Myrunnerpicper.runnerpicper[i].word;
             charName1[i] = Myrunnerpicper.runnerpicper[i].char1;
             charName2[i] = Myrunnerpicper.runnerpicper[i].char2;
             charName3[i] = Myrunnerpicper.runnerpicper[i].char3;
         }
        }
         
         print(textsJ[0]);
        Time.timeScale = 1;
        jump = false;
        sitdown = false;
        walk = false;
        sprint = false;
        applehit = false;
        walkhit = false;
        sprinthit = false;
        sitdownhit = false;
        diedd = false;
        hitted = false;
        setscore = false;
        SitOb = false;
        WalkOb = false;
        RunOb = false;
        score = 80;
        ChangeTTSLange();
    }
    void Start()
    {
        if(managertree.DestLang == "Persian"){
            jumpt.font = fontss[0];
            walkt.font = fontss[0];
            sitt.font = fontss[0];
            runt.font = fontss[0];
            guidtxt.font = fontss[0];
            for(int t = 0; t<=3 ; t++){
                textstoread[t].font = fontss[0];
            }
            
        }
        else {
            jumpt.font = fontss[1];
            walkt.font = fontss[1];
            sitt.font = fontss[1];
            runt.font = fontss[1];
            guidtxt.font = fontss[1];
            for(int t = 0; t<=3 ; t++){
                textstoread[t].font = fontss[1];
            }
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        scoretx.text = score.ToString();
        if(jg == true){
            if(LongClickButton.timePassed == true){
            jumpguide.SetActive(true);
            speechother.StartSpeaking(0);
            jumpguide.GetComponent<Animator>().SetBool("up" , true);
           // LongClickButton.timePassed = false;
        }
        else if(LongClickButton.timePassed == false){
            jumpguide.SetActive(false);
            jg = false;
            jumpguide.GetComponent<Animator>().SetBool("down" , true);
            Invoke("setdownj" , 1f);
         }
        }
        if(wg == true){
            if(LongClickButton.timePassed == true){
                walkguide.SetActive(true);
                speechother.StartSpeaking(2);
                walkguide.GetComponent<Animator>().SetBool("up" , true);
            }
            else if(LongClickButton.timePassed == false){
                walkguide.SetActive(false);
                wg = false;
                walkguide.GetComponent<Animator>().SetBool("down" , true);
                Invoke("setdownw" , 1f);
            }
        }
        if(rg == true){
            if(LongClickButton.timePassed == true){
                runguide.SetActive(true);
                speechother.StartSpeaking(3);
                runguide.GetComponent<Animator>().SetBool("up" , true);
            }
            else if(LongClickButton.timePassed == false){
                runguide.SetActive(false);
                rg = false;
                runguide.GetComponent<Animator>().SetBool("down" , true);
                Invoke("setdownr" , 1f);
            }
        }
        if(sg == true){
            if(LongClickButton.timePassed == true){
                sitguide.SetActive(true);
                speechother.StartSpeaking(1);
                sitguide.GetComponent<Animator>().SetBool("up" , true);
            }
            else if(LongClickButton.timePassed == false){
                sitguide.SetActive(false);
                sg = false;
                sitguide.GetComponent<Animator>().SetBool("down" , true);
                Invoke("setdowns" , 1f);
            }
        }
    }

    void setdownj(){
        jumpguide.GetComponent<Animator>().SetBool("down" , false);
    }
    void setdownw(){
        walkguide.GetComponent<Animator>().SetBool("down" , false);
    }
    void setdownr(){
        runguide.GetComponent<Animator>().SetBool("down" , false);
    }
    void setdowns(){
        sitguide.GetComponent<Animator>().SetBool("down" , false);
    }
    void ChangeTTSLange(){
        if(managertree.DestLang == "Persian"){
            speechother.Setup("fa_IR");
        }
        else if(managertree.DestLang == "English"){
            speechother.Setup("en_US");
        }
    }

    public void AppleB(){
        if(jumpTip == false){
            print(applehit);
        Cameramover.globalblurrate = 0f;
        if(applehit == true){
            
            walkhit = false;
            sprinthit = false;
            applehit = false;
            sitdownhit = false;
            jump = true;
            thoughtui.SetActive(false);
            applehit = false;
        }
        else if(applehit == false){
            gorred.SetTrigger("red");
            if(score > 50){
                score -= 10;
                hitted = true;
            }            
            else if(score <= 50){
                print("died");
                diedd = true;
            }
            thoughtui.SetActive(false);
            sitdownhit = false;
            walkhit = false;
            sprinthit = false;
           
        }
        }
        else if(jumpTip == true){
            jumpTip = false;
        }
    }

    

    public void Orangeb(){
        if(sitTip == false){
            Cameramover.globalblurrate = 0f;
        if(sitdownhit == true){
            walkhit = false;
            sprinthit = false;
            applehit = false;
            sitdownhit = false;
            sitdown = true;
            thoughtui.SetActive(false);
            sitdownhit = false;
        }
        else if(sitdownhit == false){
            gorred.SetTrigger("red");
             if(score > 50){
                score -= 10;
                hitted = true;
                
            }            
            else if(score <= 50){
                print("died");
                diedd = true;
            }
            thoughtui.SetActive(false);
            
            walkhit = false;
            sprinthit = false;
            applehit = false;
        }
        }
        else if(sitTip == true){
            sitTip = false;
        }
        
    }
    public void CarrotB(){
        if(walkTip == false){
            Cameramover.globalblurrate = 0f;
        if(walkhit == true){
            walkhit = false;
            sprinthit = false;
            applehit = false;
            sitdownhit = false;
           walk = true;
        thoughtui.SetActive(false);
            walkhit = false;
        }
        else if(walkhit == false){
            gorred.SetTrigger("red");
             if(score > 50){
                score -= 10;
                hitted = true;
               
            }            
            else if(score <= 50){
                print("died");
                diedd = true;
            }
            thoughtui.SetActive(false);
            sitdownhit = false;
            
            sprinthit = false;
            applehit = false;
        }
        }
        else if(walkTip == true){
            walkTip = false;
        }
        
    }

    public void BananaB(){
        if(runTip  == false){
            Cameramover.globalblurrate = 0f;
        if(sprinthit == true){
           walkhit = false;
            sprinthit = false;
            applehit = false;
            sitdownhit = false;
             sprint = true;
        thoughtui.SetActive(false);
        sprinthit = false;
        }
        else if(sprinthit == false){
            gorred.SetTrigger("red");
             if(score > 50){
                score -= 10;
                hitted = true;
              
            }            
            else if(score <= 50){
                print("died");
                diedd = true;
            }
            thoughtui.SetActive(false);
            sitdownhit = false;
            walkhit = false;
            
            applehit = false;
        }
        }
        else if(runTip == true){
            runTip = false;
        }
       
    }
    public void JumpLong(){
        jumpTip = true;
        jg = true;
    }

    public void SitLong(){
        sitTip = true;
        sg = true;
    }

    public void WalkLong(){
        walkTip = true;
        wg = true;
    }

    public void RunLong(){
        runTip = true;
        rg = true;
    }

    public void restart(){
        Time.timeScale = 1;
        karencont1.stopEve = true;
        SceneManager.LoadScene("Runner1");
        
    }
    public void home(){
        score = 0;
        SceneManager.LoadScene("PlatformerL1");
        
    }
    public void homeforgame(){
        if(setscore == false){
            lastscore = score;
            SceneManager.LoadScene("PlatformerL1");
        }
        else if(setscore == true){
            score = 0;
            lastscore = score;
            SceneManager.LoadScene("PlatformerL1");
        }
    }
    public void close(){
        theme.Play();
        limenu.SetActive(false);
        //secscore.SetActive(true);
        ScoreBack.SetActive(true);
        Time.timeScale = 1;
        
    }
    public void menu(){
        theme.Pause();
        Time.timeScale = 0;
      //  secscore.SetActive(false);
        limenu.SetActive(true);
        ScoreBack.SetActive(false);
    }
}
