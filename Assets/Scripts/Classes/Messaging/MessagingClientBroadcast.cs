using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Непосредственно передача сообщения
public class MessagingClientBroadcast : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MessagingManager.Instance.Broadcast();
        }
    }
}
