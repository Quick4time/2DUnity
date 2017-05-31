using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Получатель сообщения.
public class MessagingClientReciver : MonoBehaviour
{
    private void Start()
    {
        MessagingManager.Instance.Subscribe(TestMessage);
    }
    void TestMessage()
    {
        Debug.Log("Test Message");
    }
    private void OnDestroy()
    {
        MessagingManager.Instance.UnSubscribe(TestMessage);
    }
}
