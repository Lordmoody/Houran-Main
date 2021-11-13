using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class managertree : MonoBehaviour
{
    public GameObject cancas1 , canvas2;
    public GameObject movetree;
    public GameObject flashjump , flashwalk  , flashrun , flashsit, closeb , menutree;
    public AudioSource[] voices; 
    GameObject thisone , alsothis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void movements(){
        cancas1.SetActive(false);
        canvas2.SetActive(true);
        movetree.SetActive(true);
        alsothis = movetree;
        pan.pann = false;
    }
    public void showjumpf(){
        flashjump.SetActive(true);
        closeb.SetActive(true);
        thisone = flashjump;
    }
    public void showwalkf(){
        flashwalk.SetActive(true);
        closeb.SetActive(true);
        thisone = flashwalk;
    }
    public void showsitf(){
        flashsit.SetActive(true);
        closeb.SetActive(true);
        thisone = flashsit;
    }
    public void showrunf(){
        flashrun.SetActive(true);
        closeb.SetActive(true);
        thisone = flashrun;
    }
    public void closebutton(){
        closeb.SetActive(false);
        thisone.SetActive(false);
    }
    public void play(int i){
        voices[i].Play();
    }
    public void activemenu(){
        menutree.SetActive(true);
        pan.pann = false;
    }
    public void closemenutree(){
        menutree.SetActive(false);
        pan.pann = true;
    }
    public void GoToGame(){
        pan.pann = true;
        SceneManager.LoadScene("Runner1");
    }
    public void ExitTheGame(){
        Application.Quit();
    }
    public void returntree(){
        canvas2.SetActive(false);
        cancas1.SetActive(true);
        alsothis.SetActive(false);
        pan.pann = true;
    }
}
