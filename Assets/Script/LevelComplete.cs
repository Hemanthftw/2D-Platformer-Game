using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
   
    private void OnTriggerEnter2D (Collider2D collusion)
    {
        if ( collusion.gameObject.GetComponent<PlayerController>() !=null )

        {

            Completlevel1();
        }

       
    }
    
    private void Completlevel1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}
