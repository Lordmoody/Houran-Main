using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class karencont1 : MonoBehaviour
{
    /// - this means obsolete
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

    public GameObject thoughtui , resultui , numberui , finalscore;
    bool jumpguid = true , sprintguid = true , sitguid = true , walkguid = true ;
    bool finished = false;
    GameObject arrow;
    GameObject eggy , fally , obsjump;
    int i = 0 , j = 0 , k = 0 , m = 5;
    public GameObject[]   numbers;
    public float animspeedslow , animspeedfast , cameraspeedslow , cameraspeedfast;
    public Animator RedScreen;
    public GameObject ScoreBack;
    public Text WordText;
    public static string[] applewanters , orangewanters , banwanters , carrotwanters; 
    int aw = 0 , ow = 0 , cw = 0 , bw = 0;
    
    // Start is called before the first frame update
    void Awake(){
       
        stopEve = true;
        begin = false;
        disobscatcher = true;
        
    }
    void Start()
    {
        SetWanters();
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
        if(canvascont1.jump == true){
          //  disableObsCores();
            disobscatcher = false;
            Destroy(obsjump , 2f);
            stopEve = false;
           // - lion.SetBool("run" , false);
           // - jumper.SetTrigger("jump");
           // - lion.SetTrigger("jump");
          // - Invoke("nowstart" , 0.34f);
            canvascont1.jump = false;
        //    Invoke("enablethen" , 1f);
        }
        if(canvascont1.sitdown == true){
          //  disableObsCores();
            canvascont1.SitOb = false;
            disobscatcher = false;
            stopEve = false;
            Destroy(arrow , 2f);
           //- Cameramover.camstop = false;
          //-  lion.SetBool("run" , false);
           //- lion.SetBool("crouch" , true);
           //- Invoke("throwarrow" , 0.5f);
           // Invoke("enablethen" , 1f);
            canvascont1.sitdown = false;
            
            
        }

      /*  if(catchers.passed == true){
            Cameramover.camstop = true;
            lion.SetBool("crouch" , false);
            Destroy(arrow , 2f);
            nowstart();
           // stopEve = false;
            catchers.passed = false;
        }*/
        if(canvascont1.walk == true){
          //  disableObsCores();
            canvascont1.WalkOb = false;
            disobscatcher = false;
            stopEve = false;
          //  lion.SetBool("run" , false);
          //  lion.SetBool("walk" , true);
           // Cameramover.speed2 = 4f;
          // Cameramover.speed2 = 8f;
            canvascont1.walk = false;
            Destroy(eggy , 3f);
          //  Invoke("enablethen" , 1f);
        }
       /* if(lastpass == true){
            lion.SetBool("walk" , false);
            nowstart();
          //  Cameramover.speed2 = 8f;
            Destroy(eggy , 3f);
            lastpass = false;
        }*/
        if(canvascont1.sprint == true){
           // disableObsCores();
            canvascont1.RunOb = false;
            disobscatcher = false;
            stopEve = false;
          //  lion.SetBool("run" , false);
         //   lion.SetBool("sprint" , true);
          //  Invoke("fallem" , 0.5f);
          //  Cameramover.speed2 = 10f;
           // calllet = true;
            canvascont1.sprint = false;
            Destroy( fally , 4f);
         //   Invoke("enablethen" , 1f);
        }
        if(calllet == true){
            Invoke("fallfinished" , 1.5f);
            calllet = false;
       }
      /*  if(lastfalll == true){
            lion.SetBool("sprint" , false);
            nowstart();
           // Cameramover.speed2 = 8f;
            Destroy( fally , 4f);
            lastfalll = false;
        }*/
        if(canvascont1.hitted == true){
            disobscatcher = false;
            Cameramover.globalblurrate = 0f;
            stopEve = false;
            Cameramover.camstop = false;
            lion.SetBool("run" , false);
            AnimContAfterHit();
            lion.SetTrigger("hit");
            Invoke("nowstart" , 0.5f);
            Invoke("camstart" , 0.5f);
            canvascont1.hitted = false;
          //  Invoke("enablethen" , 1f);
        }
        if(hitObstacles1.charhitted == true){
            RedScreen.SetTrigger("red");
            disableObsCores();
            Cameramover.globalblurrate = 0f;
            thoughtui.SetActive(false);
            stopEve = false;
            Cameramover.camstop = false;
            lion.SetBool("run" , false);
            AnimContAfterHit();
            lion.SetTrigger("hit");
            if(canvascont1.score > 50 ){
                canvascont1.score -= 10;
            }
            else if(canvascont1.score <= 50){
                canvascont1.diedd = true;
            }
            Invoke("nowstart" , 0.8f);
            Invoke("camstart" , 0.8f);
            hitObstacles1.charhitted = false;
        }
        if(canvascont1.diedd == true){
            theme.Stop();
            disobscatcher = false;
            Cameramover.globalblurrate = 0f;
            stopEve = false;
            Cameramover.camstop = false;
            ScoreBack.SetActive(false);
            lion.SetBool("run" , false);
            lion.SetBool("die" , true);
            resultui.SetActive(true);
            canvascont1.setscore = true;
            resultanim.SetBool("died" , true);
            canvascont1.diedd = false;
           
        }
        if(finished == true){
            theme.Stop();
            Cameramover.camstop = false;
            lion.SetBool("run" , false);
            ScoreBack.SetActive(false);
            if(canvascont1.score == 60){
                resultui.SetActive(true);
                resultanim.SetBool("one" , true);
                Invoke("showscore" , 2f);
            }
            else if(canvascont1.score == 70){
                 resultui.SetActive(true);
                 resultanim.SetBool("two" , true);
                 Invoke("showscore" , 2f);
            }
            else if(canvascont1.score == 80){
                resultui.SetActive(true);
                resultanim.SetBool("three" , true);
                Invoke("showscore" , 2f);
            }
            else if(canvascont1.score == 50){
                resultui.SetActive(true);
                resultanim.SetBool("none" , true);
                Invoke("showscore" , 1f);
            }
            
        }
    }
    void SetWanters(){
        applewanters = new string[4];
        orangewanters = new string[4];
        carrotwanters = new string[4];
        banwanters = new string[4];
        applewanters[0] = canvascont1.charName1[0];
        applewanters[1] = canvascont1.charName2[0];
        applewanters[2] = canvascont1.charName3[0];
        orangewanters[0] = canvascont1.charName1[1];
        orangewanters[1] = canvascont1.charName2[1];
        orangewanters[2] = canvascont1.charName3[1];
        carrotwanters[0] = canvascont1.charName1[2];
        carrotwanters[1] = canvascont1.charName2[2];
        carrotwanters[2] = canvascont1.charName3[2];
        banwanters[0] = canvascont1.charName1[3];
        banwanters[1] = canvascont1.charName2[3];
        banwanters[2] = canvascont1.charName3[3];
    }
    void fallem(){
        forfallers.SetBool(fallingObstc[f] , true);
    }
    void throwarrow(){
        arrow.transform.Translate(Vector2.right * arrowspeed * Time.deltaTime);
    }

    void AnimContAfterHit(){
        if(canvascont1.SitOb == true){
            Destroy(arrow);
            canvascont1.SitOb = false;
        }
        else if(canvascont1.RunOb == true){
            forfallers.SetBool(fallingObstc[f] , true);
            calllet = true;
            Destroy(fally , 1.6f);
            canvascont1.RunOb = false;
        }
        else if(canvascont1.WalkOb == true){
            canvascont1.WalkOb = false;
        }
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
        finalscore.GetComponent<Text>().text = canvascont1.score.ToString();
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
        if(other.gameObject.tag == "apple"){
          //  oc = 0;
            thoughtui.SetActive(true);
            obsjump = other.gameObject;
            Cameramover.globalblurrate = 4f;
            stopEve = true;
            WordText.text = applewanters[aw] + canvascont1.textsJ[0]; 
            aw += 1;
            canvascont1.applehit = true;
            print(canvascont1.applehit);
        }
        else if(other.gameObject.tag == "orange"){
            canvascont1.SitOb = true;
             Cameramover.globalblurrate = 4f;
            stopEve = true;
            arrow = other.gameObject;
            thoughtui.SetActive(true);
            WordText.text = orangewanters[ow] + canvascont1.textsJ[1]; 
            ow += 1;
            canvascont1.sitdownhit = true;
            print(canvascont1.sitdownhit);
        }
        else if(other.gameObject.tag == "carrot"){
            canvascont1.WalkOb = true;
            Cameramover.globalblurrate = 4f;
            eggy = other.gameObject;
            stopEve = true;
            thoughtui.SetActive(true);
            WordText.text = carrotwanters[cw] + canvascont1.textsJ[2];
            cw += 1;
            canvascont1.walkhit = true;
            print(canvascont1.walkhit);
        }
        else if(other.gameObject.tag == "lastegg"){
            lastpass = true;
        }
        else if(other.gameObject.tag == "banana"){
            canvascont1.RunOb = true;
            Cameramover.globalblurrate = 4f;
            stopEve = true;
            thoughtui.SetActive(true);
            WordText.text = banwanters[bw] + canvascont1.textsJ[3];
            bw += 1;
            fally = other.gameObject;
            canvascont1.sprinthit = true;
            print(canvascont1.sprinthit);
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
