using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class Script : MonoBehaviour
{
    public GameObject switcmenu;
    public GameObject karench , avatch , romakch , Nozhach;
    public CinemachineVirtualCamera cinemachine;
    public Image First , Second;
    public Sprite karens , avats , romaks , nozhas;
    public Button button;
    public GameObject CurrentCharacter;
    public float multiplierr = 0.2f;
    public Image PlayerHealthBar;
    public static bool PLayerChanged = false;



    public GameObject TheTree;
    public GameObject CloseButton;
    public GameObject OpenButton;
    private GameObject mainLight;
    public CinemachinSwitcher cinemachinSwitcher;
    public GameObject BackGround1 , BackGround2;
    public GameObject GameCanvas;
   public AudioSource MainThemePlat , MainThemeTree;


   public GameObject VictoryPanel , UiCamera;
   
   public GameObject MainMenu;
   
    // Start is called before the first frame update
    void Awake()
    {
       if(karench.activeSelf == true){
           CurrentCharacter = karench;
       } 
       else if(avatch.activeSelf == true){
           CurrentCharacter = avatch;
       }
       else if(romakch.activeSelf == true){
           CurrentCharacter = romakch;
       }  
       else if(Nozhach.activeSelf == true){
           CurrentCharacter = Nozhach;
       }
    }

    // Update is called once per frame
    void Update()
    {
        button.onClick.AddListener(forAdd);
        Second.fillAmount = CurrentCharacter.GetComponent<CombatScript>().SpellAvTime * multiplierr;
        PlayerHealthBar.fillAmount = CurrentCharacter.GetComponent<PlayerHealth>().healthPlayer / 100;
        if(CurrentCharacter.GetComponent<PlayerHealth>().healthPlayer < 70 && CurrentCharacter.GetComponent<PlayerHealth>().healthPlayer > 40){
            PlayerHealthBar.color = Color.yellow;
        }
        else if(CurrentCharacter.GetComponent<PlayerHealth>().healthPlayer <= 40){
            PlayerHealthBar.color = Color.red;
        }
        else if(CurrentCharacter.GetComponent<PlayerHealth>().healthPlayer >= 40){
            PlayerHealthBar.color = Color.green;
        }
    }
    public void OpenTree(){
        TheTree.SetActive(true);
        CloseButton.SetActive(true);
        OpenButton.SetActive(false);
        
       // mainLight = GameObject.FindGameObjectWithTag("Global");
//        mainLight.SetActive(false);
        cinemachinSwitcher.SwitchToMain();
        BackGround1.SetActive(true);
        BackGround2.SetActive(true);
        GameCanvas.SetActive(false);
        UiCamera.SetActive(false);
        MainThemePlat.Stop();
        MainThemeTree.Play();
        CombatScript.InTree = true;
        
    }

    public void SwitchMenu(){
        if(switcmenu.activeSelf == false){
            switcmenu.SetActive(true);
            MainMenu.SetActive(false);

        }
        else if(switcmenu.activeSelf == true){
            switcmenu.SetActive(false);
            MainMenu.SetActive(true);
        }
        
    }
    public void OpenMainMenu(){
        MainMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void CloseMainMenu(){
        MainMenu.SetActive(false);
        Time.timeScale = 1;
    }
    void forAdd(){
        if(karench.activeSelf == true){
            karench.GetComponent<CombatScript>().AbilityActivation();
        }
        else if(romakch.activeSelf == true){
            romakch.GetComponent<CombatScript>().AbilityActivation();
        }
        else if(avatch.activeSelf == true){
            avatch.GetComponent<CombatScript>().AbilityActivation();
        }
        else if(Nozhach.activeSelf == true){
            Nozhach.GetComponent<CombatScript>().AbilityActivation();
        }
    }

    public void Karen(){
        if(karench.activeSelf == false){
            PLayerChanged = true;
            CurrentCharacter = karench;
            karench.SetActive(true);
            avatch.SetActive(false);
            romakch.SetActive(false);
            Nozhach.SetActive(false);
            cinemachine.Follow = karench.transform;
            First.sprite = karens;
            Second.sprite = karens;
        }
    }

    public void Avat(){
        if(avatch.activeSelf == false){
            CurrentCharacter = avatch;
            PLayerChanged = true;
            karench.SetActive(false);
            avatch.SetActive(true);
            romakch.SetActive(false);
            Nozhach.SetActive(false);
            cinemachine.Follow = avatch.transform;
            First.sprite = avats;
            Second.sprite = avats;
        }
    }

    public void Romak(){
        if(romakch.activeSelf == false){
            CurrentCharacter = romakch;
            PLayerChanged = true;
            romakch.SetActive(true);
            avatch.SetActive(false);
            karench.SetActive(false);
            Nozhach.SetActive(false);
            cinemachine.Follow = romakch.transform;
            First.sprite = romaks;
            Second.sprite = romaks;
        }
    }
    public void Nozha(){
        if(Nozhach.activeSelf == false){
            CurrentCharacter = Nozhach;
            PLayerChanged = true;
            Nozhach.SetActive(true);
            romakch.SetActive(false);
            avatch.SetActive(false);
            karench.SetActive(false);
            cinemachine.Follow = Nozhach.transform;
            First.sprite = nozhas;
            Second.sprite = nozhas;
        }
    }
    public void CloseVictory(){
        VictoryPanel.SetActive(false);
    }

    public void SaveAfterVictory(){
        CurrentCharacter.GetComponent<NewPlayerMovementP>().langCodeSave = LangController.Lang;
        CurrentCharacter.GetComponent<NewPlayerMovementP>().Lvlsave = CoinManager.CurrentLevel;
        SaveDatasPlayer.SavePlayer(CurrentCharacter.GetComponent<NewPlayerMovementP>());
    }
}
