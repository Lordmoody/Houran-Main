using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chargingpop : MonoBehaviour
{
    public bool startnow = false;
    public ParticleSystem thisparticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startnow == true){
            thisparticle.Play();
            startnow = false;
        }
    }
}
