using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class LightTheBox : MonoBehaviour
{
    public float addIntensity;
	
	
	 
     float FinalTime;
    float CurrentTime = 0;
    public float timeRate;
    float TimeChanger = 1;
    // Start is called before the first frame update
    void Start()
    {
        
        FinalTime = Time.time + (timeRate/2);
    }

    // Update is called once per frame
    void Update()
    {
        
            if(Time.time <= FinalTime){
                CurrentTime += Time.deltaTime * (TimeChanger);
                GetComponent<Light2D>().intensity = CurrentTime * (addIntensity / (timeRate/2));
            }
            else{
                FinalTime = Time.time + (timeRate/2);
                TimeChanger = TimeChanger * -1;
            }
        
    }
}
