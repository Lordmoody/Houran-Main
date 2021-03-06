using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public EnemyMovement enemyMovement;
    public GameObject enemy;
    public ParticleSystem Detected;
    public EnemyFieldOfView enemyFieldOfView;
    public AudioSource DetectSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }


    public void OnDetection(){
        Detected.Play();
        DetectSound.Play();
        enemyMovement.CheckPlayer = true;
    }

    public void OnExit(){
        enemyMovement.CheckPlayer = false;
    }

    /*void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
                EnemyMovement.CheckPlayer = true;
                EnemyMovement.Player = other.gameObject;
        }
                
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            EnemyMovement.CheckPlayer = false;
        }
                
    }*/
}
