using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
   // [SerializeField] float rotateSpeed = 60f;
   // [SerializeField] float rotZ ;
   [SerializeField] private Vector3[] Waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed;
    [SerializeField] private float time;
     public bool gonow ;
    

    void Update()
    {
      //  transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * rotateSpeed, rotZ) );
      if(Vector2.Distance(Waypoints[currentWaypointIndex] , transform.eulerAngles) < 0.1f){
            currentWaypointIndex++;
            gonow = false;
            Invoke("activer" , time);
            if(currentWaypointIndex >= Waypoints.Length){
                currentWaypointIndex = 0;
            }
        }
      if(gonow == true){
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, Waypoints[currentWaypointIndex], Time.deltaTime);
        }
    }

    void activer(){
        gonow = true;
    }
}
