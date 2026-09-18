using System;
using TMPro;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ChatBox : MonoBehaviourPunCallbacks
{
    List<string> chatLogs = new List<string> {"","","",""};

    [Header("Chat Boxes")]
    public TextMeshProUGUI[] chatText;
    public GameObject _ChatBoxContainer;

    public static ChatBox instance;

    void Awake()
    {
        instance = this;
    }

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

            photonView.RPC("UpdateChatPanel", RpcTarget.All);
    }

    [PunRPC]
    public void UpdateChatPanel()
    {
        for (int x = 0; x<4; x++)
        {
            chatText[x].text = chatLogs[x];
        }
    }


}
