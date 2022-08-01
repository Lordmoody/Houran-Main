using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class karencontVoice : MonoBehaviour
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

    public GameObject thoughtui , resultui , numberui , finalscore;
    bool jumpguid = true , sprintguid = true , sitguid = true , walkguid = true ;
    bool finished = false;
    GameObject arrow;
    GameObject eggy , fally , obsjump;
    int i = 0 , j = 0 , k = 0 , m = 5;
    public GameObject[] fallers , numbers;
    public float animspeedslow , animspeedfast , cameraspeedslow , cameraspeedfast;
    public Animator RedScreen;
    public GameObject ScoreBack;
    public Text ButtonText;
    [System.Serializable]
    public class Player{
        public string dial;
    }

    [System.Serializable]
    public class PlayerList{
        public Player[] Voice;
    }
    
    public PlayerList myPlayerList = new PlayerList();
    public string gamePath;
    public TextAsset textJasoneng;
    public SpeechControllerVoiceBase speechy;
    
    // Start is called before the first frame update
    void Awake(){
       gamePath = Application.dataPath + "/Resources";
       textJasoneng = Resources.Load<TextAsset>("JASONtext");
       myPlayerList = JsonUtility.FromJson<PlayerList>(textJasoneng.text);
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
        if(canvascontVoice.jump == true){
            disobscatcher = false;
            Destroy(obsjump , 2f);
            stopEve = false;
            lion.SetBool("run" , false);
            jumper.SetTrigger("jump");
            lion.SetTrigger("jump");
            Invoke("nowstart" , 0.34f);
            canvascontVoice.jump = false;
         //   Invoke("enablethen" , 1f);
        }
        if(canvascontVoice.sitdown == true){
            canvascontVoice.SitOb = false;
            disobscatcher = false;
            stopEve = false;
            Cameramover.camstop = false;
            lion.SetBool("run" , false);
            lion.SetBool("crouch" , true);
            Invoke("throwarrow" , 0.5f);
         //   Invoke("enablethen" , 1f);
            
            
        }

        if(catchers.passed == true){
            Cameramover.camstop = true;
            lion.SetBool("crouch" , false);
            Destroy(arrow , 2f);
            nowstart();
           // stopEve = false;
            catchers.passed = false;
        }
        if(canvascontVoice.walk == true){
            canvascontVoice.WalkOb = false;
            disobscatcher = false;
            stopEve = false;
            lion.SetBool("run" , false);
            lion.SetBool("walk" , true);
            Cameramover.speed2 = 4f;
            canvascontVoice.walk = false;
         //   Invoke("enablethen" , 1f);
        }
        if(lastpass == true){
            lion.SetBool("walk" , false);
            nowstart();
          //  Cameramover.speed2 = 8f;
            Destroy(eggy , 3f);
            lastpass = false;
        }
        if(canvascontVoice.sprint == true){
            canvascontVoice.RunOb = false;
            disobscatcher = false;
            stopEve = false;
            lion.SetBool("run" , false);
            lion.SetBool("sprint" , true);
            Invoke("fallem" , 0.5f);
            Cameramover.speed2 = 10f;
            calllet = true;
            canvascontVoice.sprint = false;
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
        if(canvascontVoice.hitted == true){
            disobscatcher = false;
            Cameramover.globalblurrate = 0f;
            stopEve = false;
            Cameramover.camstop = false;
            lion.SetBool("run" , false);
            AnimContAfterHit();
            lion.SetTrigger("hit");
            Invoke("nowstart" , 0.5f);
            Invoke("camstart" , 0.5f);
            canvascontVoice.hitted = false;
           // Invoke("enablethen" , 1f);
        }
        if(hitObstaclesVoice.charhitted == true){
            RedScreen.SetTrigger("red");
            disableObsCores();
            Cameramover.globalblurrate = 0f;
            thoughtui.SetActive(false);
            stopEve = false;
            Cameramover.camstop = false;
            lion.SetBool("run" , false);
            AnimContAfterHit();
            lion.SetTrigger("hit");
            if(canvascontVoice.score > 50 ){
                canvascontVoice.score -= 10;
            }
            else if(canvascontVoice.score <= 50){
                canvascontVoice.diedd = true;
            }
            Invoke("nowstart" , 0.8f);
            Invoke("camstart" , 0.8f);
            hitObstaclesVoice.charhitted = false;
        }
        if(canvascontVoice.diedd == true){
            theme.Stop();
            disobscatcher = false;
            Cameramover.globalblurrate = 0f;
            stopEve = false;
            Cameramover.camstop = false;
            ScoreBack.SetActive(false);
            lion.SetBool("run" , false);
            lion.SetBool("die" , true);
            resultui.SetActive(true);
            canvascontVoice.setscore = true;
            resultanim.SetBool("died" , true);
            canvascontVoice.diedd = false;
           
        }
        if(finished == true){
            theme.Stop();
            Cameramover.camstop = false;
            lion.SetBool("run" , false);
            ScoreBack.SetActive(false);
            if(canvascontVoice.score == 60){
                resultui.SetActive(true);
                resultanim.SetBool("one" , true);
                Invoke("showscore" , 2f);
            }
            else if(canvascontVoice.score == 70){
                 resultui.SetActive(true);
                 resultanim.SetBool("two" , true);
                 Invoke("showscore" , 2f);
            }
            else if(canvascontVoice.score == 80){
                resultui.SetActive(true);
                resultanim.SetBool("three" , true);
                Invoke("showscore" , 2f);
            }
            else if(canvascontVoice.score == 50){
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
        if(canvascontVoice.SitOb == true){
            Destroy(arrow);
            canvascontVoice.SitOb = false;
        }
        else if(canvascontVoice.RunOb == true){
            forfallers.SetBool(fallingObstc[f] , true);
            calllet = true;
            Destroy(fally , 1.6f);
            canvascontVoice.RunOb = false;
        }
        else if(canvascontVoice.WalkOb == true){
            canvascontVoice.WalkOb = false;
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
        finalscore.GetComponent<Text>().text = canvascontVoice.score.ToString();
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
            if(managertree.BaseLang == "Persian"){
                ButtonText.text = myPlayerList.Voice[0].dial;
            }
            else if(managertree.BaseLang == "English"){
                ButtonText.text = myPlayerList.Voice[1].dial;
            }
            speechy.StartListening();
            theme.Pause();
            obsjump = other.gameObject;
            Cameramover.globalblurrate = 4f;
            stopEve = true;
            thoughtui.SetActive(true);
            canvascontVoice.jumphit = true;
            print(canvascontVoice.jumphit);
        }
        else if(other.gameObject.tag == "arrowup"){
            if(managertree.BaseLang == "Persian"){
                ButtonText.text = myPlayerList.Voice[0].dial;
            }
            else if(managertree.BaseLang == "English"){
                ButtonText.text = myPlayerList.Voice[1].dial;
            }
            speechy.StartListening();
            theme.Pause();
            canvascontVoice.SitOb = true;
             Cameramover.globalblurrate = 4f;
            stopEve = true;
            arrow = other.gameObject;
            thoughtui.SetActive(true);
            if(sitguid == true){
                sitguid = false;
              //   guides[1].SetActive(true);
            }
            canvascontVoice.sitdownhit = true;
            print(canvascontVoice.sitdownhit);
        }
        else if(other.gameObject.tag == "firstegg"){
            if(managertree.BaseLang == "Persian"){
                ButtonText.text = myPlayerList.Voice[0].dial;
            }
            else if(managertree.BaseLang == "English"){
                ButtonText.text = myPlayerList.Voice[1].dial;
            }
            speechy.StartListening();
            theme.Pause();
            canvascontVoice.WalkOb = true;
             Cameramover.globalblurrate = 4f;
            eggy = other.gameObject;
            stopEve = true;
            thoughtui.SetActive(true);
            if(walkguid == true){
                walkguid = false;
              //  guides[2].SetActive(true);
            }
            canvascontVoice.walkhit = true;
            print(canvascontVoice.walkhit);
        }
        else if(other.gameObject.tag == "lastegg"){
            lastpass = true;
        }
        else if(other.gameObject.tag == "firstfall"){
            if(managertree.BaseLang == "Persian"){
                ButtonText.text = myPlayerList.Voice[0].dial;
            }
            else if(managertree.BaseLang == "English"){
                ButtonText.text = myPlayerList.Voice[1].dial;
            }
            speechy.StartListening();
            theme.Pause();
            canvascontVoice.RunOb = true;
            print("fall" + canvascontVoice.RunOb);
             Cameramover.globalblurrate = 4f;
            stopEve = true;
            thoughtui.SetActive(true);
            if(sprintguid == true){
                sprintguid = false;
              //  guides[3].SetActive(true);
            }
            fally = other.gameObject;
            canvascontVoice.sprinthit = true;
            print(canvascontVoice.sprinthit);
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
