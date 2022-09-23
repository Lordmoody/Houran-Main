using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using FirstGearGames.SmoothCameraShaker;

public class CombatScript : MonoBehaviour
{
    public Animator animator;
    public GameObject dag1 , dag2;
    public ParticleSystem dag1p , dag2p;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers , BoxLayer;
    public float HitDamage = 20f;
    //to wait for next attack series
    public float AttackRate = 2f;
    float nextAttackTime = 0f;
    public string[] animNums;
    int i = 0;

    //to wait for next rapid attack
    float forRapid = 0f;

    public ParticleSystem HitParticle;
    public AudioSource hitem , hitda;
    bool damaged = false;
    public static bool FingerMoved = false;
    bool DisapearNow = false;
    public float DisapearRate = 3f; 
    float DisapearTime = 0f;

    //Spell
    public string SpellName;
    public static bool Spelling = false;
   
    public AudioSource spellsound;
    public Transform Spellpoint;
    public float SpellRange = 0.5f; 
    public Image SpellIcone;
    public float SpellTimeRate = 5f;  
    float spellTime = 0;
    bool StartTime = false; 
    public float SpellAvTime = 5f;
    public float Multiplier = 0.2f;
    public Vector3 RomakSpellSize;

    public ParticleSystem NozhaHitMagic;
   public ShakeData MyShake;
   public ShakeData ShakePower;
   public static bool InTree = false;
   public ControlGuide controlGuide;
   public GameObject HitCheck , abilityCheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHealth.playerDied == false){
            #if UNITY_ANDROID
            AndroidController();
        #endif
        #if UNITY_EDITOR_WIN
            EditorController();
        #endif
        if(Time.time <= spellTime && StartTime == true ){
            SpellAvTime += Time.deltaTime;
          //  SpellIcone.fillAmount += Time.deltaTime * Multiplier;
        }
        else {
            StartTime = false;
        }
        }
        
    }

    void AndroidController(){
        //ForTouch
        if(Time.time >= nextAttackTime && InTree == false){
            if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended && Spelling == false && !IsMouseOverUIWithIgnores() ){
               // if(Input.GetTouch(0).phase == TouchPhase.Ended){
                    // if(!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)){
                        if(FingerMoved == true){
                            FingerMoved = false;
                        }
                        else if(FingerMoved == false){
                            if(ControlGuide.CurrentGuide == "HitGuide"){
                                ControlGuide.CurrentGuide = "None";
                                controlGuide.ForCancel();
                                Destroy(HitCheck);
                            }
                            i = 0;
                            Attack(animNums[i]);
                            nextAttackTime = Time.time + 1f ;
                            forRapid = Time.time + 0.5f;
                            DisapearTime = Time.time + DisapearRate;
                            DisapearNow = true;
                        }      
                   // }
                //}  
            }
            else if(Input.touchCount == 2 && Input.GetTouch(1).phase == TouchPhase.Ended && Spelling == false && !IsMouseOverUIWithIgnores()){
                            if(FingerMoved == true){
                            FingerMoved = false;
                        }
                        else if(FingerMoved == false){
                            i = 0;
                            Attack(animNums[i]);
                            nextAttackTime = Time.time + 1f ;
                            forRapid = Time.time + 0.5f;
                            DisapearTime = Time.time + DisapearRate;
                            DisapearNow = true;
                        } 
            }
        }
        else if(Time.time < nextAttackTime && InTree == false &&  Time.time >= forRapid && NewPlayerMovementP.CrouchValue == false){
            if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended && Spelling == false && !IsMouseOverUIWithIgnores()){
               // if(Input.GetTouch(0).phase == TouchPhase.Ended){
                //if(!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)){
                    if(FingerMoved == true){
                        FingerMoved = false;
                    }
                    else if(FingerMoved == false){
                        i++;
                        Attack(animNums[i]);
                        nextAttackTime = Time.time + 1f;
                        forRapid = Time.time + 0.5f;
                        if(i >= 2){
                            i = 0;
                            nextAttackTime = Time.time - 1f;
                            forRapid = Time.time - 0.5f;
                        }
                        DisapearTime = Time.time + DisapearRate;
                        DisapearNow = true;
                    }
                   //}
                //}
            }
            else if(Input.touchCount == 2 && Input.GetTouch(1).phase == TouchPhase.Ended && Spelling == false && !IsMouseOverUIWithIgnores()){
                        if(FingerMoved == true){
                        FingerMoved = false;
                    }
                    else if(FingerMoved == false){
                        i++;
                        Attack(animNums[i]);
                        nextAttackTime = Time.time + 1f;
                        forRapid = Time.time + 0.5f;
                        if(i >= 2){
                            i = 0;
                            nextAttackTime = Time.time - 1f;
                            forRapid = Time.time - 0.5f;
                        }
                        DisapearTime = Time.time + DisapearRate;
                        DisapearNow = true;
                    }
            }
        }
        if(Time.time > DisapearTime && Input.touchCount == 0 || Time.time > DisapearTime && Input.touchCount == 1 && FingerMoved == true ){
            if(DisapearNow == true){
                dag1.SetActive(false);
                dag2.SetActive(false);
                dag1p.Play();
                dag2p.Play();
                DisapearNow = false;
            }
        }
        /*if(Spelling == false && Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Ended && Input.GetTouch(1).phase == TouchPhase.Ended && StartTime == false &&  !IsMouseOverUIWithIgnores()){
            if(FingerMoved == true){
                FingerMoved = false;
            }
            else if(FingerMoved == false){
                AbilityAll();
            }
        }*/
    }

    public void AbilityActivation(){
        if(Spelling == false && StartTime == false && NewPlayerMovementP.CrouchValue == false){
            if(FingerMoved == true){
                FingerMoved = false;
            }
            else if(FingerMoved == false){
                if(ControlGuide.CurrentGuide == "AbilityGuide"){
                    ControlGuide.CurrentGuide = "None";
                    controlGuide.ForCancel();
                    Destroy(abilityCheck);
                }
                AbilityAll();
            }
        }
    }

    void EditorController(){
        //ForMouse
        if(Time.time >= nextAttackTime){
            if(Input.GetKeyDown(KeyCode.K)/*Input.GetMouseButtonUp(0)*/  && !IsMouseOverUIWithIgnores() /*&& !EventSystem.current.IsPointerOverGameObject()*/ && Spelling == false){
                if(FingerMoved == true){
                    if(NewPlayerMovementP.HorizValue > 0 || NewPlayerMovementP.HorizValue < 0 ){
                        i = 0;
                        if(ControlGuide.CurrentGuide == "HitGuide"){
                                ControlGuide.CurrentGuide = "None";
                                controlGuide.ForCancel();
                                Destroy(HitCheck);
                            }
                        Attack(animNums[i]);
                        nextAttackTime = Time.time + 1f ;
                        forRapid = Time.time + 0.5f;
                        DisapearTime = Time.time + DisapearRate;
                        DisapearNow = true;
                    }
                    else{
                        FingerMoved = false;
                    }
                    
                }
                else if(FingerMoved == false){
                    Debug.Log("hitstarted");
                    if(ControlGuide.CurrentGuide == "HitGuide"){
                                ControlGuide.CurrentGuide = "None";
                                controlGuide.ForCancel();
                                Destroy(HitCheck);
                            }
                    i = 0;
                    Attack(animNums[i]);
                    nextAttackTime = Time.time + 1f ;
                    forRapid = Time.time + 0.5f;
                    DisapearTime = Time.time + DisapearRate;
                    DisapearNow = true;
                }
            }
        }
        else if(Time.time < nextAttackTime && Time.time >= forRapid && NewPlayerMovementP.CrouchValue == false){
            if(Input.GetKeyDown(KeyCode.K)/*Input.GetMouseButtonUp(0)*/ && Spelling == false && !IsMouseOverUIWithIgnores() /*&& !EventSystem.current.IsPointerOverGameObject()*/){
                if(FingerMoved == true){
                    FingerMoved = false;
                }
                else if(FingerMoved == false){
                    i++;
                    Attack(animNums[i]);
                    nextAttackTime = Time.time + 1f;
                    forRapid = Time.time + 0.5f;
                    if(i >= 2){
                        i = 0;
                        nextAttackTime = Time.time - 1f;
                        forRapid = Time.time - 0.5f;
                    } 
                    DisapearTime = Time.time + DisapearRate;
                    DisapearNow = true;
                }
            }
        }

        if(Time.time > DisapearTime && Input.GetMouseButtonDown(0) == false && Input.GetMouseButtonUp(0) == false){
            if(DisapearNow == true){
                dag1.SetActive(false);
                dag2.SetActive(false);
                dag1p.Play();
                dag2p.Play();
                DisapearNow = false;
            }
            
        }
        if(Spelling == false && /*Input.GetMouseButtonDown(1)*/ Input.GetKeyDown(KeyCode.J) && StartTime == false && !IsMouseOverUIWithIgnores()){
            if(FingerMoved == true){
                FingerMoved = false;
            }
            else if(FingerMoved == false){
                AbilityAll();
            }
        }
    }

    void Attack(string animnum){
        //play animation
        dag1.SetActive(true);
        dag2.SetActive(true);
        if(NewPlayerMovementP.CrouchValue == false){
            animator.SetTrigger(animnum);
        }
        else{
            animator.SetTrigger("Attack1");
        }
        if(SpellName == "NSpell"){
            NozhaHitMagic.Play();
        }
        

        //detect enemies
        Collider2D[] hitEnemies  =  Physics2D.OverlapCircleAll(attackPoint.position , attackRange , enemyLayers);
        //damage
        foreach(Collider2D enemy in hitEnemies){
            enemy.GetComponent<Enemy>().TakeDamage(HitDamage);
            HitParticle.Play();
            damaged = true;
        }
        ///Detect Box
            Collider2D[] hitBoxes  =  Physics2D.OverlapCircleAll(attackPoint.position , attackRange , BoxLayer);
            foreach(Collider2D box in hitBoxes){
            box.GetComponent<BoxController>().BreakBox();
        }
        ///end
        if(damaged == true){
            hitda.Play();
            CameraShakerHandler.Shake(MyShake);
            damaged = false;
        }
        else if(damaged == false){
            hitem.Play();
        }
    }

    void AbilityAll(){
      //  SpellIcone.fillAmount = 0;
        SpellAvTime = 0;
        spellTime = Time.time + SpellTimeRate;
        StartTime = true;
        animator.SetTrigger(SpellName);
        
        spellsound.Play();
        Spelling = true;
        if(SpellName == "ASpell" || SpellName == "RSpell"){
            CameraShakerHandler.Shake(ShakePower);
        }
        if(SpellName == "SSpell" || SpellName == "ASpell" || SpellName == "RSpell" || SpellName == "NSpell"){
            Collider2D[] effectEnemies  =  Physics2D.OverlapCircleAll(Spellpoint.position , SpellRange , enemyLayers);
            foreach(Collider2D enemy in effectEnemies){
             if(SpellName == "SSpell"){
                 enemy.GetComponent<Enemy>().Invoke("SpellGotK" , 0.5f);
            }
            else if(SpellName == "ASpell"){
                enemy.GetComponent<Enemy>().SpellGotA();             
            }
            else if(SpellName == "RSpell"){
             enemy.GetComponent<Enemy>().Invoke("SpellGotR" , 0.5f);   
            }
            else if(SpellName == "NSpell"){
                enemy.GetComponent<Enemy>().Invoke("SpellGotN" , 0.5f);
            }
         }  
        }
        
        
          
            
        Invoke("SpellingFinished" , 1.55f);
    }

    
    void SpellingFinished(){
        Spelling = false;
    }

    
    void OnDrawGizmosSelected(){
        if(attackPoint == null){
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position , attackRange);
        if(SpellName == "SSpell" || SpellName == "ASpell" || SpellName == "RSpell" || SpellName == "NSpell"){
            Gizmos.DrawWireSphere(Spellpoint.position , SpellRange);
        }
        
    }

    private bool IsMouseOverUIWithIgnores(){
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;
        List<RaycastResult> raycastResultList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData , raycastResultList);
        for (int i = 0 ; i < raycastResultList.Count ; i++){
            if(raycastResultList[i].gameObject.GetComponent<MouseUIClickThrough>() != null){
                raycastResultList.RemoveAt(i);
                i--;
            }
        }
        return raycastResultList.Count > 0;
    }
}
