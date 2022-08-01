using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSound : MonoBehaviour
{
    public GameObject[] Audios;
    // Start is called before the first frame update
    void Start()
    {
        Audios = GameObject.FindGameObjectsWithTag("Audio");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LesserOtherSounds(){
        Audios = GameObject.FindGameObjectsWithTag("Audio");
        foreach(GameObject audio in Audios){
            audio.GetComponent<AudioSource>().volume = 0.2f;
        }
        Invoke("Increase" , 1.5f);

    }

    void Increase(){
        foreach(GameObject audio in Audios){
            audio.GetComponent<AudioSource>().volume = 1f;
        }
    }
}
