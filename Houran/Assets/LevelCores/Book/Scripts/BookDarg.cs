using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BookDarg : MonoBehaviour , IPointerDownHandler , IBeginDragHandler , IEndDragHandler , IDragHandler , IDropHandler
{
    private RectTransform rectTransform;
    public Transform home , dest;
    private CanvasGroup canvasGroup;
    public Animator thisanim;
    public GameObject textthis , wholechar ;
    public SpriteRenderer charsp;
    public Image cadr;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Camera mainCamera;
    bool end = false;
    // Start is called before the first frame update
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if(end == false){
            if(BookSlot.here == true && this.gameObject.tag != "chosen"){
                ForChecking();
                end = true;
            }
        }
    }
    public void OnBeginDrag(PointerEventData eventData){
        canvasGroup.blocksRaycasts = false;
        textthis.SetActive(false);

    }
    public void OnDrag(PointerEventData eventData){
        //rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        this.transform.position = mouseWorldPosition;
        
    }
    public void OnEndDrag(PointerEventData eventData){
        canvasGroup.blocksRaycasts = true;
        ForChecking();
    }
    void ForChecking(){
        if(BookSlot.here == true && this.gameObject.tag == "chosen"){
            this.transform.position = dest.position;
            charsp.enabled = false;
            cadr.enabled = false;

        }
        else if(BookSlot.here == true && this.gameObject.tag != "chosen"){
            thisanim.SetBool("burn" , true);
            textthis.SetActive(false);
            cadr.enabled = false;
            Invoke("disactivate" , 1.5f);
        }
        else if(BookSlot.here == false){
            this.transform.position = home.position;
            textthis.SetActive(true);
        }
    }

    void disactivate(){
        wholechar.SetActive(false);
    }

   
    public void OnPointerDown(PointerEventData eventData){
       
    }
    
    public void OnDrop(PointerEventData eventData){

    }
}
