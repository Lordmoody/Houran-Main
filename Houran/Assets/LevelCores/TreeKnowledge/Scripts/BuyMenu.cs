using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyMenu : MonoBehaviour
{
    
    public GameObject buypanel;
    public AudioSource buysound;
    [HideInInspector]public GameObject TheOneToBuy;
    public Button yesbutton;
    
    public GameObject BuyParticle;
    public GameObject Blocker;
    [HideInInspector]public int Root;
    public LevelAndKnowledgeManager lakm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    public void BuyButton(){
      //  if(CoinManager.AllCoins >= cost){
       //     CoinManager.AllCoins -= cost;
        //open word panel
        buysound.Play();
        BuyParticle.transform.position = TheOneToBuy.transform.position;
        BuyParticle.GetComponent<ParticleSystem>().Play();
        TheOneToBuy.GetComponent<Ring>().ThisBought = true;
        lakm.myProgressList.prog[Root].progress += 1;
        buypanel.SetActive(false);
        Blocker.SetActive(false);
        TheOneToBuy.gameObject.tag = "Bought";
        pan.pann = true;
       // }
        
    }
    public void NoButton(){
        Blocker.SetActive(false);
        pan.pann = true;
        buypanel.SetActive(false);

    }
}
