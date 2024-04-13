using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DragD : NetworkBehaviour
{
    public PlayerManager PlayerManager;

    private bool isDragging = false;
    private bool isDraggable = true;
    private GameObject startParent;
    private Vector2 startPosition;
    private bool isOverDropZone;
    public GameObject Canvas;
    private GameObject dropZone;
    //public GameObject DropZone;
    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        if (!isOwned)
        {
            isDraggable = false;
        }
        //DropZone = GameObject.Find("AreaCard");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isOverDropZone = true;
        dropZone = collision.gameObject;
        //Debug.Log("Colliding!");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        dropZone = null;
        //Debug.Log("Uncolliding");
    }

    public void StartDrag()
    {
        if (!isDraggable) return;
        isDragging = true;
        startParent = transform.parent.gameObject;
        startPosition = transform.position;

    }
    
    public void EndDrag()
    {
        if (!isDraggable) return;
        isDragging = false;
        if (isOverDropZone)
        {
            transform.SetParent(dropZone.transform, false);
            isDraggable = false;
            NetworkIdentity networkIdentity = NetworkClient.connection.identity;
            PlayerManager = networkIdentity.GetComponent<PlayerManager>();
            PlayerManager.PlayCard(gameObject);
        }
        else
        {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }
    }

    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true);
        }
    }
}
