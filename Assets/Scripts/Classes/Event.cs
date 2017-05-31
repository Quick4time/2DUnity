using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    // Delegate mehod definition.
    // Определяем делегат метода.
    public delegate void ClickAction();
    // Event hook using delegate method signature.
    public static event ClickAction OnClicked;

    // Safe method for calling the event.
    // Приватный метод для вызова события.
    void Clicked()
    {
        // Trigger the event delegate if there is a subscriber.
        // Проверка наличия подписчика.
        if (OnClicked != null)
        {
            OnClicked(); 
        }
    }

    private void Update()
    {
        // if the space bar is pressed, this item has been clicked
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Clicked(); // Передаем сообщение подписчикам.
        }
    }

    private void Start()
    {
        // Hook on to the function onClicked event and run the Events_OnClicked method when it occurs.
        OnClicked += Events_OnClicked;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event to clean up.
        OnClicked -= Events_OnClicked;
    }
    // Subordinate method
    void Events_OnClicked()
    {
        Debug.Log("The button was clicked");
    }
}
