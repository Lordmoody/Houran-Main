using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class borndeathscreen : MonoBehaviour
{
    public Animator deathborn;
    public PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        deathborn.SetTrigger("born");
        if(PlayerHealth.playerDied == true){
            playerHealth.healthPlayer = 100f;
            PlayerHealth.playerDied = false;

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
