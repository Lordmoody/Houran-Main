using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidDrop : MonoBehaviour
{
    public float damage;
    public GameObject DropSplash;
   [HideInInspector] public bool move;
    [HideInInspector] public Vector3 SideMove;
    [HideInInspector] public float speed;


    void Update(){
        if(move == true){
            this.gameObject.transform.position += SideMove * Time.deltaTime * speed; 
        }
    }
    
    Script script;
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "pplayer"){
            script = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Script>();
            script.CurrentCharacter.GetComponent<PlayerHealth>().TakeDamge(damage);
            Instantiate(DropSplash , this.transform.position , Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if(other.gameObject.tag == "ground"){
            Instantiate(DropSplash , this.transform.position , Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
