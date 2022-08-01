using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class PlayerCont : MonoBehaviour
{
    public Light2D lightt;
    public bool lessen = true;
    public MoveLight movelight;
    public ParticleSystem HitDark , CorrCh;
    public AudioSource HitDarkSound , CorrSound;
    public ParticleSystemRenderer GlowParticle;
    public Image Filler;
    public Animator RedWrong;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LightLesser" , 9f , 0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void LightLesser(){
        if(lessen == true){
            lightt.pointLightOuterRadius -= 0.1f;
            GlowParticle.lengthScale -= 0.1f;
            
        }
        else if(lessen == false){
            if(VoidCanvas.LostB == false){
                if(DarknessDetection.HittedByDark == true){
                    if(VoidCanvas.ByCanvas == false){
                        VoidCanvas.Health -= 1;
                        Filler.fillAmount -= 0.25f;
                    }
                    else if(VoidCanvas.ByCanvas == true){
                        VoidCanvas.ByCanvas = false;
                    }
                    RedWrong.SetTrigger("wrong");
                    lightt.pointLightOuterRadius = 5f;
                    GlowParticle.lengthScale = 5f;
                    movelight.speed = 10f;
                    Invoke("IncreaseSpeed" , 3f);
                    HitDark.Play();
                    HitDarkSound.Play();
                    DarknessDetection.HittedByDark = false;
                    lessen = true;
            }
            else if(VoidCanvas.CorrectChoice == true){
                lightt.pointLightOuterRadius = 5f;
                GlowParticle.lengthScale = 5f;
                movelight.speed = 10f;
                Invoke("IncreaseSpeed" , 2f);
                CorrCh.Play();
                CorrSound.Play();
                VoidCanvas.CorrectChoice = false;
                lessen = true;
            }
            }
            
            
        }
        
    }

    void IncreaseSpeed(){
        movelight.speed = 17f;
    }
    

    
}
