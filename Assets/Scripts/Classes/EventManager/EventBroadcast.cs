using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBroadcast : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (this.GetInstanceID() != Enemy.GetInstanceID()) return; Проверяет уникальность каждого игрового обьекта для которого производиться отправка сообщения.
        EventManager.Instance.PostNotification(EVENT_TYPE.CONVERSATION, this);
    }
}
