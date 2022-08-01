using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static int AllCoins = 400;
    public static int CurrentLevel = 0;
    int coinforUI;
    public Text  lvl;
    public GameObject blocker;
    public GameObject ErrorPanel;
    // Start is called before the first frame update
    void Start()
    {
        coinforUI = AllCoins;
        
        lvl.text = CurrentLevel.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(coinforUI > AllCoins){
            coinforUI -= 1;
            
        }
        else if(coinforUI < AllCoins){
            coinforUI += 1;
            
        }
    }

    public void CloseError(){
        ErrorPanel.SetActive(false);
        blocker.SetActive(false);
        pan.pann = true;
    }
}
