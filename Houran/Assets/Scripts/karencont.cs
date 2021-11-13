using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class karencont : MonoBehaviour
{
    public static bool stopEve = true;
    public static bool begin = false;
    bool lastpass = false , lastfalll = false , calllet = false;
    public float arrowspeed;
    public Animator lion , jumper , resultanim;
    public GameObject thoughtui , resultui , numberui , finalscore , secscore;
    bool jumpguid = true , sprintguid = true , sitguid = true , walkguid = true ;
    bool finished = false;
    public GameObject[] guides;
    GameObject arrow;
    GameObject eggy , fally;
    int i = 0 , j = 0 , k = 0;
    public GameObject[] fallers , numbers;
    
    // Start is called before the first frame update
    void awake(){
        stopEve = true;
        begin = false;

    }
    void Start()
    {
        InvokeRepeating("count" , 0f , 1f);
        Invoke("nowstart" , 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if(begin == true){
            if(stopEve == false){
                lion.SetBool("run" , true);
            }
            begin = false;
        }

        

        if(stopEve == true){
            lion.SetBool("run" , false);
        }

        if(canvascont.jump == true){
            stopEve = false;
            jumper.SetTrigger("jump");
            lion.SetTrigger("jump");
            
            Invoke("nowstart" , 0.34f);
            canvascont.jump = false;
        }
        if(canvascont.sitdown == true){
            lion.SetBool("crouch" , true);
            arrow.transform.Translate(Vector2.right * arrowspeed * Time.deltaTime);
            
        }

        if(catchers.passed == true){
            lion.SetBool("crouch" , false);
            Destroy(arrow , 2f);
            nowstart();
           // stopEve = false;
            catchers.passed = false;
        }
        if(canvascont.walk == true){
            lion.SetBool("walk" , true);
            stopEve = false;
            Cameramover.speed2 = 4f;
            canvascont.walk = false;
        }
        if(lastpass == true){
            lion.SetBool("walk" , false);
            nowstart();
            Cameramover.speed2 = 8f;
            Destroy(eggy , 3f);
            lastpass = false;
        }
        if(canvascont.sprint == true){
            lion.SetBool("sprint" , true);
            stopEve = false;
            Cameramover.speed2 = 10f;
            calllet = true;
            canvascont.sprint = false;
        }
        if(calllet == true){
            InvokeRepeating("letThemFall" , 0.1f , 0.3f);
        }
        if(lastfalll == true){
            lion.SetBool("sprint" , false);
            nowstart();
            Cameramover.speed2 = 8f;
            Destroy( fally , 4f);
            lastfalll = false;
        }
        if(canvascont.hitted == true){
            lion.SetTrigger("hit");
            Invoke("nowstart" , 0.5f);
            canvascont.hitted = false;
        }
        if(canvascont.diedd == true){
            secscore.SetActive(false);
            lion.SetBool("die" , true);
            stopEve = true;
            resultui.SetActive(true);
            canvascont.setscore = true;
            resultanim.SetBool("died" , true);
            canvascont.diedd = false;
        }
        if(finished == true){
            secscore.SetActive(false);
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
    void showscore(){
        finalscore.SetActive(true);
        finalscore.GetComponent<Text>().text = canvascont.score.ToString();
    }
    void count(){
        if(j <3){
            numbers[j].SetActive(true);
             j += 1;
        }
        else if(j >=3){
            numberui.SetActive(false);
        }
        
    }

    void nowstart(){
        stopEve = false;
        begin = true;
    }
    void letThemFall(){
        if(i < 5){
            fallers[i].GetComponent<Rigidbody>().isKinematic = false;
            fallers[i].GetComponent<Rigidbody>().useGravity = true;
            i += 1;
        }
        else if(i > 5){
            calllet = false;

        }
        
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "obstaclej"){
            stopEve = true;
            thoughtui.SetActive(true);
            
            if(jumpguid == true){
                jumpguid = false;
                guides[0].SetActive(true);
            }
            canvascont.jumphit = true;
            print(canvascont.jumphit);
        }
        else if(other.gameObject.tag == "arrowup"){
            stopEve = true;
            arrow = other.gameObject;
            thoughtui.SetActive(true);
            if(sitguid == true){
                sitguid = false;
                 guides[1].SetActive(true);
            }
           
            
            canvascont.sitdownhit = true;
            print(canvascont.sitdownhit);
        }
        else if(other.gameObject.tag == "firstegg"){
            eggy = other.gameObject;
            stopEve = true;
            thoughtui.SetActive(true);
            if(walkguid == true){
                walkguid = false;
                guides[2].SetActive(true);
            }
            canvascont.walkhit = true;
            print(canvascont.walkhit);
        }
        else if(other.gameObject.tag == "lastegg"){
            lastpass = true;
        }
        else if(other.gameObject.tag == "firstfall"){
            stopEve = true;
            thoughtui.SetActive(true);
            if(sprintguid == true){
                sprintguid = false;
                guides[3].SetActive(true);
            }
            fally = other.gameObject;
            canvascont.sprinthit = true;
            print(canvascont.sprinthit);
        }
        else if(other.gameObject.tag == "lastfall"){
            lastfalll = true;
        }
        else if(other.gameObject.tag == "flag"){
            stopEve = true;
            resultui.SetActive(true);
            finished = true;
        }
    }

    
}
