using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovementP : MonoBehaviour
{
    public CharacterController2Dp controller;
    public Animator animator;
    public float runSpeed;
    [HideInInspector] public float horizontalMove = 0f;
    bool jump = false;
    bool crouch= false;
    bool jumped = false;
    bool fell = false;
    public ParticleSystem runParticle;
    public ParticleSystem JumpParticle;
    public AudioSource runs , jumps , crouchMove , pushingSound;
    bool running = false , falling = false;
    public static float HorizValue = 0f;
    public static bool JumpValue = false , CrouchValue = false  , PlayerGrounded;
    
    [HideInInspector] public bool IsPushing = false;
    public static bool BounceLanded;
    public AudioSource BounceSound;


    //For SaveSystem Only
    public PlayerHealth healthInstance;
    public ItemController itemControllerInstance;

    [HideInInspector]public string langCodeSave;
    [HideInInspector]public int Lvlsave;


    public GameObject FreezeSheild;
    public ParticleSystem IceHit;
    public AudioSource freezsound , icebreak;
   [HideInInspector] public bool Freezed = false;

    ///end
    void Awake(){
        Debug.Log(Application.persistentDataPath);
        if(this.gameObject.activeSelf == true){
            SaveDatasPlayer.LoadItToThem(this);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHealth.playerDied == false && Freezed == false){
            if(CombatScript.Spelling == false){  
                #if UNITY_EDITOR
                    horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
                #elif UNITY_ANDROID
                    horizontalMove = HorizValue * runSpeed;
                #endif
               /* if(UnityControl == true){
                    horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
                } 
                else{
                    horizontalMove = HorizValue * runSpeed;
                }*/
       
        
        animator.SetFloat("Speed" , Mathf.Abs(horizontalMove));
        
        if(JumpValue == true){
            jump = true;
            animator.SetBool("IsJumping" , true);
            jumped = true;
            JumpValue = false;
        }


        if(PlayerGrounded == false && jumped == false ){
            falling = true;
            animator.SetBool("falling" , true);
        }
        if(IsPushing == true && horizontalMove != 0){
            animator.SetBool("pushing" , true);
        }
        else if(IsPushing == false || horizontalMove == 0){
            animator.SetBool("pushing" , false);
        }
        
        
        if(PlayerGrounded == false){
            runs.Stop();
        }

        if(CrouchValue == true){
            crouch = true;
        }
        else if(CrouchValue == false){
            crouch = false;
        }
      }
  }
      

    }

    void FixedUpdate(){
        if(PlayerHealth.playerDied == false && Freezed == false){
                controller.Move(horizontalMove * Time.deltaTime , crouch , jump);
        jump = false;
        if(horizontalMove != 0 && jumped == false){
            runParticle.Play();
            if(!runs.isPlaying && crouch == false && IsPushing == false && PlayerGrounded == true){
                runs.Play();
                if(crouchMove.isPlaying){
                    crouchMove.Stop();
                }
                
            }
            else if(!crouchMove.isPlaying && crouch == true){
                crouchMove.Play();
                if(runs.isPlaying){
                    runs.Stop();
                }
                
            }
            else if(!pushingSound.isPlaying && IsPushing == true){
                pushingSound.Play();
                runs.Stop();
                crouchMove.Stop();
            }
        }
        else{
            runParticle.Stop();
            runs.Stop();
            crouchMove.Stop();
            pushingSound.Stop();
        }
        
        }
        
        
    }
    
   
   
    public void OnLanding(){
        if(falling == true){
            animator.SetBool("falling" , false);
            falling = false;
        }
        else{
            animator.SetBool("IsJumping" ,false);
            jumped = false;
        }
        if(BounceLanded == true){
            BounceSound.Play();
            BounceLanded = false;
        }
        else {
            JumpParticle.Play();
            jumps.Play();
        }
        
        
    }
    public void OnCrouching(bool IsCrouching){
        if(horizontalMove != 0){
            animator.SetBool("IsCrouching" , IsCrouching);
            animator.SetTrigger("Slide");
            controller.m_CrouchSpeed = 1;
            Invoke("SetCrouchSpeed" , 1f);
        }
        else{
            animator.SetBool("IsCrouching" , IsCrouching);
        }
        
    }

    
    void SetCrouchSpeed(){
        controller.m_CrouchSpeed = controller.OriginalCrouchSpeed;
    }

    public void FreezePlayer(){
        Freezed = true;
        animator.SetBool("Freeze" , true);
        FreezeSheild.SetActive(true);
        pushingSound.Stop();
        runs.Stop();
        crouchMove.Stop();
        freezsound.Play();
        Invoke("Exitfreeze" , 3f);
       this.gameObject.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.StartAsleep;
    }

    public void Exitfreeze(){
        if(Freezed == true){
            Freezed = false;
            animator.SetBool("Freeze" , false);
            FreezeSheild.SetActive(false);
            IceHit.Play();
            icebreak.Play();
            this.gameObject.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.StartAwake;
           
        }
        
    }
}
