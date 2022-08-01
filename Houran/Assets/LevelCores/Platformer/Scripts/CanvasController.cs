using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    public static string levelname;
    public static GameObject Stairs;
    public static GameObject switchs;
    public static GameObject changeswitch , teleeffect , secswitch;
    public static Animator stairlight , stairss;
    bool now = false;
    public Transform player , thispos;
    public GameObject menu , joy , menuopener;
    public string namescene;
    public static int forPos;
    public PlayerMovementInPlatformer playerobject;
   // public PlayerMovementInPlatformer platformerplayer;
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(){
        SaveSystem.SavePlayer(playerobject);
       // platformerplayer.setPastPos(forPos);
        SceneManager.LoadScene(levelname);
    }
    
    void disswitch(){
        switchs.GetComponent<SpriteRenderer>().enabled = true;
        changeswitch.SetActive(false);
        Stairs.SetActive(false);
    }
    public void ActiveStairs(){
        if(now == false){
            Stairs.SetActive(true);
            switchs.GetComponent<SpriteRenderer>().enabled = false;
            changeswitch.SetActive(true);
            secswitch.SetActive(true);
            now = true;
        }
        else if(now == true){
           // Stairs.SetActive(false);
         //   switchs.GetComponent<SpriteRenderer>().enabled = true;
          //  changeswitch.SetActive(false);
            stairlight.SetBool("back" , true);
            stairss.SetBool("hide" , true);
            Invoke("disswitch" , 1f);
            secswitch.SetActive(false);
            now = false;
        }
    }

    void setTelePosition(){
        player.position = thispos.position;
        teleeffect.SetActive(false);
    }
    public void Teleportnow(){
        teleeffect.SetActive(true);
        Invoke("setTelePosition" , 1.5f);
    }


    public void OpenMenu(){
        Time.timeScale = 0;
        menu.SetActive(true);
        joy.SetActive(false);
        menuopener.SetActive(false);
    }   
    public void CloseMenu(){
        Time.timeScale = 1;
        menu.SetActive(false);
        joy.SetActive(true);
        menuopener.SetActive(true);
    }
    public void Gototree(){
        Time.timeScale = 1;
        SceneManager.LoadScene(namescene);
    }
}
