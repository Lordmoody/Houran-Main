using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public float healthRate;
    float ReaminedHealth;
    public GameObject EatHealth;

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            ReaminedHealth = 100 - other.gameObject.GetComponent<PlayerHealth>().healthPlayer;
            if(ReaminedHealth >= healthRate){
                other.gameObject.GetComponent<PlayerHealth>().healthPlayer += healthRate;
            }
            else if(ReaminedHealth < healthRate && ReaminedHealth > 0){
                other.gameObject.GetComponent<PlayerHealth>().healthPlayer += ReaminedHealth;
            }
            Instantiate(EatHealth , this.gameObject.transform.position , Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
