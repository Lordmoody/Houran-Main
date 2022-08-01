using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FoxCanvas : MonoBehaviour
{
    public static string CorrectWord;
    public string[] words;
    int w = 0;
    public Animator flipper , DeckChangeanim;
    public GameObject[] Coins;
    public AudioSource CoinSound , sigh;
    public ParticleSystem skelet;
    int c = 0;

    /// for json reader func
    public TextAsset textJasoneng;
    public string gamePath;
  
    [System.Serializable]
    public class Words{
        public string en;
        public string per;
    }
    [System.Serializable]
    public class Winsent{
        public string sent;
        public string psent;
    }

    [System.Serializable]
    public class WordList{
        public Words[] words;
        public Winsent[] winsent;
    }
    
    public WordList myWordList = new WordList();

    public Text[] cardTexts;
    public Text MainWordCard;
    public SpriteRenderer picCardPic;
    public Sprite[] picsforCard;
    float timeGame = 0;
    public Image clock;
    bool timeC = false , StartCaounting = true;
    public GameObject Blocker;
    public static bool PointerDis = false;
    int ScoreTear = 0;
    public Text TearText , score , sentence;
    public ParticleSystem pointTaken;
    public Animator endmenuanim , corruption;
    int corrupts = 1;
    public string namescene;

    // Start is called before the first frame update
    void Awake()
    {
        Statics();
        JsonReaderFunc();
        CorrectWord = words[0];
    }

    void Start(){

    }

    // Update is called once per frame
    void Update()
    {
        
        if(timeGame <= 9){
            if(StartCaounting == true){
                timeGame += Time.deltaTime;
                clock.fillAmount = timeGame * 0.11f;
            }
            
        }
        else if(timeGame > 9 && timeC == false){
            StartCaounting = false;
            FirstWrongSelected();
            FoxSlot.fwrong = false;
            FoxSlot.secWrong = true;
            FoxSlot.wc += 1;

        }
        else if(timeGame > 9 && timeC == true){
            StartCaounting = false;
            SecWrongSelect();
            FoxSlot.secWrong = false;
            FoxSlot.wc = 0;
            timeC = false;
        }

        if(w >= 4){
            StartCaounting = false;
            Invoke("EndShow" , 0.5f);
        }
        
    }

    void EndShow(){
        score.text = ScoreTear.ToString();
        sentence.text = myWordList.winsent[ScoreTear].psent;
        endmenuanim.SetInteger("score" , ScoreTear);
    }
    void TimeCountFirst(){
        timeGame = 0;
        timeC = true;
    }

    void TimeCountSec(){
        timeGame = 0;
        timeC = false;
    }
    void StartNow(){
        StartCaounting = true;
        Blocker.SetActive(false);
        PointerDis = false;
    }
        public void CorrectSelected(){
            Blocker.SetActive(true);
            PointerDis = true;
            StartCaounting = false;
            ScoreTear += 1;
            TearText.text = ScoreTear.ToString();
            pointTaken.Play();
            if(FoxSlot.wc > 0){
                flipper.SetInteger("flip" , 1);
                Invoke("ChangeDeck" , 0.8f);
                Invoke("ChangeWords" , 2.5f);
                Invoke("StartNow" , 2.6f);
            }
            else{
                DeckChangeanim.SetTrigger("true");
                Invoke("ChangeWords" , 1.1f);
                Invoke("StartNow" , 1.5f);
            }
            TimeCountSec();

    }
    void ChangeWords(){
        if(w < 3){
            w += 1;
            CorrectWord = words[w];
            MainWordCard.text = myWordList.words[w].per;
            picCardPic.sprite = picsforCard[w]; 
        }
        else {
            w += 1;
        }
    }
    void ChangeDeck(){
        flipper.SetInteger("flip" , 2);
        DeckChangeanim.SetTrigger("true");
    }
    void ChangeDeckForWrong(){
        flipper.SetInteger("flip" , 2);
        DeckChangeanim.SetTrigger("change");
    }

    public void FirstWrongSelected(){
        PointerDis = true;
        Blocker.SetActive(true);
        flipper.SetInteger("flip" , 0);
        CoinCost();
        TimeCountFirst();
        Invoke("StartNow" , 0.4f);
    }
    public void SecWrongSelect(){
        corruption.SetInteger("stage" , corrupts);
        corrupts += 1;
        PointerDis = true;
        Blocker.SetActive(true);
        flipper.SetInteger("flip" , 1);
        skelet.Play();
        sigh.Play();
        Invoke("ChangeDeckForWrong" , 0.8f);
        GameObject.FindGameObjectWithTag(CorrectWord).GetComponent<Animator>().SetBool("burn" , true);
        Invoke("forSecDis" , 1.1f);
        TimeCountSec();
        Invoke("StartNow" , 2.5f);
    }


    void CoinCost(){
        Coins[c].SetActive(false);
        if(c < 3){
            c += 1;
        }
        CoinSound.Play();
    }
    void forSecDis(){
        GameObject.Find(CorrectWord).SetActive(false);
        if(w < 3){
            w += 1;
            CorrectWord = words[w];
            MainWordCard.text = myWordList.words[w].per;
            picCardPic.sprite = picsforCard[w]; 
        }
        else {
            w += 1;
        }
    }


    void JsonReaderFunc(){
        gamePath = Application.dataPath + "/Resources";
        //set the downloadfile to game path
        //  var dlpath = new DownloadHandlerFile(gamePath);
         textJasoneng = Resources.Load<TextAsset>("JSONFox");
         myWordList = JsonUtility.FromJson<WordList>(textJasoneng.text);
         for(int t = 0; t < 4; t++){
             cardTexts[t].text = myWordList.words[t].en;
         }
         MainWordCard.text = myWordList.words[0].per;
         picCardPic.sprite = picsforCard[0]; 
    }

    void Statics(){
        PointerDis = false;
        FoxSlot.fwrong = false;
        FoxSlot.secWrong = false;
        FoxSlot.here = false;
        FoxSlot.wc = 0;
    }
    public void Restart(){
        SceneManager.LoadScene(namescene);
    }
}
