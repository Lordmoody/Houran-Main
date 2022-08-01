using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasC : MonoBehaviour
{
    public GameObject elses , opener , menu;
    public string homename;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openmenu(){
        elses.SetActive(false);
        opener.SetActive(false);
        menu.SetActive(true);
        Time.timeScale = 0;
    }
    public void closer(){
        elses.SetActive(true);
        opener.SetActive(true);
        menu.SetActive(false);
        Time.timeScale = 1;
    }
    public void gohome(){
        Time.timeScale = 1;
        SceneManager.LoadScene(homename);
    }
}
