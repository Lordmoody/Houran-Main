using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControllerNew : MonoBehaviour
{
    public AudioSource audio;

    public void PlayScene(){
        audio.Play();
        SceneManager.LoadScene("TestMovement");
    }

    public void Exit(){
        audio.Play();
        Application.Quit();
    }
}
