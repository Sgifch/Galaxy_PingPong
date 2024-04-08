using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragD : MonoBehaviour
{
    private bool isDragging = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartDrag()
    {
        isDragging = true;
    }
    
    public void EndDrag()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }
}
