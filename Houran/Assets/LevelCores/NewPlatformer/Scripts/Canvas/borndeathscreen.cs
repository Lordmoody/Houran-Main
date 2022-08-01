using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class borndeathscreen : MonoBehaviour
{
    public Animator deathborn;
    // Start is called before the first frame update
    void Start()
    {
        deathborn.SetTrigger("born");
        PlayerHealth.playerDied = false;
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
