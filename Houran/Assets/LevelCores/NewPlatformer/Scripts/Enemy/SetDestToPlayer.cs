using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SetDestToPlayer : MonoBehaviour
{
    public float TimeToDestroy;
    public GameObject HitParticle;
    GameObject parent;
    public float Damage = 5f;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<AIDestinationSetter>().target = IceWizEnemyFinder.PlayerTarget.transform;
        Destroy(this.gameObject , TimeToDestroy);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "pplayer"){
            Instantiate(HitParticle , this.gameObject.transform.position , Quaternion.identity);
            //player freeze
            parent = other.gameObject.GetComponent<ShowYourParent>().MyParent;
            parent.GetComponent<PlayerHealth>().TakeDamge(Damage);
            parent.GetComponent<NewPlayerMovementP>().FreezePlayer();
            Destroy(this.gameObject);
        }
    }

}
