using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportEnd : MonoBehaviour
{
    public ParticleSystem tele , lightt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Light"){
            Debug.Log("it passed");
            VoidCanvas.NowWin = true;
            tele.Play();
            lightt.Play();
        }
    }
}
