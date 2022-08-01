using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro.Examples
{
public class TextTyping : MonoBehaviour
{
    private TMP_Text m_textmeshpro;
    
    private bool stop = true;
    public static bool charend = false;
    public static int charCounter;

    void Awake(){
        m_textmeshpro = GetComponent<TMP_Text>();
       
        m_textmeshpro.enableWordWrapping = true;
        
        charend = false;
       // m_textmeshpro.alignment = TextAlignmentOptions.Top;

    }
    // Start is called before the first frame update
    IEnumerator Start()
    {
      m_textmeshpro.ForceMeshUpdate();  
       // charCounter = m_textmeshpro.textInfo.characterCount;
      int totalVisibleCharacters = m_textmeshpro.textInfo.characterCount;
      int counter = 0;
      int visibleCount = 0;

      while(stop){
          visibleCount = counter % (totalVisibleCharacters+1);
          m_textmeshpro.maxVisibleCharacters = visibleCount;
          counter += 1;
          if(visibleCount >= totalVisibleCharacters){
              stop = false;
              charend = true;
              yield return new WaitForSeconds(0.05f);
          }
          else {
              yield return new WaitForSeconds(0.05f);
          }
          
      }
      
    }

    
    
}
}
