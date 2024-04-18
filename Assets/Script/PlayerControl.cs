using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerControl : NetworkBehaviour
{
    private Rigidbody2D rb;
    private Camera mainCam;

    public float xLimit = 7f;
    public float speed = 1f;
    
    private float AxisGo;

    void Awake()
    {
        mainCam = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //не совершать действия если это не локальный игрок
        if (!isLocalPlayer) return;

        AxisGo = Input.GetAxis("Horizontal");
        transform.Translate(AxisGo * speed, 0f, 0f);

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -xLimit, xLimit);
        transform.position = position;

        CameraRotation();
    }

    void CameraRotation()
    {
        mainCam.transform.rotation = Quaternion.LookRotation(rb.velocity);
    }
}
