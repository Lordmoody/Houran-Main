using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerMovementInPlatformer : MonoBehaviour
{
    public CharacterController2Dp controller;
    float horziMove = 0f;
    public float runSpeed = 40f;
     bool jump = false;
    bool crouch = false;
    public Animator animator;
    public Joystick joystick;
    public float JoystickSensivity = 0.2f , jumpSensivity = 0.5f;
    [System.Serializable]
    public class Player{
        public string name;
    }

    [System.Serializable]
    public class PlayerList{
        public Player[] player;
    }
    
    public PlayerList myPlayerList = new PlayerList();
    public string gamePath;
    public TextAsset textJasoneng;
    public Transform[] flags;
    int i = 0;
    public static bool firsttime = true;
    public Transform player;
    string g;
    public int thisplayertime = 0; 
    public GameObject thisPlayerr;
    bool nowgo = false , dofunction = true;
    // Start is called before the first frame update

    // Update is called once per frame
    void Awake(){
        
        gamePath = Application.persistentDataPath + "/Resources";
        textJasoneng = Resources.Load<TextAsset>("JASONtext3");
        myPlayerList = JsonUtility.FromJson<PlayerList>(textJasoneng.text);
       
        
        
    }
    void Start(){
        
         PlayerData data = SaveSystem.LoadPlayer();
        if(SaveSystem.notFound == true){
            Debug.Log("Not Found Yet.");
        }
        else{
            thisplayertime = data.playtime;
            if(thisplayertime == 0){
                Debug.Log("First Time");
                thisplayertime = 1;
                SaveSystem.SavePlayer(this);
            }
            else if(thisplayertime == 1){
                Vector3 positionnn;
                positionnn.x = data.position[0];
                positionnn.y = data.position[1];
                positionnn.z = data.position[2];

                thisPlayerr.transform.position = positionnn;
             }
             
        }
        Time.timeScale = 1;
        
    }
    void Update()
    {
     
       // horziMove = Input.GetAxisRaw("Horizontal") * runSpeed;
      if(joystick.Horizontal >= JoystickSensivity){
           horziMove = runSpeed;
       }
       else if(joystick.Horizontal <= -JoystickSensivity){
           horziMove = -runSpeed;
       }else{
           horziMove = 0;
       }
       float verticalMove = joystick.Vertical;

        animator.SetFloat("speed" , Mathf.Abs(horziMove)); 
       /* if(Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("jump" , true);
        }
        if(verticalMove >= jumpSensivity ){
            jump = true;
            animator.SetBool("jump" , true);
        }*/
        /*if(Input.GetButtonDown("Crouch")){
            crouch = true;
        }
        else if(Input.GetButtonUp("Crouch")){
            crouch = false;
        }*/
        if(verticalMove <= -jumpSensivity){
            crouch = true;
        }else{
            crouch = false;
        }
    }
    
    public void OnLanding(){
        animator.SetBool("jump" , false);
    }
    public void OnCrouching(bool isCrouching){
        animator.SetBool("crouch" , isCrouching);
    }

    void FixedUpdate(){
            controller.Move(horziMove * Time.fixedDeltaTime , crouch , jump);
            jump = false;
            
            
        
        
      //  crouch = false;
    }
     void Starter(){
        Time.timeScale = 1;
        Debug.Log("done");
    }
   
   /* public void setPastPos(int p){
        string positionn = p.ToString();
        myPlayerList.player[1].name = positionn;
        positionn = JsonUtility.ToJson(myPlayerList);
        File.WriteAllText(gamePath + "/JASONtext3.txt" , positionn);
    }*/

}
