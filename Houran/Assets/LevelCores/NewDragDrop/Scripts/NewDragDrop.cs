using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewDragDrop : MonoBehaviour , IPointerDownHandler , IBeginDragHandler , IEndDragHandler , IDragHandler , IDropHandler
{
    private RectTransform rectTransform;
   // public RectTransform hometransform;
    private CanvasGroup canvasGroup;
    [SerializeField] private Canvas canvas;
    public GameObject text , triangle , particle , book , bookicon , thisword , wordbox , SWordbox , TriSpr , darkTri;
    public Animator bookanim , wordanim , LightAnim , Swordanim;
    public RectTransform home;
    public GameObject lighttt;
    public int textNumber;
    public NDDTTSController nddtts;
    public AudioSource mainmusic;
   // public NewDDCanvas newDD;
   // public int thisnum;

    private void Awake(){
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    void Update(){
       
    }
    public void OnBeginDrag(PointerEventData eventData){
        //nddtts.StartSpeaking(textNumber);
        mainmusic.volume = 0.05f;
        Invoke("CallTTS" , 0.2f);
        Invoke("IncreaseSound" , 1.2f);
        canvasGroup.blocksRaycasts = false;
        text.SetActive(false);
        triangle.SetActive(true);
        particle.SetActive(true);
    }
    void CallTTS(){
        nddtts.StartSpeaking(textNumber);
    }
    void IncreaseSound(){
        mainmusic.volume = 0.2f;
    }
    public void OnDrag(PointerEventData eventData){
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData){
        canvasGroup.blocksRaycasts = true;
        if(NewItemSlot.here == true){
          //  newDD.firstt[thisnum] = null;
          //  newDD.secondd[thisnum] = null;
            NewDDCanvas.score += 1;
            lighttt.gameObject.tag = "lightened";
            NewDDCanvas.lightScore -= 1;
            triangle.SetActive(false);
            particle.SetActive(false);
            wordanim.SetBool("burn" , true);
            Swordanim.SetBool("burn" , true);
            wordbox.tag = "correctb";
            SWordbox.tag = "correctb";
         //   bookanim.SetBool("down" , true);
            Invoke("ForDisingifCorrect" , 1.1f);
            LightAnim.SetBool("light" , true);
            TriSpr.SetActive(true);
            NewItemSlot.here = false;
            thisword.SetActive(false);
        }
        else if(NewItemSlot.here == false){
                if(NewItemSlot.darkness == true){
               //     newDD.firstt[thisnum] = null;
           // newDD.secondd[thisnum] = null;
                    NewDDCanvas.lightScore -= 1;
                    NewDDCanvas.evilScore += 1;
                     triangle.SetActive(false);
                     particle.SetActive(false);
                  //   bookanim.SetBool("down" , true);
                   //  Invoke("ForDisActivatingBook" , 1.1f);
                     text.SetActive(true);
                     rectTransform.anchoredPosition = home.anchoredPosition;
                     NewItemSlot.darkness = false;
                 }
                 else if(NewItemSlot.darkness == false){
                     text.SetActive(true);
                     triangle.SetActive(false);
                     particle.SetActive(false);
                     rectTransform.anchoredPosition = home.anchoredPosition;
             }   
        }
    }
    public void OnPointerDown(PointerEventData eventData){
       
    }
    
    public void OnDrop(PointerEventData eventData){

    }

    void ForDisActivatingBook(){
      //  bookicon.SetActive(true);
      //  book.SetActive(false);
      //  bookanim.SetBool("down" , false);
    }
    void ForDisingifCorrect(){
        wordbox.SetActive(false);
      //  bookicon.SetActive(true);
      //  book.SetActive(false);
      //  bookanim.SetBool("down" , false);
    }
}
