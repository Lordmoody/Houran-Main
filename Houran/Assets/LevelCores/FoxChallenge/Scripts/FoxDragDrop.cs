using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class FoxDragDrop : MonoBehaviour , IPointerDownHandler , IBeginDragHandler , IEndDragHandler , IDragHandler , IDropHandler
{
    private RectTransform rectTransform;
    public RectTransform home;
    private CanvasGroup canvasGroup;
    [SerializeField] private Canvas canvas;
    public GameObject fakeCard;
    public SpriteRenderer RealCard;
    public GameObject realCardO;
    public FoxCanvas foxCanvas;
    public Animator thisBurn;
    public FoxTTS foxTTS;
    public AudioSource music;
    public int thisText;
    
    private void Awake(){
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    void Update(){
       
    }
    public void OnBeginDrag(PointerEventData eventData){
        canvasGroup.blocksRaycasts = false;
        fakeCard.SetActive(true);
        RealCard.enabled = false;
        music.volume = 0.05f;
        Invoke("callTTs" , 0.2f);
        Invoke("IncreaseSound" , 1.2f);

    }
    public void OnDrag(PointerEventData eventData){
        if(FoxCanvas.PointerDis == false){
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
        else if(FoxCanvas.PointerDis == true){
            rectTransform.anchoredPosition = home.anchoredPosition;
        }
        
    }
    public void OnEndDrag(PointerEventData eventData){
        canvasGroup.blocksRaycasts = true;
        if(FoxSlot.here == true){
            Debug.Log("here");
            foxCanvas.CorrectSelected();
          //  thisBurn.SetBool("burn" , true);
          //  Invoke("disthis" , 1.1f);
          realCardO.SetActive(false);
            FoxSlot.here = false;
            FoxSlot.wc = 0;
           
        }
        else{
            if(FoxSlot.fwrong == true){
                
                foxCanvas.FirstWrongSelected();
                FoxSlot.fwrong = false;
            }
            else if(FoxSlot.secWrong == true){
                
                foxCanvas.SecWrongSelect();
                FoxSlot.secWrong = false;
            }
            
            rectTransform.anchoredPosition = home.anchoredPosition;
            
            
        }
        fakeCard.SetActive(false);
        RealCard.enabled = true;
    }

    void disthis(){
        realCardO.SetActive(false);
    }
    void callTTs(){
        foxTTS.StartSpeaking(foxCanvas.myWordList.words[thisText].en);
    }
    void IncreaseSound(){
        music.volume = 0.2f;
    }
    public void OnPointerDown(PointerEventData eventData){
       
    }
    
    public void OnDrop(PointerEventData eventData){

    }
}
