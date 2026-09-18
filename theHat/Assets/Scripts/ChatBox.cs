using System;
using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class ChatBox : MonoBehaviour
{
    List<string> chatLogs = new List<string> {"","","",""};
    public TextMeshProUGUI[] chatText;

    public void Start()
    {
        UpdateChatPanel();
    }

    public void OnMessageEnter(TMP_InputField message)
    {

            chatLogs.RemoveAt(0);
            chatLogs.Add(message.text);
            
            UpdateChatPanel();
    }

    public void UpdateChatPanel()
    {
        for (int x = 0; x<4; x++)
        {
            chatText[x].text = chatLogs[x];
        }
    }


}
