using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class canvascont : MonoBehaviour
{
    public static bool jump = false;
    public static bool sitdown = false;
    public GameObject ScoreBack;
    public static bool walk = false , sprint = false;
    public GameObject thoughtui;
    public static bool jumphit = false  , setscore = false , walkhit = false , sprinthit = false , sitdownhit = false , hitted = false , diedd = false; 
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

    public Text jumpt , walkt , sitt , runt;
    public Text[] guidetext;
    public Font[] fontss; 
    public SpeechControllerOther speechother;
    public string[] textstoread;
    bool jumpTip = false , walkTip = false , sitTip = false , runTip = false;
    public static bool jg = false , wg = false , sg = false , rg = false;
    public GameObject jumpguide , sitguide , walkguide , runguide;
    public GameObject hitrock;
    public static string answer;
    public Image[] wrongAnswer;
    GameObject rightAnswer;
    public Button[] buttons;
    public static bool jumpwrong , sitwrong , walkwrong , runwrong;
    public Slider progress;
    public GameObject camer;
    public Animator shaker;
    public GameObject sliderr , menuicon;
    // Start is called before the first frame update
    void Awake(){
        ChangeTTSLange();
        Time.timeScale = 1;
        jump = false;
        sitdown = false;
        walk = false;
        sprint = false;
        jumphit = false;
        walkhit = false;
        sprinthit = false;
        sitdownhit = false;
        diedd = false;
        hitted = false;
        setscore = false;
        SitOb = false;
        WalkOb = false;
        RunOb = false;
        jumpwrong = false;
        sitwrong = false;
        walkwrong = false;
        runwrong = false;
        score = 80;
    }
    void Start()
    {
        if(managertree.DestLang == "Persian"){
            jumpt.font = fontss[0];
            walkt.font = fontss[0];
            sitt.font = fontss[0];
            runt.font = fontss[0];
            for(int i = 0;i <= 3 ; i++){
                guidetext[i].font = fontss[0];
            }
        }
        else {
            jumpt.font = fontss[1];
            walkt.font = fontss[1];
            sitt.font = fontss[1];
            runt.font = fontss[1];
            for(int i = 0;i <= 3 ; i++){
                guidetext[i].font = fontss[1];
            }
        }
            jumpt.text = managertree.desttexts[0];
            walkt.text = managertree.desttexts[1];
            sitt.text = managertree.desttexts[2];
            runt.text = managertree.desttexts[3];
            textstoread[0] = managertree.desttexts[0];
            textstoread[1] = managertree.desttexts[1];
            textstoread[2] = managertree.desttexts[2];
            textstoread[3] = managertree.desttexts[3];
            for(int i = 0;i <= 3 ; i++){
                guidetext[i].text = managertree.desttexts[i];
            }
        
    }

    // Update is called once per frame
    void Update()
    {
        progress.value = camer.transform.position.x * 0.002f;
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
                speechother.StartSpeaking(1);
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
                speechother.StartSpeaking(2);
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



    public void jumpb(){
      if(jumpTip == false){
          Cameramover.globalblurrate = 0f;
        if(jumphit == true){
            walkhit = false;
            sprinthit = false;
            jumphit = false;
            sitdownhit = false;
            jump = true;
            thoughtui.SetActive(false);
            jumphit = false;
        }
        else if(jumphit == false){
            gorred.SetTrigger("red");
            if(score > 50){
                score -= 10;
                hitted = true;
             //   jump = true;
                //hitrock.SetActive(true);
            }            
            else if(score <= 50){
                print("died");
                diedd = true;
            }
            wrongAnswer[0].color = Color.red;
            GameObject.Find(answer).GetComponent<Image>().color = Color.green;
            for(int b = 0; b<=3; b++){
                buttons[b].interactable = false;
            }
            shaker.SetTrigger("shake");
            Invoke("nowdisactive" , 0.5f);
            jumpwrong = true;
            sitdownhit = false;
            walkhit = false;
            sprinthit = false;
           
        }
      }
        else if(jumpTip == true){
            jumpTip = false;
        }
    }

    void nowdisactive(){
        GameObject.Find(answer).GetComponent<Image>().color = Color.white;
   // hitrock.SetActive(false);
        for(int b = 0; b<=3; b++){
                buttons[b].interactable = true;
                wrongAnswer[b].color = Color.white;
            }
        thoughtui.SetActive(false);
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
    

    public void sitdownb(){
        if(sitTip == false){
            Cameramover.globalblurrate = 0f;
        if(sitdownhit == true){
            walkhit = false;
            sprinthit = false;
            jumphit = false;
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
             //   hitrock.SetActive(true);
              //  sitdown = true;
                
            }            
            else if(score <= 50){
                print("died");
                diedd = true;
            }
            wrongAnswer[1].color = Color.red;
            GameObject.Find(answer).GetComponent<Image>().color = Color.green;
            for(int b = 0; b<=3; b++){
                buttons[b].interactable = false;
            }
            shaker.SetTrigger("shake");
            Invoke("nowdisactive" , 0.5f);
            sitwrong = true;
            walkhit = false;
            sprinthit = false;
            jumphit = false;
        }
        }
        else if(sitTip == true){
            sitTip = false;
        }
        
    }
    public void walkb(){
        if(walkTip == false){
             Cameramover.globalblurrate = 0f;
        if(walkhit == true){
            walkhit = false;
            sprinthit = false;
            jumphit = false;
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
           //  walk = true;
            //    hitrock.SetActive(true);
               
            }            
            else if(score <= 50){
                print("died");
                diedd = true;
            }
            wrongAnswer[2].color = Color.red;
            GameObject.Find(answer).GetComponent<Image>().color = Color.green;
            for(int b = 0; b<=3; b++){
                buttons[b].interactable = false;
            }
            shaker.SetTrigger("shake");
            Invoke("nowdisactive" , 0.5f);
            sitdownhit = false;
            walkwrong = true;
            sprinthit = false;
            jumphit = false;
        }
        }
       else if(walkTip == true){
           walkTip = false;
       }
        
    }

    public void runb(){
        if(runTip == false){
            Cameramover.globalblurrate = 0f;
        if(sprinthit == true){
           walkhit = false;
            sprinthit = false;
            jumphit = false;
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
              //  hitrock.SetActive(true);
               // sprint = true;
              
            }            
            else if(score <= 50){
                print("died");
                diedd = true;
            }
            wrongAnswer[3].color = Color.red;
            GameObject.Find(answer).GetComponent<Image>().color = Color.green;
            for(int b = 0; b<=3; b++){
                buttons[b].interactable = false;
            }
            shaker.SetTrigger("shake");
            Invoke("nowdisactive" , 0.5f);
            sitdownhit = false;
            walkhit = false;
            runwrong = true;
            jumphit = false;
        }
        }
       else if(runTip == true){
           runTip = false;
       }
       
    }

    public void restart(){
        Time.timeScale = 1;
        karencont.stopEve = true;
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
        menuicon.SetActive(true);
        sliderr.SetActive(true);
        theme.Play();
        limenu.SetActive(false);
        //secscore.SetActive(true);
        ScoreBack.SetActive(true);
        Time.timeScale = 1;
        
    }
    public void menu(){
        menuicon.SetActive(false);
        sliderr.SetActive(false);
        theme.Pause();
        Time.timeScale = 0;
      //  secscore.SetActive(false);
        limenu.SetActive(true);
        ScoreBack.SetActive(false);
    }
}
