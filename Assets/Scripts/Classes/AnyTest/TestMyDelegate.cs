using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMyDelegate : MonoBehaviour {

    // Мы можем переключать State из другого кода.
    Delegates action;
    DelegatePattern actionPattern;

   // Delegates.Manager manager;
    private void Awake()
    {
        Event.OnClicked += ClickTest; // Добавляем слушателя для Event'a
        action = gameObject.GetComponent<Delegates>();
        actionPattern = gameObject.GetComponent<DelegatePattern>();
        //manager = action.GetComponent<Manager>();
    }
    private void Update()
    {
        //actionPattern.DoSomeWork();
        //actionPattern.DoSomeWorkWithLambda();
        //action.DoRobotRun();
    }
    private void OnDestroy()
    {
        Event.OnClicked -= ClickTest; // Удаляем подписчика для Event.OnClicked.
    }
    void ClickTest()
    {
        Debug.Log("OnClick");
    }
}
