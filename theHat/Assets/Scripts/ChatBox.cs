using System;
using TMPro;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ChatBox : MonoBehaviourPunCallbacks
{
    List<string> chatLogs = new List<string> { "", "", "", "" };

    [Header("Chat Boxes")]
    public TextMeshProUGUI[] chatText;
    public GameObject _ChatBoxContainer;

    void Start()
    {
        UpdateChatPanel();
        _ChatBoxContainer.SetActive(false);
    }

    public void OnToggleChat()
    {
        if (!_ChatBoxContainer.activeSelf)
        {
            _ChatBoxContainer.SetActive(true);
        }
        else
        {
            _ChatBoxContainer.SetActive(false);
        }
    }

    public void OnMessageEnter(TMP_InputField message)
    {

        chatLogs.RemoveAt(0);
        chatLogs.Add(message.text);

        for (int x = 0; x < 4; x++)
        {
            photonView.RPC("SyncChatLogs", RpcTarget.All, x, chatLogs[x]);
        }

        photonView.RPC("UpdateChatPanel", RpcTarget.All);
    }

    [PunRPC]
    public void UpdateChatPanel()
    {
        for (int x = 0; x < 4; x++)
        {
            chatText[x].text = chatLogs[x];
        }
    }

    [PunRPC]
    public void SyncChatLogs(int x, string str)
    {
            chatLogs[x] = str;
    }

}
