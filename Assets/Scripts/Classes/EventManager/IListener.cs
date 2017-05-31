using System.Collections;
using UnityEngine;

public enum EVENT_TYPE { CONVERSATION, TRAVEL }

public interface IListener
{
    void OnEvent(EVENT_TYPE Event_Type, Component Sender, object Param = null);
}
