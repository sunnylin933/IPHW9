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
    [SerializeField] NPCController npc;

    string npcName = "The Guide";
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
        chatGPT.SendToChatGPT("{\"player_said\":Where am I? What is happpening? \"}");
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
            chatGPT.SendToChatGPT("{\"player_said\":\"" + iF_PlayerTalk.text + "\"}");
            iF_PlayerTalk.text = "";
        }
    }

    public void ReceiveChatGPTReply(string message)
    {
        print(message);
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
            print(npcJSON.reply_to_player);
            print(npcJSON.environment);
            string talkLine = npcJSON.reply_to_player;
            tX_AIReply.text = talkLine;

            npc.ChangeScene(npcJSON.environment);
        }
        catch(Exception e)
        {
            string talkLine = "Check console for response.";
            tX_AIReply.text = talkLine;
        }
    }
}
