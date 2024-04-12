using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ButttonReady : NetworkBehaviour
{
    public GameObject card1;
    public GameObject card2;
    public GameObject PlayerArea;

    public PlayerManager playerManager;

    public void OnClick()
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerManager = networkIdentity.GetComponent<PlayerManager>();
        playerManager.CmdDealCards();
        
        /*for (int i=0; i<6; i++)
        {
            GameObject card = Instantiate(card1, new Vector2(0, 0), Quaternion.identity);
            card.transform.SetParent(PlayerArea.transform, false);
        }*/
    }


}
