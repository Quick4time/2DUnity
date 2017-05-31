using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventReciver : MonoBehaviour, IListener
{
    private void Start()
    {
        EventManager.Instance.AddListener(EVENT_TYPE.CONVERSATION, this);
    }
    private void OnDestroy()
    {
        EventManager.Instance.RemoveEvent(EVENT_TYPE.CONVERSATION);
    }

    public void OnEvent(EVENT_TYPE Event_type, Component Sender, object Param = null)
    {
        switch(Event_type)
        {
            case EVENT_TYPE.CONVERSATION:
                PlayerTryingToLeave();
                break;
        }
    }
    void PlayerTryingToLeave()
    {
        var dialog = GetComponent<ConversantionComponent>();
        if (dialog != null)
        {
            if (dialog.Conversations != null && dialog.Conversations.Length > 0)
            {
                var conversation = dialog.Conversations[0];
                if (conversation != null)
                {
                    ConversationManager.Instance.StartConversation(conversation);
                }
            }
        }
    }
}
