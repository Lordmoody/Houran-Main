using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidPool : MonoBehaviour
{
    public GameObject AcidParticle;
    GameObject parent;
    public float damage;
    bool doit = false;

     void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "pplayer"){
            parent = other.gameObject.GetComponent<ShowYourParent>().MyParent;
            parent.GetComponent<PlayerHealth>().TakeDamge(damage);
            Instantiate(AcidParticle , other.gameObject.transform.position , Quaternion.identity);
            doit = true;
            StartCoroutine(DecreaseHealth());
        }    
    }
     void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "pplayer"){
            doit = false;
            StopCoroutine(DecreaseHealth());
        }
    }

    IEnumerator DecreaseHealth(){
        while(doit){
            parent.GetComponent<PlayerHealth>().TakeDamge(damage);
            yield return new WaitForSeconds(3f);
        } 
    }
}
