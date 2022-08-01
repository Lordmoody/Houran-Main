using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControllerNew : MonoBehaviour
{

    public void PlayScene(){
        SceneManager.LoadScene("TestMovement");
    }

    public void Exit(){
        Application.Quit();
    }
}
