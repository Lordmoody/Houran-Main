using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SetDestGuide : MonoBehaviour
{
    public static GameObject tagerGuide; 

    // Start is called before the first frame update
    void Start()
    {
        tagerGuide = TaskUIManager.GuideToThis;
        this.gameObject.GetComponent<AIDestinationSetter>().target = tagerGuide.transform;
    }
    void Update(){
        if(this.gameObject.GetComponent<AIPath>().reachedDestination == true){
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    
}
