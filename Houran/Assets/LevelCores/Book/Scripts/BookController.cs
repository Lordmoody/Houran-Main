using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookController : MonoBehaviour
{
    public Book refBook;
    public GameObject text;



    public string gamePath;
  
    [System.Serializable]
    public class Booker{
        public string sent;
    }

    [System.Serializable]
    public class BookList{
        public Booker[] book;
    }
    
    public BookList myBookList = new BookList();
    public TextAsset textJasoneng;
    public Text mainText;
    public GameObject pic;
    int i = 2 , j = 2;
    public Sprite[] pics;
    public SpriteRenderer mainpic;
    bool setThemActive = false , charsbool = false;
    public AutoFlip autoFlip;
    public GameObject  chars2;
    public GameObject partice;
    // Start is called before the first frame update
    void Start()
    {
        gamePath = Application.dataPath + "/Resources";
      //set the downloadfile to game path
      //var dlpath = new DownloadHandlerFile(gamePath);
        textJasoneng = Resources.Load<TextAsset>("BookJSON");
        myBookList = JsonUtility.FromJson<BookList>(textJasoneng.text);
    }

    // Update is called once per frame
    void Update()
    {
        if(setThemActive == false){
            if(refBook.currentPage >= 2){

            text.SetActive(true);
            pic.SetActive(true);
                setThemActive = true;
            }
        }
        else{
            if(refBook.currentPage < 2 || refBook.currentPage > 16){
            text.SetActive(false);
            pic.SetActive(false);
            setThemActive = false;
          }
        }
         if(refBook.currentPage >=2){
             autoFlip.StopAllCoroutines();
         }

        if(refBook.currentPage == i){
            mainText.text = myBookList.book[i- j].sent;
            mainpic.sprite = pics[i-j];
            i += 2;
            j += 1; 
        }
        if(charsbool == false){
            if(refBook.currentPage == 12){
            
            chars2.SetActive(true);
            charsbool = true;
        }
        }
        else{
            if(refBook.currentPage != 12){
                
                chars2.SetActive(false);
            }
            
        }
        
    }


    public void OnFlip(){
        refBook.interactable = false;
        Invoke("inttrue" , 8f);
    }

    void inttrue(){
        refBook.interactable = true;
        partice.SetActive(true);
    }
}
