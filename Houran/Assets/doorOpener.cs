using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class doorOpener : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera vcam1;

    public GameObject Door;
    bool openIt = false;
    public Vector2 positionToOpen;
    public ParticleSystem OpeningParticle;
    public AudioSource openingSound;
    public bool StopRonot = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(openIt == true){
            if(Vector2.Distance(Door.transform.position , positionToOpen) >= 0.1f){
                 Door.transform.position = Vector2.MoveTowards(Door.transform.position , positionToOpen , Time.deltaTime * 3);
            }
            else{
                openIt = false;
                if(StopRonot == true){
                    OpeningParticle.Stop();
                    
                }
            }
        }
        
    }

    public void OpenDoor(){
        openIt = true;
        openingSound.Play();
        OpeningParticle.Play();
        vcam1.Priority = 15;
        Invoke("cameraSwitch" , 5);

    }
     public void cameraSwitch(){
        vcam1.Priority = 8;

    }
}

