using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private enum Sides{
        Left,
        Right
    }
    public Vector3 CurrentTarget;
    public Vector3 positionA , positionB;
    public Animator enemyAnim;
    public float speed , runspeed;
    [HideInInspector] public bool NowWalk = false , NowRun = false;
    [HideInInspector] public int Whichone = 1;
    public bool PlayerinRange = false;
    public Transform Findpoint;
    public float FindRange = 1f; 
    public LayerMask PlayersLayers;
    [HideInInspector] public bool CheckRange = false , goWalking = false;
    public GameObject Player;
    public bool CheckPlayer = false;
    public Enemy enemyinstance;


    public AudioSource WalkSound , RunSound;


    ///forAttacking
    public Transform HitPoint;
    public float HitRange = 1f;
    public float HitDmg = 10f;
    public string[] attacknames;
    int i = 0;
    public int AttackNumbers;
    public float hitrate = 2f , nextHit;
    public AudioSource forHitSound;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position = positionA;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    { 
       
             Player = GameObject.FindGameObjectWithTag("Player");
             
     if(enemyinstance.ItDied == false){
        if(CheckPlayer == true && enemyinstance.Slept == false){
            CheckRange = true;
            CurrentTarget = new Vector3(Player.transform.position.x , this.transform.position.y , transform.position.z);
            PlayerinRange = true;
            NowRun = true;
        }
        else if(CheckPlayer == false && enemyinstance.Slept == false){
            if(CheckRange == true){
                Debug.Log("out");
                CurrentTarget = positionA;
                PlayerinRange = false;
                NowRun = false;
                enemyAnim.SetBool("Run" , false);
                Whichone = 3;
                CheckRange = false;
            }
        }
        if(PlayerinRange == false && enemyinstance.Slept == false){
            NowRun = false;
            EnemyMoveToPoints();
            WalkTo();
        }
        else if(PlayerinRange == true && enemyinstance.Slept == false && PlayerHealth.playerDied == false){
            float DistanceBetween = Vector2.Distance(this.transform.position , Player.transform.position);
            if(DistanceBetween < 4 ){
                StandThere();
                NowRun = false;
                if(Time.time > nextHit && enemyinstance.EnemyGotDamaged == false){
                    AttackPlayer();
                    nextHit = Time.time + hitrate;
                }
            }
            else{
                NowRun = true;
                RunTo();
                enemyAnim.SetBool("Run" , true);
            }   
        }
        }

        
    }


    void EnemyMoveToPoints(){
        if(this.transform.position == positionA && Whichone == 1 || Whichone == 1 && goWalking == true){
            Whichone = 2;
            CurrentTarget = positionB;
            enemyAnim.SetBool("Walk" , false);
            NowWalk = false;
            Invoke("SetNowWalk" , 3f);
            goWalking = false;
        }
        else if(this.transform.position == positionB && Whichone == 2){
            Whichone = 1;
            CurrentTarget = positionA;
            
            enemyAnim.SetBool("Walk" , false);
            NowWalk = false;
            Invoke("SetNowWalk" , 3f);
        }
        else if(Whichone == 3){
            Whichone = 1;
            goWalking = true;
        }
    }
    void SetNowWalk(){
        NowWalk = true;
        enemyAnim.SetBool("Walk" , true);
        if(CurrentTarget == positionB){
              Flip(Sides.Right);
            }
            else if(CurrentTarget == positionA){
                Flip(Sides.Left);
            }
    }

    void WalkTo(){
        if(NowWalk == true){
            if(!WalkSound.isPlaying){
                WalkSound.Play();
            }
            if(RunSound.isPlaying){
                RunSound.Stop();
            }
            this.transform.position = Vector2.MoveTowards(transform.position , CurrentTarget , speed * Time.deltaTime);
            
        }
        else{
            if(WalkSound.isPlaying){
                WalkSound.Stop();
            }
        }
    }
    void RunTo(){
        if(NowRun == true){
            if(!RunSound.isPlaying){
                RunSound.Play();
            }
            if(WalkSound.isPlaying){
                WalkSound.Stop();
            }
            this.transform.position = Vector2.MoveTowards(transform.position , CurrentTarget , runspeed * Time.deltaTime);
            if(this.transform.position.x < CurrentTarget.x){
                Flip(Sides.Right);
            }
            else if(this.transform.position.x > CurrentTarget.x){
                Flip(Sides.Left);
            }
        }
        else{
            if(RunSound.isPlaying){
                RunSound.Stop();
            }
        }
    }
    void StandThere(){
        if(RunSound.isPlaying){
                RunSound.Stop();
            }
        enemyAnim.SetBool("Run" , false);
        enemyAnim.SetBool("Walk" , false);
    }
    void AttackPlayer(){
       // enemyAnim.SetTrigger(attacknames[i]);
       forHitSound.Play();
        if(i < AttackNumbers ){
            enemyAnim.SetTrigger(attacknames[i]);
            i++;
        }
        else{
            i = 0;
            enemyAnim.SetTrigger(attacknames[i]);
            i++;
        }
        Collider2D[] hitPlayer  =  Physics2D.OverlapCircleAll(HitPoint.position , HitRange , PlayersLayers);
        //damage
        foreach(Collider2D player in hitPlayer){
          //  player.GetComponent<PlayerHealth>().TakeDamge(HitDmg);
            //HitParticle.Play();
            
        }
        Player.GetComponent<PlayerHealth>().TakeDamge(HitDmg);
    }

    void Flip(Sides sides){
        if(sides == Sides.Left){
            if(this.transform.localScale.x < 0){
                this.transform.localScale = new Vector3(this.transform.localScale.x , this.transform.localScale.y , this.transform.localScale.z);
            }
            else if(this.transform.localScale.x > 0){
               this.transform.localScale = new Vector3(-this.transform.localScale.x , this.transform.localScale.y , this.transform.localScale.z); 
            }
           
        }
        else if(sides == Sides.Right){
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x) , this.transform.localScale.y , this.transform.localScale.z);
        }
    }

    

   void OnDrawGizmosSelected(){
       if(Findpoint == null || HitPoint == null){
           return;
       }
         Gizmos.DrawWireSphere(HitPoint.position , HitRange);
   }
}
