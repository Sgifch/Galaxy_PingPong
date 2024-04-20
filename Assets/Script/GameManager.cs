using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameManager : NetworkBehaviour
{
    public GameObject Spawn;
    public GameObject Ball;

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

}
