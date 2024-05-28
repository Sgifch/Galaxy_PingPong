using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Gate1Script : NetworkBehaviour
{
    public GameManager gameManager;
    public Animator anim;

    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.tag == "Ball")
        {
            gameManager.CmdDestroyObject(collider.gameObject, 1);
            anim.SetBool("TriggerEnt", true);
            print("yes");
            //anim.SetBool("TriggerEnt", false);
        }
    }

    
}
