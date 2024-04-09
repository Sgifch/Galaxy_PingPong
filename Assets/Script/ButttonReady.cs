using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButttonReady : MonoBehaviour
{
    public GameObject card1;
    public GameObject card2;
    public GameObject PlayerArea;

    public void OnClick()
    {
        for (int i=0; i<6; i++)
        {
            GameObject card = Instantiate(card1, new Vector2(0, 0), Quaternion.identity);
            card.transform.SetParent(PlayerArea.transform, false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
