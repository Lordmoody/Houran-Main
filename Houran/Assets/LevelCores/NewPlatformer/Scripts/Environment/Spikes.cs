using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    
     float SpikeDamage;
     [Range(1 , 10)] public float DamageCost;
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            SpikeDamage = other.gameObject.GetComponent<PlayerHealth>().healthPlayer / DamageCost;
            other.gameObject.GetComponent<PlayerHealth>().TakeDamge(SpikeDamage);
        }
    }
}
