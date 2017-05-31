using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DelegatePattern : MonoBehaviour {

    delegate void LambdaDelegate();
    private Worker myWorker = new Worker();
    LambdaDelegate lamdaDelegate;

    void Start()
    {
        //DoSomeWork();
        lamdaDelegate = () => { print("lambdaDelegate"); };
    }

    void Update()
    {
        lamdaDelegate();
        //DoSomeWorkWithLambda();
    }
    public void SomeWork1()
    {
        Debug.Log("SomeWork1");
    }
    public void SomeWork2()
    {
        Debug.Log("SomeWork2");
    }
    public void DoSomeWork()
    {
        // Send worker to do job 1
        // Посылаем выполнять первую работу.
        myWorker.DoSomeShit("Manager1", SomeWork1);
        // Send worker to do job 2
        // Посылаем выполнять вторую работу.
        myWorker.DoSomeShit("Manager1", SomeWork2);
    }
    public void DoSomeWorkWithLambda()
    {
        // Send worker to do job 1
        // Посылаем выполнять первую работу.
        myWorker.DoSomeShit("Manager1", () => { Debug.Log("SomeWorkWithLambda1"); });
        myWorker.DoSomeShit("Manager1", () => { Debug.Log("SomeWorkWithLambda2"); });
    }
    public class Worker
    {
        List<string> WorkCompleteFor = new List<string>();
        public void DoSomeShit(string ManagerName, Action myDelegate)
        {
            // Audits that work was done for which manager
            // Проверяем сделаную работу и каким менеджером она была сделана.
            WorkCompleteFor.Add(ManagerName);
            // Begin work
            // Начинаем работу
            myDelegate();
        }
    }
}
