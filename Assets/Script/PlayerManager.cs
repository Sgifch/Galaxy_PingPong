using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class PlayerManager : NetworkBehaviour
{
    public GameObject card1;
    public GameObject card2;
    public GameObject PlayerArea;
    public GameObject EnemyArea;
    public GameObject DropZone;

    List<GameObject> cards = new List<GameObject>();

    public override void OnStartClient()
    {
        base.OnStartClient();
        PlayerArea = GameObject.Find("AreaBattleCard1");
        EnemyArea = GameObject.Find("AreaBattleCard2");
        DropZone = GameObject.Find("AreaCard");
    }

    [Server]

    public override void OnStartServer()
    {
        base.OnStartServer();

        cards.Add(card1);
        cards.Add(card2);
        Debug.Log(cards);

    }

    [Command]

    public void CmdDealCards()
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject card = Instantiate(cards[Random.Range(0, cards.Count)], new Vector2(0, 0), Quaternion.identity);
            NetworkServer.Spawn(card, connectionToClient);
            RpcShowCard(card, "Dealt");
        }
    }

    [ClientRpc]

    void RpcShowCard(GameObject card, string type)
    {
        if (type == "Dealt")
        {
            if (isOwned)
            {
                card.transform.SetParent(PlayerArea.transform, false);
            }
            else
            {
                card.transform.SetParent(EnemyArea.transform, false);
            }

        }
        else if (type == "Player")
        {

        }
        
    }
}

