﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
   
    private void OnTriggerEnter2D (Collider2D collusion)
    {
        if ( collusion.gameObject.GetComponent<PlayerController>() !=null )

            {
            Debug.Log("Player finish the game");
        }
    }
    
    
    
}