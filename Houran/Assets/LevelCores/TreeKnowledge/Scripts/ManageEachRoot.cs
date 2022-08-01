using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageEachRoot : MonoBehaviour
{
    public Image ProgressBar;
    public LevelAndKnowledgeManager lakm;
    public int num;
    public float Rate;
    public Image Crown;
    public Sprite FillCrown;
    public IconClicked[] Subs;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach(IconClicked sub in Subs){
            if(sub.RequiredLevel <= CoinManager.CurrentLevel){
                lakm.myProgressList.prog[num].progress += 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(ProgressBar.fillAmount != 1){
            ProgressBar.fillAmount = lakm.myProgressList.prog[num].progress * Rate;
        }
        else if(ProgressBar.fillAmount == 1){
            Crown.sprite = FillCrown;
        }
        
    }

    
}
