using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollBackground : MonoBehaviour
{
    public float speed = -2f;
    public float lowerValue = -10.8f;
    public float upperValue = 10.8f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, speed * Time.deltaTime, 0f);
        if (transform.position.y <= lowerValue)
        {
            transform.Translate(0f, upperValue, 0f);
        }
    }
}
