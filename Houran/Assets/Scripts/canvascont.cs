using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class canvascont : MonoBehaviour
{
    public static bool jump = false;
    public static bool sitdown = false;
    public static bool walk = false , sprint = false;
    public GameObject thoughtui , secscore;
    public static bool jumphit = false  , setscore = false , walkhit = false , sprinthit = false , sitdownhit = false , hitted = false , diedd = false; 
    public static int score = 80 , lastscore;
    public GameObject[] guides;
    public Text scoretx;
    public GameObject limenu;
    public Animator gorred;
    // Start is called before the first frame update
    void awake(){
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
        score = 80;
    }
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        scoretx.text = score.ToString();
    }

    public void jumpb(){
        if(jumphit == true){
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
        guides[0].SetActive(false);
        
    }

    public void sitdownb(){
        if(sitdownhit == true){
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
        guides[1].SetActive(false);
        
    }
    public void walkb(){
        if(walkhit == true){
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
        guides[2].SetActive(false);
        
    }

    public void runb(){
        if(sprinthit == true){
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
        guides[3].SetActive(false);
       
    }

    public void restart(){
        Time.timeScale = 1;
        karencont.stopEve = true;
        SceneManager.LoadScene("Runner1");
        
    }
    public void home(){
        score = 0;
        SceneManager.LoadScene("Tree");
        
    }
    public void homeforgame(){
        if(setscore == false){
            lastscore = score;
            SceneManager.LoadScene("Tree");
        }
        else if(setscore == true){
            score = 0;
            lastscore = score;
            SceneManager.LoadScene("Tree");
        }
    }
    public void close(){
        limenu.SetActive(false);
        secscore.SetActive(true);
        Time.timeScale = 1;
        
    }
    public void menu(){
        Time.timeScale = 0;
        secscore.SetActive(false);
        limenu.SetActive(true);
    }
}
