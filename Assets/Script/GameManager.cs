using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class GameManager : NetworkBehaviour
{

    public GameObject Spawn;
    public GameObject Ball;
    public TMP_Text Score1;
    public TMP_Text Score2;

    [SyncVar]
    public int numbScore1 = 0;
    [SyncVar]
    public int numbScore2 = 0;

    void Update()
    {
        Score1.text = numbScore1.ToString();
        Score2.text = numbScore2.ToString();
    }

    public void StopGame()
    {
        if (NetworkServer.active && NetworkClient.isConnected)
        {
            NetworkManager.singleton.StopHost();
        }
        else if (NetworkClient.isConnected)
        {
            NetworkManager.singleton.StopClient();
        }
        else if (NetworkServer.active)
        {
            NetworkManager.singleton.StopServer();
        }
    }

    [Server]
    public void StartSpawn()
    {
        GameObject prefab = Instantiate(Ball, Spawn.transform.position, Spawn.transform.rotation);
        NetworkServer.Spawn(prefab, connectionToClient);
        //CmdStartSpawn();
    }

    [Command]
    public void CmdStartSpawn()
    {
        print("1");
        GameObject prefab = Instantiate(Ball, Spawn.transform.position, Spawn.transform.rotation);
        NetworkServer.Spawn(prefab, connectionToClient);
        print("2");
    }

    public void CmdDestroyObject(GameObject obj, int numb)
    {
        if (numb == 1)
        {
            NetworkServer.Destroy(obj);
            numbScore1++;
            //print("1");
        }
        else
        {
            NetworkServer.Destroy(obj);
            numbScore2++;
            //print("2");
        }
    }

}
