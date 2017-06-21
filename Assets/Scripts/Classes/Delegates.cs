using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Delegates : MonoBehaviour
{
    #region ConfigurablePattern (Пояснение кода: обновляем исключительно состояние RobotAction() через свойство MyRobotAction);(Использование метода как переменной); 
    // Define delegate method signature.
    // Установвить делегату метод подписания.
    public delegate void RobotAction();

    public delegate void DelTest();
    // private property for delegate use.
    // Свойство для использования делегатом.
    DelTest myDeltest;
    RobotAction myRobotAction;

    private void Start()
    {
        // Set the default method for the delegate.
        // Установить метод по умолчанию для делегата.
        myRobotAction = RobotWalk;
        //myDeltest = DoMyDeltest;
        //StartCoroutine(SwithStatement());
    }
    public void Update()
    {
        //myDeltest();
        // Run the selected delegate method on update.
        // Запустить установленый делегату метод в Update.
        myRobotAction();
    }
    // public metgod to tell the robot to walk.
    // публичный метод указывающий роботу идти.
    public void DoRobotWalk()
    {
        // set the delegate method to the walk function.
        // Устанавливаем делегату метод к функции ходьбы.
        myRobotAction = RobotWalk;
    }
    void RobotWalk()
    {
        Debug.Log("Robot walking");
    }
    // public metgod to tell the robot to run.
    // публичный метод указывающий роботу бежать.
    public void DoRobotRun()
    {
        // set the delegate method to the run function.
        // Устанавливаем делегату метод к функции бега.
        myRobotAction = RobotRun;
    }

    public void DoMyDeltest()
    {
        myDeltest = MyDeltest;
    }
    void MyDeltest()
    {
        Debug.Log("MyDeltest");
    }
    void RobotRun()
    {
        Debug.Log("Robot running");
    }
    IEnumerator SwithStatement()
    {
        while (true)
        {
            yield return new WaitForSeconds(4.0f);
            DoRobotRun();
            yield return new WaitForSeconds(3.0f);
            DoRobotWalk();
        }
    }

    #endregion
    #region Delegate pattern (Делегат шаблона, характера, модель)

    public class Worker
    {
        List<string> WorkCompleteFor = new List<string>();
        public void DoSomething(string ManagerName, Action myDelegate)
        {
            // Audits that work was done for which manager
            // Проверяем сделаную работу и каким менеджером она была сделана.
            WorkCompleteFor.Add(ManagerName);
            // Begin work
            // Начинаем работу
            myDelegate();
        }
    }
    public class Manager 
    {
        private Worker myWorker = new Worker();

        public void PeiceOfWork1()
        {
            // A piece of very long tedious work (tedious - утомительной).
            Debug.Log("Do some tedious work");
        }
        public void PeiceOfWork2()
        {
            // You guessed it, yet more tedious work.
            Debug.Log("Do some tedious work again");
        }
        public void DoWork()
        {
            // Send worker to do job 1
            // Посылаем выполнять первую работу.
            myWorker.DoSomething("Manager1", PeiceOfWork1);
            // Send worker to do job 2
            // Посылаем выполнять вторую работу.
            myWorker.DoSomething("Manager2", PeiceOfWork2);
        }
            // или вот так с lambda function
        public void DoWork2()
        {
        // Send worker to do job 1
        // Посылаем выполнять первую работу.
        myWorker.DoSomething("Manager1", () =>
        { // A piece of very long tedious work (tedious - утомительной).
            Debug.Log("Do some tedious work");
        });
        myWorker.DoSomething("Manager2", () =>
        { // You guessed it, yet more tedious work.
            Debug.Log("Do some tedious work again");
        });
        }
    }
    #endregion
    #region Dynamic pattern 
    public class WorkerManager
    {
        void DoWork()
        {
            DoJob1();
            DoJob2();
            DoJob3();
        }

        private void DoJob1()
        {
            //Do some filing
        }

        private void DoJob2()
        {
            //Make coffee for the office
        }

        private void DoJob3()
        {
            //Stick it to the man
        }
    }

    //A more intellegent WorkerManager
    public class WorkerManager2
    {
        //WorkerManager delegate
        delegate void MyDelegateHook();
        MyDelegateHook ActionsToDo;

        public string WorkerType = "Peon";

        //On Startup, assign jobs to the worker, note this is configurable instead of fixed
        void Start()
        {
            //Peons get lots of work to do
            if (WorkerType == "Peon")
            {
                ActionsToDo += DoJob1;
                ActionsToDo += DoJob2;
            }
            //Everyone else plays golf
            else
            {
                ActionsToDo += DoJob3;
            }
        }

        //On Update do the actions set on ActionsToDo
        void Update()
        {
            ActionsToDo();
        }

        private void DoJob1()
        {
            //Do some filing
        }

        private void DoJob2()
        {
            //Make coffee for the office
        }

        private void DoJob3()
        {
            //Play Golf
        }
    }
    #endregion
}