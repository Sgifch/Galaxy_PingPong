using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Gate1Script : NetworkBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.tag == "Ball")
        {
            gameManager.CmdDestroyObject(collider.gameObject, 1);
            
        }
    }

    
}
