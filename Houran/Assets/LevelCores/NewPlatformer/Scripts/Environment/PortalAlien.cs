using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAlien : MonoBehaviour
{
    public static bool Teleported = false;
    public Transform TeleportPos;
    public GameObject Poof;
    public Transform PoofPos;
    private GameObject Char , Root;
    public AudioSource PoofSound;
    
     private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "pplayer" && Teleported == false){
            Teleported = true;
            Char = other.GetComponent<ShowYourParent>().MyParent;
            Root = other.GetComponent<ShowYourParent>().MyRoot;
            Instantiate(Poof, PoofPos.position , Quaternion.identity);
            PoofSound.Play();
            Root.SetActive(false);
            Invoke("Teleport" , 1f);
            
        }
    }

    void Teleport(){
        Char.transform.position = TeleportPos.position;
        Instantiate(Poof, TeleportPos.position , Quaternion.identity);
        PoofSound.Play();
        Root.SetActive(true);
        Invoke("ForTeleported" , 1f);
    }

    void ForTeleported(){
        Teleported = false;
    }
}
