using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BallMovement : NetworkBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(4, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
