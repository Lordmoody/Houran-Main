using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateHologram : MonoBehaviour
{
    public Vector3 instantiatePos;
    public float FlipSide , DestroyTime;
    public string AnimName;
    public GameObject Hologram;
    GameObject thisHologram;
    public bool AutoDestroy;

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "pplayer"){
            thisHologram = Instantiate(Hologram , instantiatePos , Quaternion.identity);
            thisHologram.GetComponent<HologramGuide>().ShowGuide(FlipSide , AnimName , DestroyTime);
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            if(AutoDestroy == true){
                DestroyThis();
            }
            else{
                Invoke("activeColliderAgain" , 5f);
            }
            

        }
    }

    void activeColliderAgain(){
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void DestroyThis(){
        Destroy(this.gameObject);
    }
}
