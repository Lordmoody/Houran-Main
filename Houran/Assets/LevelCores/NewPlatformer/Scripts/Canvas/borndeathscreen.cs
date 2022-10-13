using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class borndeathscreen : MonoBehaviour
{
    public Animator deathborn;
     PlayerHealth playerHealth;
    public Script script;
    // Start is called before the first frame update
    void Start()
    {   
        playerHealth = script.CurrentCharacter.GetComponent<PlayerHealth>();
        deathborn.SetTrigger("born");
        if(PlayerHealth.playerDied == true){
            playerHealth.healthPlayer = 100f;
            PlayerHealth.playerDied = false;
            script.CurrentCharacter.GetComponent<Collider2D>().enabled = true;
            script.CurrentCharacter.GetComponent<CombatScript>().enabled = true;
            script.CurrentCharacter.GetComponent<NewPlayerMovementP>().enabled = true;
        }
        
        
    }

    public void Death(){
        deathborn.SetBool("death" , true);
        Invoke("reload" , 1.1f);
    }

    void reload(){
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
