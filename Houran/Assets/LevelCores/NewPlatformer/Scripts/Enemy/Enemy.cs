using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100;
    float currentHealth;
    public Image barHealth;
    public ParticleSystem SleepParticle;
    public Animator animator , stuckAnimator;
    public  bool ItDied = false , Slept = false;
    public GameObject ForAI;
    public  bool EnemyGotDamaged = false;
    public GameObject DeathParticle;
    public Transform DeathParticlePosition;
    public UnityEvent DieEvent;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage){
        EnemyGotDamaged = true;
        Invoke("DamagesPass" , 1f);
        currentHealth -= damage;
        barHealth.fillAmount = currentHealth / 100;
        

        animator.SetFloat("Health" , currentHealth);
        //play animation
        
        animator.SetTrigger("Hitted");

        if(currentHealth <= 0){
            Die();
        }
    }

    void DamagesPass(){
        EnemyGotDamaged = false;
    }

    void Die(){
        Debug.Log("Enenmy Died!");
        // die animation
        DieEvent.Invoke();
        //diable enemy
        ItDied = true;
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        if(this.gameObject.GetComponent<EnemyMovement>() != null){
            this.gameObject.GetComponent<EnemyMovement>().enabled = false;
        }
        ForAI.GetComponent<EnemyAI>().enabled = false;
        ForAI.GetComponent<EnemyFieldOfView>().enabled = false;
        Instantiate(DeathParticle , DeathParticlePosition.position , Quaternion.identity);
        Destroy(this.gameObject , 0.30f);

    }

    public void SpellGotK(){
        //play animation
        animator.SetBool("Dizzy" , true);
        SleepParticle.Play();
        Slept = true;
        animator.SetBool("Walk" , false);
        animator.SetBool("Run", false);
        // stop movement
        Invoke("Awakenn" , 4f);
    }
    public void SpellGotA(){
        //play animation hit
        //stop movement
        TakeDamage(40);
        Invoke("AwakennOther" , 1f);
    }

    public void SpellGotR(){
        //play animation hit
        //stop movement
        TakeDamage(40);
        Invoke("AwakennOther" , 1f);
    }
    public void SpellGotN(){
        //play animation
        animator.SetBool("Dizzy" , true);
        Slept = true;
        animator.SetBool("Walk" , false);
        animator.SetBool("Run", false);
        stuckAnimator.SetBool("Stuck" , true);
        // stop movement
        Invoke("Awakenn" , 4f);
    }

    void Awakenn(){
        stuckAnimator.SetBool("Stuck" , false);
        stuckAnimator.SetTrigger("End");
        Slept = false;
        animator.SetBool("Dizzy" , false);
        //start movement
        //idle animation
    }
    void AwakennOther(){
        
        //start movement
        //idle animation
    }
}
