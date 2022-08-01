using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveCircleLight : MonoBehaviour
{
    public GameObject CircleLight , ParticleCreation , FollowThis;
    public ParticleSystem HandlerParticle;
    private GameObject InstPos;
    GameObject Created , particle;
    [HideInInspector] public bool Gave = false;
    public AudioSource Activation;


     void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" && Gave == false){
            Activation.Play();
            FollowThis = other.gameObject;
            Created = Instantiate(CircleLight , new Vector3(other.gameObject.transform.position.x , other.gameObject.transform.position.y + 3f , other.gameObject.transform.position.z),Quaternion.identity);
            Created.GetComponent<CircleMask>().giveCircle = this.GetComponent<GiveCircleLight>();
            InstPos = GameObject.FindGameObjectWithTag("playerParent");
            Created.transform.SetParent(InstPos.transform);
            particle = Instantiate(ParticleCreation , new Vector3(other.gameObject.transform.position.x , other.gameObject.transform.position.y + 3f , other.gameObject.transform.position.z) , Quaternion.identity);
            particle.transform.SetParent(other.gameObject.transform);
            HandlerParticle.Stop();
            Gave = true;
        }
    }

    
}
