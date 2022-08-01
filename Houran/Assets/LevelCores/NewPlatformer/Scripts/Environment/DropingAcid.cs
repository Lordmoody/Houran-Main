using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropingAcid : MonoBehaviour
{
    public GameObject Drop;
    public Animator dropingAnim;
    public Transform dropPosition;
    public bool DropNow;
    public float timeToDrop , timeToStart;
    GameObject spit;
    public float spitSpeed;
    public Vector3 spitSide;
    public bool spitMove;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Dropping" , timeToStart , timeToDrop);
    }

    // Update is called once per frame
    void Update()
    {
        


        if(DropNow == true){
            spit = Instantiate(Drop , dropPosition.position , Quaternion.identity);
            if(spitMove == true){
                spit.GetComponent<AcidDrop>().move = true;
                spit.GetComponent<AcidDrop>().speed = spitSpeed;
                spit.GetComponent<AcidDrop>().SideMove = spitSide;
            }
            DropNow = false;
        }
    }

    void Dropping(){
        dropingAnim.SetTrigger("shoot");
    }
}
