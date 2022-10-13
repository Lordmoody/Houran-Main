using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBehind : MonoBehaviour
{
    public EnemyFieldOfView fov;
    public Enemy enemy;
    bool LookBack = false;
    public EnemyMovement enemyMovement;
    public Transform Thisenemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LookBack == true && enemy.EnemyGotDamaged == true){
            if(enemyMovement != null){
                enemyMovement.PlayerinRange = true;
            }
            Thisenemy.transform.localScale = new Vector3(-Thisenemy.transform.localScale.x,Thisenemy.transform.localScale.y,Thisenemy.transform.localScale.z );
            LookBack = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            if(fov.CanSeePlayer == false){
                LookBack = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            if(fov.CanSeePlayer == false){
                LookBack = false;
            }
        }
    }
}
