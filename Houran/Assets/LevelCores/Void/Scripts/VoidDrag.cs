using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VoidDrag : MonoBehaviour , IPointerDownHandler , IBeginDragHandler , IEndDragHandler , IDragHandler , IDropHandler
{
    private RectTransform rectTransform;
   // public RectTransform hometransform;
    private CanvasGroup canvasGroup;
    [SerializeField] private Canvas canvas;
    public RectTransform home;
    public static bool DragBegan = false;
    public string thisOne;
    public static bool Incorrect = false;
    public VoidCanvas voidy;
    public GameObject MouseFollower;
    public VoidSpeechController voidSpeech;
    public Image  MainPic;
    public GameObject textUI , wordPic;
    public AudioSource mainmusic;
  

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData){
        canvasGroup.blocksRaycasts = false;
        MouseFollower.SetActive(true);
        mainmusic.volume = 0.05f;
        Invoke("CallTTS" , 0.2f);
        Invoke("IncreaseSound" , 1.2f);
      //  wordPic.SetActive(true);
      //  textUI.SetActive(false);
      //  MainPic.enabled = false;
        
    }

    void CallTTS(){
        voidSpeech.StartSpeaking(thisOne);
    }
    void IncreaseSound(){
        mainmusic.volume = 0.2f;
    }
    public void OnDrag(PointerEventData eventData){
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData){
        canvasGroup.blocksRaycasts = true;
        if(VoidSlot.here == true){
            voidy.CorrectAnswer(thisOne);
         //   GameObject.Find(thisOne).GetComponent<Animator>().SetBool("do" , true);
            VoidSlot.here = false;
        }
        else{
            if(Incorrect == true){
                voidy.WrongAnswer(thisOne);
                Incorrect = false;
            }
            rectTransform.anchoredPosition = home.anchoredPosition;
        }
        MouseFollower.SetActive(false);
      //  wordPic.SetActive(false);
      //  textUI.SetActive(true);
       // MainPic.enabled = true;
    }
    public void OnPointerDown(PointerEventData eventData){
       
    }
    
    public void OnDrop(PointerEventData eventData){

    }
}
