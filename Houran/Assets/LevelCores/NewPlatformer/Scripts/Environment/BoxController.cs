using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public SpriteRenderer BoxSprite;
    public GameObject BoxGO , ParticleBreak;

    public void BreakBox(){
        Invoke("BreakNow" , 0.2f);
    }
    void BreakNow(){
        BoxSprite.enabled = false;
        Instantiate(ParticleBreak , BoxGO.transform.position , Quaternion.identity);
        Destroy(BoxGO , 1f);
    }
}
