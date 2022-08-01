using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class karencont : MonoBehaviour
{
    public AudioSource theme;
    public static bool stopEve = true;
    public static bool begin = false;
    bool lastpass = false , lastfalll = false , calllet = false;
    public float arrowspeed;
    public Animator lion , jumper , resultanim;
    //*for controlling falling obstacles
    public Animator forfallers;
    public string[] fallingObstc;
    public GameObject[] obscores;
    public static GameObject nowobscore;
    public static bool disobscatcher = true;
    int oc =  0;
    int f = 0;
    //*

    public GameObject thoughtui , resultui , numberui , finalscore ;
    bool jumpguid = true , sprintguid = true , sitguid = true , walkguid = true ;
    bool finished = false;
    
    GameObject arrow;
    GameObject eggy , fally , obsjump;
    int i = 0 , j = 0 , k = 0 , m = 5;
    public GameObject[] fallers , numbers;
    public float animspeedslow , animspeedfast , cameraspeedslow , cameraspeedfast;
    public Animator RedScreen;
    public GameObject ScoreBack;
    public canvascont cny;
    
    // Start is called before the first frame update
    void Awake(){
       
        stopEve = true;
        begin = false;
        disobscatcher = true;

    }
    void Start()
    {
        InvokeRepeating("count" , 0f , 1f);
        Invoke("nowstart" , 4f);
        Invoke("camstart" , 4f);
        Invoke("playTheme" , 4f);
    }

    // Update is called once per frame
    void Update()
    {
        if(begin == true){
                lion.SetBool("run" , true);
            begin = false;
        }

        

        if(stopEve == true){
           // lion.SetBool("run" , false);
           theme.pitch = 0.5f;
           lion.speed = animspeedslow;
           Cameramover.speed2 = cameraspeedslow;
        }
        else if(stopEve == false){
            theme.pitch = 1;
            lion.speed = animspeedfast;
            Cameramover.speed2 = cameraspeedfast;
        }
        if(canvascont.jump == true){
            disobscatcher = false;
            Destroy(obsjump , 2f);
            stopEve = false;
            lion.SetBool("run" , false);
            jumper.SetTrigger("jump");
            lion.SetTrigger("jump");
            Invoke("nowstart" , 0.34f);
            canvascont.jump = false;
          //  Invoke("enablethen" , 1f);
        }
        if(canvascont.sitdown == true){
            canvascont.SitOb = false;
            disobscatcher = false;
            stopEve = false;
            Cameramover.camstop = false;
            lion.SetBool("run" , false);
            lion.SetBool("crouch" , true);
            Invoke("throwarrow" , 0.5f);
          //  Invoke("enablethen" , 1f);
            
            
        }

        if(catchers.passed == true){
            Cameramover.camstop = true;
            lion.SetBool("crouch" , false);
            Destroy(arrow , 2f);
            nowstart();
           // stopEve = false;
            catchers.passed = false;
        }
        if(canvascont.walk == true){
            canvascont.WalkOb = false;
            disobscatcher = false;
            stopEve = false;
            lion.SetBool("run" , false);
            lion.SetBool("walk" , true);
            Cameramover.speed2 = 4f;
            canvascont.walk = false;
          //  Invoke("enablethen" , 1f);
        }
        if(lastpass == true){
            lion.SetBool("walk" , false);
            nowstart();
          //  Cameramover.speed2 = 8f;
            Destroy(eggy , 3f);
            lastpass = false;
        }
        if(canvascont.sprint == true){
            canvascont.RunOb = false;
            disobscatcher = false;
            stopEve = false;
            lion.SetBool("run" , false);
            lion.SetBool("sprint" , true);
            Invoke("fallem" , 0.5f);
            Cameramover.speed2 = 10f;
            calllet = true;
            canvascont.sprint = false;
         //   Invoke("enablethen" , 1f);
        }
        if(calllet == true){
            Invoke("fallfinished" , 1.5f);
            calllet = false;
        }
        if(lastfalll == true){
            lion.SetBool("sprint" , false);
            nowstart();
           // Cameramover.speed2 = 8f;
            Destroy( fally , 4f);
            lastfalll = false;
        }
        if(canvascont.hitted == true){
            disobscatcher = false;
            Cameramover.globalblurrate = 0f;
            stopEve = false;
            Cameramover.camstop = false;
            lion.SetBool("run" , false);
            AnimContAfterHit();
            AnimContAfterHitwrong();
          //  lion.SetTrigger("hit");
          //  Invoke("nowstart" , 0.5f);
           // Invoke("camstart" , 0.5f);
            canvascont.hitted = false;
          //  Invoke("enablethen" , 1f);
        }
        if(hitObstacles.charhitted == true){
            RedScreen.SetTrigger("red");
            disableObsCores();
            Cameramover.globalblurrate = 0f;
            thoughtui.SetActive(false);
            stopEve = false;
            Cameramover.camstop = false;
            lion.SetBool("run" , false);
            AnimContAfterHit();
            lion.SetTrigger("hit");
            if(canvascont.score > 50 ){
                canvascont.score -= 10;
            }
            else if(canvascont.score <= 50){
                canvascont.diedd = true;
            }
            Invoke("nowstart" , 0.8f);
            Invoke("camstart" , 0.8f);
            hitObstacles.charhitted = false;
        }
        if(canvascont.diedd == true){
            cny.sliderr.SetActive(false);
            cny.menuicon.SetActive(false);
            theme.Stop();
            disobscatcher = false;
            Cameramover.globalblurrate = 0f;
            stopEve = false;
            Cameramover.camstop = false;
        //    secscore.SetActive(false);
            ScoreBack.SetActive(false);
            lion.SetBool("run" , false);
            lion.SetBool("die" , true);
            resultui.SetActive(true);
            canvascont.setscore = true;
            resultanim.SetBool("died" , true);
            canvascont.diedd = false;
           
        }
        if(finished == true){
            cny.sliderr.SetActive(false);
            cny.menuicon.SetActive(false);
            theme.Stop();
         //   secscore.SetActive(false);
            Cameramover.camstop = false;
            lion.SetBool("run" , false);
            ScoreBack.SetActive(false);
            if(canvascont.score == 60){
                resultui.SetActive(true);
                resultanim.SetBool("one" , true);
                Invoke("showscore" , 2f);
            }
            else if(canvascont.score == 70){
                 resultui.SetActive(true);
                 resultanim.SetBool("two" , true);
                 Invoke("showscore" , 2f);
            }
            else if(canvascont.score == 80){
                resultui.SetActive(true);
                resultanim.SetBool("three" , true);
                Invoke("showscore" , 2f);
            }
            else if(canvascont.score == 50){
                resultui.SetActive(true);
                resultanim.SetBool("none" , true);
                Invoke("showscore" , 1f);
            }
            
        }
    }
    void fallem(){
        forfallers.SetBool(fallingObstc[f] , true);
    }
    void throwarrow(){
        arrow.transform.Translate(Vector2.right * arrowspeed * Time.deltaTime);
    }

    void AnimContAfterHit(){
        if(canvascont.SitOb == true){
            Destroy(arrow);
            canvascont.SitOb = false;
        }
        else if(canvascont.RunOb == true){
            forfallers.SetBool(fallingObstc[f] , true);
            calllet = true;
            Destroy(fally , 1.6f);
            canvascont.RunOb = false;
        }
        else if(canvascont.WalkOb == true){
            canvascont.WalkOb = false;
        }
    }
    void AnimContAfterHitwrong(){
        if(canvascont.jumpwrong == true){
            jumper.SetTrigger("jump");
            lion.SetTrigger("jump");
            Invoke("nowstart" , 1f);
            Invoke("camstart" , 1f);
            canvascont.jumpwrong = false;
        }
        else if(canvascont.walkwrong == true){
            lion.SetBool("walk" , true);
            Invoke("walkfalser" , 1f);
            Invoke("nowstart" , 1.1f);
            Invoke("camstart" , 1.1f);
            canvascont.walkwrong = false;
        }
         else if(canvascont.sitwrong == true){
             lion.SetBool("crouch" , true);
             Invoke("crouchfalser" , 1f);
             Invoke("nowstart" , 1.1f);
             Invoke("camstart" , 1.1f);
            canvascont.sitwrong = false;
        }
         else if(canvascont.runwrong == true){
             lion.SetBool("sprint" , true);
             Invoke("runfalser" , 1f);
             Invoke("nowstart" , 1.1f);
             Invoke("camstart" , 1.1f);
            canvascont.runwrong = false;
        }
    }
    void crouchfalser(){
        lion.SetBool("crouch" , false);
    }
    void walkfalser(){
        lion.SetBool("walk" , false);
    }
    void runfalser(){
        lion.SetBool("sprint" , false);
    }
   
    void disableObsCores(){
      //  nowobscore = obscores[oc];
        nowobscore.SetActive(false);
       // obscores[oc].SetActive(false);
       // if(oc < 12){
       //     oc += 1;
       // }
        
    }
    void enablethen(){
        disobscatcher = true;
    }
    void showscore(){
        finalscore.SetActive(true);
        finalscore.GetComponent<Text>().text = canvascont.score.ToString();
    }
    void count(){
        if(j <4){
            numbers[j].SetActive(true);
             j += 1;
        }
        else if(j >=4){
            numberui.SetActive(false);
        }
        
    }
    void playTheme(){
        theme.Play();
    }

    void nowstart(){
        stopEve = false;
        begin = true;
    }
    void camstart(){
        Cameramover.camstop = true;
    }
    void fallfinished(){
        print("fall called");
        forfallers.SetBool(fallingObstc[f] , false);
        if(f<2){
             f += 1;
        }
    }
   

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "obstaclej"){
            canvascont.answer = "jump";
            other.gameObject.tag = "nottagged";
            obsjump = other.gameObject;
            Cameramover.globalblurrate = 4f;
            stopEve = true;
            thoughtui.SetActive(true);
            
            if(jumpguid == true){
                jumpguid = false;
              //  guides[0].SetActive(true);
            }
            canvascont.jumphit = true;
            print(canvascont.jumphit);
        }
        else if(other.gameObject.tag == "arrowup"){
            canvascont.answer = "sitdown";
            other.gameObject.tag = "sittagged";
            canvascont.SitOb = true;
             Cameramover.globalblurrate = 4f;
            stopEve = true;
            arrow = other.gameObject;
            thoughtui.SetActive(true);
            if(sitguid == true){
                sitguid = false;
              //   guides[1].SetActive(true);
            }
            canvascont.sitdownhit = true;
            print(canvascont.sitdownhit);
        }
        else if(other.gameObject.tag == "firstegg"){
            canvascont.answer = "walk";
            other.gameObject.tag = "nottagged";
            canvascont.WalkOb = true;
             Cameramover.globalblurrate = 4f;
            eggy = other.gameObject;
            stopEve = true;
            thoughtui.SetActive(true);
            if(walkguid == true){
                walkguid = false;
              //  guides[2].SetActive(true);
            }
            canvascont.walkhit = true;
            print(canvascont.walkhit);
        }
        else if(other.gameObject.tag == "lastegg"){
            lastpass = true;
        }
        else if(other.gameObject.tag == "firstfall"){
            canvascont.answer = "sprint";
            other.gameObject.tag = "nottagged";
            canvascont.RunOb = true;
            print("fall" + canvascont.RunOb);
             Cameramover.globalblurrate = 4f;
            stopEve = true;
            thoughtui.SetActive(true);
            if(sprintguid == true){
                sprintguid = false;
              //  guides[3].SetActive(true);
            }
            fally = other.gameObject;
            canvascont.sprinthit = true;
            print(canvascont.sprinthit);
        }
        else if(other.gameObject.tag == "lastfall"){
            lastfalll = true;
        }
        else if(other.gameObject.tag == "flag"){
           // stopEve = true;
            resultui.SetActive(true);
            finished = true;
        }
    }

    
}
