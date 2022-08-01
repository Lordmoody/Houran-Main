using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipParticleWave : MonoBehaviour
{
    public Transform Player;
    public Transform Particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FlipParticle();
    }
    public void FlipParticle(){
        if(Player.localScale.x > 0){
            Particle.localScale = new Vector3(Mathf.Abs(Particle.localScale.x) , Particle.localScale.y , Particle.localScale.z);
        }
        else if(Player.localScale.x < 0){
            if(Particle.localScale.x > 0){
                Particle.localScale = new Vector3(-Particle.localScale.x , Particle.localScale.y , Particle.localScale.z);
            }
            else if(Particle.localScale.x < 0){
                Particle.localScale = new Vector3(Particle.localScale.x , Particle.localScale.y , Particle.localScale.z);
            }
        }
    }
}
