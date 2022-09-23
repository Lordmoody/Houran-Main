using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TaskUIManager : MonoBehaviour
{
    //Dialouge Panel
  

    public GameObject DialougePanel;
    public GameObject tskButton;
    public GameObject TextDial;
    public GameObject InfoButton;


    
    public static string TskName;
    public static string EnteredTsk;
    public static int EnNumForThis;
    public static bool ATaskRunning = false;
    
    public GameObject TreeButton;
    //

    //InfoPanel
    public GameObject InfoPanel;
    public Text InfoText;
    [System.Serializable]
    public class InfoClass{
        public string txt;
    }
    [System.Serializable]
    public class InfoList{
        public InfoClass[] Info; 
    }
    public InfoList myInfoList = new InfoList();
    public TextAsset textJson;
    public string gamePath;
    public static GameObject EnteredChar;
    
    public static int CharNumber;


    [System.Serializable]
    public class TskClass{
        public string txt;
    }

    [System.Serializable]
    public class TskList{
        public TskClass[] Info;
    }
    public TskList myTskList = new TskList();
    public TextAsset textJsonTsk;

    

    public TextTypeMode textTypeMode;
    
    //
    public Searcher searcher;
    public static int childrenNum;
    public GameObject CurrentChild;
    public Animator CharANim;
    public int NeededLength;
    public PanelItemGive panelItemGive;
    public static GameObject GuideToThis;





    //for Errors
    public GameObject ErrorPanel;
    public Text ErrorText , LvlText;
    [System.Serializable]
    public class ErrorClass{
        public string txt;
    }

    [System.Serializable]
    public class ErrorList{
        public ErrorClass[] Errors;
    }
    public ErrorList myErrorList = new ErrorList();
    public TextAsset textJsonError;
    public UnityEvent OnAccepted;
    public GameObject AcceptBtn , DeclineBtn;



    ///end
    //ForInof
    public Text[] InfoTxts;
    public GameObject[] Ticks;
    SideCharacterController sideinfo;
///end
    // Start is called before the first frame update
    void Start()
    {
         gamePath = Application.dataPath + "/Resources";
         //set the downloadfile to game path
         //  var dlpath = new DownloadHandlerFile(gamePath);
         textJson = Resources.Load<TextAsset>("JSONInfo");
         myInfoList = JsonUtility.FromJson<InfoList>(textJson.text);

         textJsonTsk = Resources.Load<TextAsset>("JSONTsk");
         myTskList = JsonUtility.FromJson<TskList>(textJsonTsk.text);

         textJsonError = Resources.Load<TextAsset>("JSONError");
         myErrorList = JsonUtility.FromJson<ErrorList>(textJsonError.text);
    }

   

    public void OpenDialouge(){
        tskButton.SetActive(false);
        DialougePanel.SetActive(true);
        textTypeMode.FullText = myTskList.Info[CharNumber].txt;
        if(CharANim != null){
            CharANim.SetBool("Talk" , true);
        }
        TextDial.SetActive(true);
        StartCoroutine(textTypeMode.ShowText());
        TreeButton.SetActive(false);
    }

    public void Accepttsk(){
        ATaskRunning = true;
        AcceptBtn.SetActive(false);
        DeclineBtn.SetActive(false);
        TskName = EnteredTsk;
        EnteredChar.GetComponent<SideCharacterController>().ThisTskAccepted = true;
        searcher.SearchFor(TskName);
        searcher.Founded.GetComponent<ChildrenList>().children[childrenNum].SetActive(true);
        CurrentChild = searcher.Founded.GetComponent<ChildrenList>().children[childrenNum];
        DialougePanel.SetActive(false);
        InfoButton.SetActive(true);
        TreeButton.SetActive(true);
        CheckForGuide.Targetnum = EnteredChar.GetComponent<SideCharacterController>().EndNumGuide;
        OnAccepted.Invoke();
        panelItemGive.SetImages();
        Debug.Log(EnteredChar.gameObject.name);
        
        
    }
    
    public void DeclineTsk(){
        DialougePanel.SetActive(false);
         TreeButton.SetActive(true);
         AcceptBtn.SetActive(false);
        DeclineBtn.SetActive(false);
    }

    public void OpenInfo(){
        InfoButton.SetActive(false);
        InfoPanel.SetActive(true);
        sideinfo = EnteredChar.GetComponent<SideCharacterController>();
        if(LangController.Lang == "Eng"){
           // InfoText.text = EnteredChar.GetComponent<SideCharacterController>().ENGwords;
              for(int i = 0; i < InfoTxts.Length ; i++){
                InfoTxts[i].text = sideinfo.myWordList.Words[i].name;
              }
        }
        else if(LangController.Lang == "Fr"){
           // InfoText.text = EnteredChar.GetComponent<SideCharacterController>().FRwords;
            for(int i = 0; i < InfoTxts.Length ; i++){
                InfoTxts[i].text = sideinfo.myWordList.Words[i].fr;
              }
        }
        
    }
    public void ClosInfo(){
        InfoPanel.SetActive(false);
        InfoButton.SetActive(true);
    }

    void DisDialPanel(){
        DialougePanel.SetActive(false);
        InfoButton.SetActive(true);
        TreeButton.SetActive(true);
    }
    void DisDialPanelDeclined(){
        DialougePanel.SetActive(false);
         TreeButton.SetActive(true);
    }
    void ActiveText(){
        TextDial.SetActive(true);
        StartCoroutine(textTypeMode.ShowText());
    }

    public void ErrorFunc(string errortxt , string lvlShow){
        ErrorPanel.SetActive(true);
        ErrorText.text = errortxt;
        LvlText.text = lvlShow;
    }
}
