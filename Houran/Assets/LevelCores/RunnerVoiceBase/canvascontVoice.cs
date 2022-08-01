using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class canvascontVoice : MonoBehaviour
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
    public Font[] fontss; 
    public static bool spoke = false;
    public GameObject buttonS , buttonM;
    public AudioSource themee;
    public static string[] toRead;
    public SpeechControllerVoiceBase speechother;
    // Start is called before the first frame update
    void Awake(){
        toRead = new string[4];
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
        }
        else {
            jumpt.font = fontss[1];
            walkt.font = fontss[1];
            sitt.font = fontss[1];
            runt.font = fontss[1];
        }
            jumpt.text = managertree.desttexts[0];
            toRead[0] = managertree.desttexts[0];
            walkt.text = managertree.desttexts[1];
            toRead[1] = managertree.desttexts[1];
            sitt.text = managertree.desttexts[2];
            toRead[2] = managertree.desttexts[2];
            runt.text = managertree.desttexts[3];
            toRead[3] = managertree.desttexts[3];
        
        
    }

    // Update is called once per frame
    void Update()
    {
        scoretx.text = score.ToString();
        if(spoke == true){
            if(SpeechControllerVoiceBase.uiText == "jump" || SpeechControllerVoiceBase.uiText == "Jump"){
                jumpb();
            }
            else if(SpeechControllerVoiceBase.uiText == "sit down" || SpeechControllerVoiceBase.uiText == "Sit down"){
                sitdownb();
            }
            else if(SpeechControllerVoiceBase.uiText == "walk" || SpeechControllerVoiceBase.uiText == "Walk"){
                walkb();
            }
            else if(SpeechControllerVoiceBase.uiText == "run" || SpeechControllerVoiceBase.uiText == "Run"){
                runb();
            }
            spoke = false;
        }
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
        themee.Play();
        buttonM.SetActive(false);
        buttonS.SetActive(true);
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
      //  guides[0].SetActive(false);

        
    }

    

    public void sitdownb(){
        themee.Play();
        buttonM.SetActive(false);
        buttonS.SetActive(true);
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
                
            }            
            else if(score <= 50){
                print("died");
                diedd = true;
            }
            thoughtui.SetActive(false);
            
            walkhit = false;
            sprinthit = false;
            jumphit = false;
        }
       // guides[1].SetActive(false);
        
    }
    public void walkb(){
        themee.Play();
        buttonM.SetActive(false);
        buttonS.SetActive(true);
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
               
            }            
            else if(score <= 50){
                print("died");
                diedd = true;
            }
            thoughtui.SetActive(false);
            sitdownhit = false;
            
            sprinthit = false;
            jumphit = false;
        }
      //  guides[2].SetActive(false);
        
    }

    public void runb(){
        themee.Play();
        buttonM.SetActive(false);
        buttonS.SetActive(true);
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
              
            }            
            else if(score <= 50){
                print("died");
                diedd = true;
            }
            thoughtui.SetActive(false);
            sitdownhit = false;
            walkhit = false;
            
            jumphit = false;
        }
      //  guides[3].SetActive(false);
       
    }

    public void restart(){
        Time.timeScale = 1;
        karencontVoice.stopEve = true;
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
