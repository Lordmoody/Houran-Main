using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class canvascontDD : MonoBehaviour
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

    public Text jumpt , walkt , sitt , runt , slottxt;
    public Font[] fontss; 
    public SpeechControllerDD speechother;
    public static string[] ddread;
    public Animator bookanim;
    public Slider progress;
    public GameObject camer;
    public GameObject[] partics;
    int p = 0; 
    public static string answer;
    public GameObject sliderr , menuicon;
    // Start is called before the first frame update
    void Awake(){

        ddread = new string[4];
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
            slottxt.font = fontss[0];
        }
        else {
            jumpt.font = fontss[1];
            walkt.font = fontss[1];
            sitt.font = fontss[1];
            runt.font = fontss[1];
            slottxt.font = fontss[1];
        }
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        progress.value = camer.transform.position.x * 0.002f;
        scoretx.text = score.ToString();
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
      
        Cameramover.globalblurrate = 0f;
        if(jumphit == true){
            walkhit = false;
            sprinthit = false;
            jumphit = false;
            sitdownhit = false;
            jump = true;
            bookanim.SetInteger("book" , 1);
            Invoke("uidiser" , 1.1f);
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
            GameObject.Find(answer).GetComponent<Animator>().SetTrigger("right");
            Invoke("bookanimator" , 1f);
            Invoke("uidiser" , 2.1f);
            sitdownhit = false;
            walkhit = false;
            sprinthit = false;
           
        }
      //  guides[0].SetActive(false);

        
    }

    

    public void sitdownb(){
        Cameramover.globalblurrate = 0f;
        if(sitdownhit == true){
            partics[p].SetActive(true);
            p += 1;
            walkhit = false;
            sprinthit = false;
            jumphit = false;
            sitdownhit = false;
            sitdown = true;
            bookanim.SetInteger("book" , 1);
            Invoke("uidiser" , 1.1f);
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
            GameObject.Find(answer).GetComponent<Animator>().SetTrigger("right");
            Invoke("bookanimator" , 1f);
            Invoke("uidiser" , 2.1f);
            
            walkhit = false;
            sprinthit = false;
            jumphit = false;
        }
       // guides[1].SetActive(false);
        
    }
    public void walkb(){
        Cameramover.globalblurrate = 0f;
        if(walkhit == true){
            walkhit = false;
            sprinthit = false;
            jumphit = false;
            sitdownhit = false;
           walk = true;
        bookanim.SetInteger("book" , 1);
            Invoke("uidiser" , 1.1f);
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
            GameObject.Find(answer).GetComponent<Animator>().SetTrigger("right");
            Invoke("bookanimator" , 1f);
            Invoke("uidiser" , 2.1f);
            sitdownhit = false;
            
            sprinthit = false;
            jumphit = false;
        }
      //  guides[2].SetActive(false);
        
    }

    public void runb(){
        Cameramover.globalblurrate = 0f;
        if(sprinthit == true){
           walkhit = false;
            sprinthit = false;
            jumphit = false;
            sitdownhit = false;
             sprint = true;
        bookanim.SetInteger("book" , 1);
            Invoke("uidiser" , 1.1f);
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
            GameObject.Find(answer).GetComponent<Animator>().SetTrigger("right");
            Invoke("bookanimator" , 1f);
            Invoke("uidiser" , 2.1f);
            sitdownhit = false;
            walkhit = false;
            
            jumphit = false;
        }
      //  guides[3].SetActive(false);
       
    }
    void bookanimator(){
        bookanim.SetInteger("book" , 1);
    }
    void uidiser(){
        bookanim.SetInteger("book" , 2);
        thoughtui.SetActive(false);
    }

    public void restart(){
        Time.timeScale = 1;
        karencontDD.stopEve = true;
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
        ScoreBack.SetActive(true);
        Time.timeScale = 1;
        
    }
    public void menu(){
        menuicon.SetActive(false);
        sliderr.SetActive(false);
        theme.Pause();
        Time.timeScale = 0;
        limenu.SetActive(true);
        ScoreBack.SetActive(false);
    }
}
