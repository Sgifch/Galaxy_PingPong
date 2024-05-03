using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class JoinLobby : MonoBehaviour
{
    public NetworkManager networkLobby;
    public TMP_InputField ipText;

    public void JoinLobbyButton()
    {
        string ipAddress = ipText.text;
        networkLobby.networkAddress = ipAddress;
        networkLobby.StartClient();
    }
}
