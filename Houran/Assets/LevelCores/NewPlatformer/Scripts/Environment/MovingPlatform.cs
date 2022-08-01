using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector2[] Waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed;
    [SerializeField] private float time;
     public bool gonow ;
    [HideInInspector]public bool InBound = false;
    [HideInInspector] public GameObject InBoundObject;
    private GameObject PlayerParent;

    public int relatedMission;
    public int returnIndex;
    bool ToReturn = false;
    public UnityEvent startEvent;
    
    // Update is called once per frame
    void Start(){
        PlayerParent = GameObject.FindGameObjectWithTag("playerParent");
        startEvent.Invoke();
    }
    void Update()
    {
        if(ToReturn == false && Vector2.Distance(Waypoints[currentWaypointIndex] , transform.position) < 0.1f){
            currentWaypointIndex++;
            gonow = false;
            Invoke("activer" , time);
            if(currentWaypointIndex >= Waypoints.Length){
                currentWaypointIndex = 0;
            }
        }
        else if(ToReturn == true && Vector2.Distance(Waypoints[currentWaypointIndex] , transform.position) < 0.1f){
            currentWaypointIndex++;
            gonow = false;
            if(currentWaypointIndex >= Waypoints.Length){
                currentWaypointIndex = 0;
            }
        }
        if(gonow == true){
            transform.position = Vector2.MoveTowards(transform.position , Waypoints[currentWaypointIndex] , Time.deltaTime * speed);
        }
        if(InBoundObject != null){
            if(InBound == true){
                InBoundObject.transform.SetParent(this.gameObject.transform);
            }
            else if(InBound == false){
                InBoundObject.transform.SetParent(PlayerParent.transform);
                InBoundObject = null;
            }
        }
        
        
    }
    public void Return(){
        gonow = true;
        currentWaypointIndex = returnIndex;
        ToReturn = true;
    }
    public void OnActive(){
        gonow = true;
    }
    
    public void OnDisactive(){
        gonow = false;
    }

    void activer(){
        gonow = true;
    }

    public void BaseOnMission(){
        if(GameObject.FindGameObjectWithTag("EnvBase").GetComponent<ItemController>().AllMissions[relatedMission].ThisisDone == true){
            OnActive();
        }
    }

}
