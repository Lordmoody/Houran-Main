using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CharMovements : MonoBehaviour
{
    public Transform knobposition;
    public static GameObject lastKnob , ForwardKnob , LeftKnob , RightKnob;
    public float speed;
    public GameObject symb;
    public static GameObject thisKnob;
    public GameObject sighter;
    int i = 0;
    public AIDestinationSetter aIDestinationSetter;
    public GameObject Sightholder;
    
   // public Transform lefter;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {

    //    symb.transform.position = Vector2.MoveTowards(symb.transform.position , knobposition.position , Time.deltaTime * speed);
      //  symb.transform.Rotate(new Vector3(0,0,90) , Space.World);
    }


    public void TurnLeft(){
    //    sighter.SetActive(true);
     //   symb.transform.Rotate(new Vector3(0,0,90) , Space.World);
        Sightholder.SetActive(false);
        aIDestinationSetter.target = LeftKnob.transform;
    }
    public void TurnRight(){
       // sighter.SetActive(true);
      //  symb.transform.Rotate(new Vector3(0,0,-90) , Space.World);
      aIDestinationSetter.target = RightKnob.transform;
      Sightholder.SetActive(false);
    }
    public void Forward(){
       // sighter.SetActive(true);
      //  knobposition = thisKnob.transform;
      aIDestinationSetter.target = ForwardKnob.transform;
      Sightholder.SetActive(false);
        
    }
    public void Backward(){
      //  sighter.SetActive(false);
      //  knobposition = lastKnob.transform;
      aIDestinationSetter.target = lastKnob.transform;
      Sightholder.SetActive(false);
    }

}
