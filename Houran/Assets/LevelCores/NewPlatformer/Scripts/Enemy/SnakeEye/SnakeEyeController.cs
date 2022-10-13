using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeEyeController : MonoBehaviour
{
    public bool SnakeEye = true , IceWize = false;
    public Animator animator;
    public static string SideOfShot;
    public Transform targrotationup , targrotationdown;
    public Transform UpperBody;
    public EnemyFieldOfView Front , Back;
    public GameObject Bullet , VanishPart;
    public AudioSource BulletSound , begsound , vansound , dienowsound;
    public Transform BulletPos;
    public Transform ShotParticle;
    public float ShootRate;
    float CurrentTime;
     Transform Target;
     Transform SaveRotation;
    bool detected = false;
    bool Begmode  = false;
    int DecideMode = 0;
    Vector3 relativePos;
    public float shootstart = 0f;
    // Start is called before the first frame update
    void Start()
    {
        SaveRotation = UpperBody;
        Target = GameObject.FindGameObjectWithTag("flag").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(detected == true){
            if(SnakeEye == true){
                if(Target.position.x < UpperBody.position.x){
                   relativePos = Target.position - UpperBody.position; 
                   SideOfShot = "Left";
                }
                else if(Target.position.x > UpperBody.position.x){
                    relativePos =  UpperBody.position - Target.position;
                    SideOfShot = "Right";
                }
                 float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
                 var rotation = Quaternion.AngleAxis(angle ,Vector3.forward);
                 UpperBody.rotation = rotation;
            }
                
                 if(Begmode == false){
                    if(DecideMode == 0){
                        if(Time.time >= CurrentTime + ShootRate){
                        animator.SetTrigger("Shoot");
                        Invoke("ShootTheTarget" , shootstart);
                        CurrentTime = Time.time;
                         }
                    }
                    else if(DecideMode == 1){
                        if(Time.time >= CurrentTime + ShootRate){
                        animator.SetTrigger("Shoot");
                        Invoke("ShootTheTarget" , shootstart);
                        CurrentTime = Time.time;
                         }
                    }
                    else if(DecideMode == 2){
                        OnExit();
                        Front.enabled = false;
                        Back.enabled = false;
                        vansound.Play();
                        Invoke("Vanish" , 2f);
                    }
                 }
        }
        else {
            UpperBody.rotation = new Quaternion(0 , 0 , 0 , 0);
        }
       
    }
    void Vanish(){
        Instantiate(VanishPart , this.gameObject.transform.position , Quaternion.identity);
        Destroy(this.gameObject);
    
    }
    GameObject bulletins;
    void ShootTheTarget(){
        bulletins = Instantiate(Bullet , BulletPos.position , Quaternion.identity);
        if(SnakeEye == true){
            bulletins.GetComponent<BulletScript>().PlayerPos = Target;
        }
        BulletSound.Play();
        if(SnakeEye == true){
            if(SideOfShot == "Left"){
                 ShotParticle.localScale = new Vector3(-1, ShotParticle.localScale.y , ShotParticle.localScale.z);
            }
             else if(SideOfShot == "Right"){
                 ShotParticle.localScale = new Vector3(1, ShotParticle.localScale.y , ShotParticle.localScale.z);
            }
        }
       // animator.SetTrigger("Shoot");
    }


    public void OnDetect(){
       CurrentTime = Time.time;
        Back.CheckNow = false;
        animator.SetBool("aim" , true);
        detected = true;
        
    }
    public void OnExit(){
        
        animator.SetBool("aim" , false);
        detected = false;
        Back.CheckNow = true;
       
    }

    public void OnDetectBack(){
        this.transform.localScale = new Vector3(-this.transform.localScale.x , this.transform.localScale.y , this.transform.localScale.z);
    }
    public void OnExitBack(){
      
        animator.SetBool("aim" , false);
        detected = false;
       
       
    }

    public void BegDetect(){
        Begmode = true;
        animator.SetBool("Surrender" , true);
        begsound.Play();
    }

    public void BegExit(){
        Begmode = false;
        animator.SetBool("Surrender" , false);
        DecideMode = Random.Range(1 , 3);
        Debug.Log(DecideMode);
        if(DecideMode == 1){
            dienowsound.Play();
        }
    }
}
