using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class karencontDD : MonoBehaviour
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
    GameObject ThisBridge , thisfire , thisstone;


    [System.Serializable]
    public class UIText{
        public string dial;
        public string word;
    }

    [System.Serializable]
    public class UIList{
        public UIText[] uiper;
    }
    [System.Serializable]
    public class UIListen{
        public UIText[] uien;
    }
    [System.Serializable]
    public class UIListwper{
        public UIText[] perword;
    }
    [System.Serializable]
    public class UIListwen{
        public UIText[] enword;
    }
    
    public UIList myuiList = new UIList();
    public UIListen myuiListen = new UIListen();
    public UIListwper myuiListwper = new UIListwper();
    public UIListwen myuiListwen = new UIListwen();
    public string gamePath;
    public TextAsset Uitextt;
    public Text DialGuid;
    public canvascontDD canvascontDDd;
    
    // Start is called before the first frame update
    void Awake(){
       gamePath = Application.dataPath + "/Resources";
       Uitextt = Resources.Load<TextAsset>("JsonForDDUI");
       myuiList = JsonUtility.FromJson<UIList>(Uitextt.text);
       myuiListen = JsonUtility.FromJson<UIListen>(Uitextt.text);
       myuiListwper = JsonUtility.FromJson<UIListwper>(Uitextt.text);
       myuiListwen = JsonUtility.FromJson<UIListwen>(Uitextt.text);
        stopEve = true;
        begin = false;
        disobscatcher = true;

    }
    void Start()
    {
        if(managertree.DestLang == "Persian"){
            canvascontDDd.jumpt.text = myuiListwper.perword[0].word;
            canvascontDD.ddread[0] = myuiListwper.perword[0].word;
           canvascontDDd.sitt.text = myuiListwper.perword[1].word;
           canvascontDD.ddread[1] = myuiListwper.perword[1].word;
            canvascontDDd.walkt.text = myuiListwper.perword[2].word;
            canvascontDD.ddread[2] = myuiListwper.perword[2].word;
           canvascontDDd.runt.text = myuiListwper.perword[3].word;
           canvascontDD.ddread[3] = myuiListwper.perword[3].word;
        }
        else if(managertree.DestLang == "English"){
            canvascontDDd.jumpt.text = myuiListwen.enword[0].word;
            canvascontDD.ddread[0] = myuiListwen.enword[0].word;
            canvascontDDd.sitt.text = myuiListwen.enword[1].word;
            canvascontDD.ddread[1] = myuiListwen.enword[1].word;
            canvascontDDd.walkt.text = myuiListwen.enword[2].word;
            canvascontDD.ddread[2] = myuiListwen.enword[2].word;
            canvascontDDd.runt.text = myuiListwen.enword[3].word;
            canvascontDD.ddread[3] = myuiListwen.enword[3].word;
        }
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
           theme.volume = 0.05f;
           lion.speed = animspeedslow;
           Cameramover.speed2 = cameraspeedslow;
        }
        else if(stopEve == false){
            theme.pitch = 1;
            theme.volume = 0.2f;
            lion.speed = animspeedfast;
            Cameramover.speed2 = cameraspeedfast;
        }
        if(canvascontDD.jump == true){
            disobscatcher = false;
            Destroy(obsjump , 2f);
            stopEve = false;
            ThisBridge.GetComponent<Animator>().SetBool("bridge" , true);
         //   lion.SetBool("run" , false);
          //  jumper.SetTrigger("jump");
         //   lion.SetTrigger("jump");
        //    Invoke("nowstart" , 0.34f);
            canvascontDD.jump = false;
           // Invoke("enablethen" , 1f);
        }
        if(canvascontDD.sitdown == true){
            canvascontDD.SitOb = false;
            disobscatcher = false;
            stopEve = false;
            thisfire.GetComponent<Animator>().SetBool("off" , true);
            Destroy(arrow , 2f);
          //  Cameramover.camstop = false;
           // lion.SetBool("run" , false);
          //  lion.SetBool("crouch" , true);
          //  Invoke("throwarrow" , 0.5f);
          //  Invoke("enablethen" , 1f);
            
            
        }

       /* if(catchersDD.passed == true){
            Cameramover.camstop = true;
            lion.SetBool("crouch" , false);
            Destroy(arrow , 2f);
            nowstart();
           // stopEve = false;
            catchersDD.passed = false;
        }*/
        if(canvascontDD.walk == true){
            canvascontDD.WalkOb = false;
            disobscatcher = false;
            stopEve = false;
           // lion.SetBool("run" , false);
           // lion.SetBool("walk" , true);
           // Cameramover.speed2 = 4f;
           Cameramover.speed2 = 8f;
            canvascontDD.walk = false;
            thisstone.GetComponent<Animator>().SetBool("up" , true);
            Destroy(eggy , 3f);
           // Invoke("enablethen" , 1f);
        }
      /*  if(lastpass == true){
            lion.SetBool("walk" , false);
            nowstart();
          //  Cameramover.speed2 = 8f;
            Destroy(eggy , 3f);
            lastpass = false;
        }*/
        if(canvascontDD.sprint == true){
            canvascontDD.RunOb = false;
            disobscatcher = false;
            stopEve = false;
            lion.SetBool("run" , false);
            lion.SetBool("sprint" , true);
            Invoke("fallem" , 0.5f);
            Cameramover.speed2 = 10f;
            calllet = true;
            canvascontDD.sprint = false;
           // Invoke("enablethen" , 1f);
        }
        if(calllet == true){
            Invoke("fallfinished" , 3f);
            calllet = false;
        }
        if(lastfalll == true){
            lion.SetBool("sprint" , false);
            nowstart();
           // Cameramover.speed2 = 8f;
            Destroy( fally , 4f);
            lastfalll = false;
        }
        if(canvascontDD.hitted == true){
            disobscatcher = false;
            Cameramover.globalblurrate = 0f;
            stopEve = false;
            Cameramover.camstop = false;
            lion.SetBool("run" , false);
            AnimContAfterHit();
            lion.SetTrigger("hit");
            Invoke("nowstart" , 0.5f);
            Invoke("camstart" , 0.5f);
            canvascontDD.hitted = false;
          //  Invoke("enablethen" , 1f);
        }
        if(hitObstaclesDD.charhitted == true){
            RedScreen.SetTrigger("red");
            disableObsCores();
            Cameramover.globalblurrate = 0f;
            thoughtui.SetActive(false);
            stopEve = false;
            Cameramover.camstop = false;
            lion.SetBool("run" , false);
            AnimContAfterHit();
            lion.SetTrigger("hit");
            if(canvascontDD.score > 50 ){
                canvascontDD.score -= 10;
            }
            else if(canvascontDD.score <= 50){
                canvascontDD.diedd = true;
            }
            Invoke("nowstart" , 0.8f);
            Invoke("camstart" , 0.8f);
            hitObstaclesDD.charhitted = false;
        }
        if(canvascontDD.diedd == true){
            canvascontDDd.sliderr.SetActive(false);
            canvascontDDd.menuicon.SetActive(false);
            theme.Stop();
            disobscatcher = false;
            Cameramover.globalblurrate = 0f;
            stopEve = false;
            Cameramover.camstop = false;
            ScoreBack.SetActive(false);
            lion.SetBool("run" , false);
            lion.SetBool("die" , true);
            resultui.SetActive(true);
            canvascontDD.setscore = true;
            resultanim.SetBool("died" , true);
            canvascontDD.diedd = false;
           
        }
        if(finished == true){
            canvascontDDd.sliderr.SetActive(false);
            canvascontDDd.menuicon.SetActive(false);
            theme.Stop();
            Cameramover.camstop = false;
            lion.SetBool("run" , false);
            ScoreBack.SetActive(false);
            if(canvascontDD.score == 60){
                resultui.SetActive(true);
                resultanim.SetBool("one" , true);
                Invoke("showscore" , 2f);
            }
            else if(canvascontDD.score == 70){
                 resultui.SetActive(true);
                 resultanim.SetBool("two" , true);
                 Invoke("showscore" , 2f);
            }
            else if(canvascontDD.score == 80){
                resultui.SetActive(true);
                resultanim.SetBool("three" , true);
                Invoke("showscore" , 2f);
            }
            else if(canvascontDD.score == 50){
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
        if(canvascontDD.SitOb == true){
            Destroy(arrow);
            canvascontDD.SitOb = false;
        }
        else if(canvascontDD.RunOb == true){
            forfallers.SetBool(fallingObstc[f] , true);
            calllet = true;
            Destroy(fally , 1.6f);
            canvascontDD.RunOb = false;
        }
        else if(canvascontDD.WalkOb == true){
            canvascontDD.WalkOb = false;
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
        finalscore.GetComponent<Text>().text = canvascontDD.score.ToString();
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
            canvascontDD.answer = "Bridge";
            if(managertree.BaseLang == "Persian"){
                DialGuid.text = myuiList.uiper[0].dial;
            }
            else if(managertree.BaseLang == "English"){
                DialGuid.text = myuiListen.uien[0].dial;
            }
            obsjump = other.gameObject;
            canvascontDDd.bookanim.SetInteger("book" , 0);
            ThisBridge = other.gameObject;
            Cameramover.globalblurrate = 4f;
            stopEve = true;
            thoughtui.SetActive(true);
            canvascontDD.jumphit = true;
            print(canvascontDD.jumphit);
        }
        else if(other.gameObject.tag == "arrowup"){
            canvascontDD.answer = "TurnOff";
            if(managertree.BaseLang == "Persian"){
                DialGuid.text = myuiList.uiper[1].dial;
            }
            else if(managertree.BaseLang == "English"){
                DialGuid.text = myuiListen.uien[1].dial;
            }
            thisfire = other.gameObject;
            canvascontDDd.bookanim.SetInteger("book" , 0);
            canvascontDD.SitOb = true;
            Cameramover.globalblurrate = 4f;
            stopEve = true;
            arrow = other.gameObject;
            thoughtui.SetActive(true);
            canvascontDD.sitdownhit = true;
            print(canvascontDD.sitdownhit);
        }
        else if(other.gameObject.tag == "firstegg"){
            canvascontDD.answer = "walk";
            if(managertree.BaseLang == "Persian"){
                DialGuid.text = myuiList.uiper[2].dial;
            }
            else if(managertree.BaseLang == "English"){
                DialGuid.text = myuiListen.uien[2].dial;
            }
            thisstone = other.gameObject;
            canvascontDDd.bookanim.SetInteger("book" , 0);
            canvascontDD.WalkOb = true;
             Cameramover.globalblurrate = 4f;
            eggy = other.gameObject;
            stopEve = true;
            thoughtui.SetActive(true);
            canvascontDD.walkhit = true;
            print(canvascontDD.walkhit);
        }
        else if(other.gameObject.tag == "lastegg"){
            lastpass = true;
        }
        else if(other.gameObject.tag == "firstfall"){
            canvascontDD.answer = "sprint";
            if(managertree.BaseLang == "Persian"){
                DialGuid.text = myuiList.uiper[3].dial;
            }
            else if(managertree.BaseLang == "English"){
                DialGuid.text = myuiListen.uien[3].dial;
            }
            canvascontDD.RunOb = true;
            canvascontDDd.bookanim.SetInteger("book" , 0);
            print("fall" + canvascontDD.RunOb);
             Cameramover.globalblurrate = 4f;
            stopEve = true;
            thoughtui.SetActive(true);
            if(sprintguid == true){
                sprintguid = false;
              //  guides[3].SetActive(true);
            }
            fally = other.gameObject;
            canvascontDD.sprinthit = true;
            print(canvascontDD.sprinthit);
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
