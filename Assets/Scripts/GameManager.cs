using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChatGPTWrapper;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] ChatGPTConversation chatGPT;
    [SerializeField] TMP_InputField iF_PlayerTalk;
    [SerializeField] TextMeshProUGUI tX_AIReply;

    string npcName = "Coco";
    string playerName = "Player";


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        chatGPT.Init();
    }
    void Start()
    {
        chatGPT.SendToChatGPT("{\"player_said\":Hello! Who are you? \"}");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Submit"))
        {
            SubmitChatMessage();
        }
    }

    public void SubmitChatMessage()
    {
        if(iF_PlayerTalk.text != "")
        {
            chatGPT.SendToChatGPT("{\"player_said\":" + iF_PlayerTalk.text + "\"}");
            iF_PlayerTalk.text = "";
        }
    }

    public void ReceiveChatGPTReply(string message)
    {
        print(message);
        tX_AIReply.text = message;

        try
        {
            //
            if(!message.EndsWith("}"))
            {
                if (message.Contains("}"))
                {
                    message = message.Substring(0, message.LastIndexOf("}") + 1);
                }
                else
                {
                    message += "}";
                }
            }

            NPCJsonReceiver npcJSON = JsonUtility.FromJson<NPCJsonReceiver>(message);
            string talkLine = npcJSON.reply_to_player;
            tX_AIReply.text = "<color=#ff7082>" + npcName + "</color>" + talkLine;

        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
            string talkLine = "Don't say that!";
            tX_AIReply.text = "<color=#ff7082>" + npcName + ": </color>" + talkLine;
        }
    }
}
