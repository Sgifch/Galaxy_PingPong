using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BallSpawn : NetworkBehaviour
{
    public GameObject Spawn;
    public GameObject Ball;

    public void StartSpawn()
    { 
        CmdStartSpawn();     
    }

    [Command]
    void CmdStartSpawn()
    {
        print("1");
        GameObject prefab = Instantiate(Ball, Spawn.transform.position, Spawn.transform.rotation);
        NetworkServer.Spawn(prefab, connectionToClient);
        print("2");
    }
}
