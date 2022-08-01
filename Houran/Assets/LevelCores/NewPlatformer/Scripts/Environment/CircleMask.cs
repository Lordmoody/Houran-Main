using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMask : MonoBehaviour
{

    GameObject TheObject;
    public GameObject CreationParticle;
    public float DestTime;
    
    [HideInInspector] public GiveCircleLight giveCircle;

    void Start(){
        Invoke("Ending" , DestTime);
    }
    void Update(){
        this.transform.position = new Vector3(giveCircle.FollowThis.transform.position.x , giveCircle.FollowThis.transform.position.y + 3f , giveCircle.FollowThis.transform.position.z);
    }
     void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Circle"){
            Debug.Log("insiiiide");
            TheObject = other.gameObject;
            TheObject.GetComponent<Rigidbody2D>().isKinematic = false;
            TheObject.GetComponent<Collider2D>().isTrigger = true;
            
        }
    }

     void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Circle"){
            TheObject.GetComponent<Rigidbody2D>().isKinematic = true;
            TheObject.GetComponent<Collider2D>().isTrigger = false;
        }
    }

    void Ending(){
        Instantiate(CreationParticle , this.transform.position , Quaternion.identity);
        giveCircle.Gave = false;
        giveCircle.HandlerParticle.Play();
        Destroy(this.gameObject);
    }
}
