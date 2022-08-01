using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fortree : MonoBehaviour
{
    public GameObject TheTree;
    public GameObject CloseButton;
    public GameObject OpenButton;
    private GameObject mainLight;
    public CinemachinSwitcher cinemachinSwitcher;
    public GameObject BackGround1 , BackGround2;
    public GameObject GameCanvas , UiCamera;
    public AudioSource MainThemePlat , MainThemeTree , Ambience;
    public Script script;
    public Animator GuidAnim;
    public ControlGuide controlGuide;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseTheTree(){
        TheTree.SetActive(false);
        CloseButton.SetActive(false);
        OpenButton.SetActive(true);
        mainLight = GameObject.FindGameObjectWithTag("Global");
        mainLight.SetActive(true);
        cinemachinSwitcher.SwitchToPlatformer();
        BackGround1.SetActive(false);
        BackGround2.SetActive(false);
        GameCanvas.SetActive(true);
        UiCamera.SetActive(true);
        MainThemePlat.Play();
        MainThemeTree.Stop();
        Ambience.Play();
        CombatScript.InTree =false;
        if(ControlGuide.CurrentGuide != "None"){
            controlGuide.PlayAnim(ControlGuide.CurrentTransition , 2f);
        }
        
    }
}
