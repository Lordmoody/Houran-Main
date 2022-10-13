using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage;
    public GameObject DropSplash , WallSplash;
    Script script;
    public GameObject parent;
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "pplayer"){
            script = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Script>();
            script.CurrentCharacter.GetComponent<PlayerHealth>().TakeDamge(damage);
            Instantiate(DropSplash , this.transform.position , Quaternion.identity);
            Destroy(parent);
        }
        else if(other.gameObject.tag == "ground"){
            Instantiate(WallSplash , this.transform.position , Quaternion.identity);
            Destroy(parent);
        }
    }
}
