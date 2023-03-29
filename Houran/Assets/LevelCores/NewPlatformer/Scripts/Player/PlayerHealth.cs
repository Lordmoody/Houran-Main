using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FirstGearGames.SmoothCameraShaker;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{

    public float healthPlayer = 100f;
    public Animator playeranim;
    public static bool playerDied = false;
    public Animator BarEffect;
    public GameObject IconButton , HealthBar , BrokenBar , FillBar;
    public AudioSource BreakHealth , GotHitS;
    public ShakeData shakeHealth;
    public GameObject GuideBirth;
    public UnityEvent OnDeath;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamge(float damage){
        if(this.gameObject.GetComponent<NewPlayerMovementP>().Freezed == true){
            this.gameObject.GetComponent<NewPlayerMovementP>().Exitfreeze();
        }
        CameraShakerHandler.Shake(shakeHealth);
        healthPlayer -= damage;
        BarEffect.SetTrigger("Less");
        playeranim.SetFloat("Health" , healthPlayer);
        playeranim.SetTrigger("GotHit");
        if(healthPlayer <= 0){
            Die();
        }
        else{
            GotHitS.Play();
        }
    }

    void Die(){
        BreakHealth.Play();
        HealthBar.SetActive(false);
        BrokenBar.SetActive(true);
        IconButton.SetActive(false);
        FillBar.SetActive(false);
        playerDied = true;
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        this.gameObject.GetComponent<CombatScript>().enabled = false;
        this.gameObject.GetComponent<NewPlayerMovementP>().enabled = false;
        CheckForGuide.ItemTillNow = 0;
        OnDeath.Invoke();
        Destroy(this.gameObject , 3f);
    }
}
