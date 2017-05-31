using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Another feature of delegates is that they can be compounded, meaning you can assign multiple function to a single delegate.
// Also, when a delegate is called, all the method assigned to the delegate will run as shown in the following code.
// Thos feature is very handy when you wandt to chain several common functions together instead of one:
public class DynamicPattern : MonoBehaviour {

    // WorkerManager delegate
    delegate void MyDelegateHook();
    MyDelegateHook ActionToDo;

    public string WorkerType = "Peon";

    // On Startup, assign jobs to the worker, note this is configurable instead of fixed
	void Start ()
    { 
        // Peons get lots of work to do
        if (WorkerType == "Peon")
        {
            ActionToDo += DoJob1;
            ActionToDo += DoJob2;
        }
        else
        {
            ActionToDo += DoJob3;
        }	
	}
    // On Update do the actions set on ActionsToDo
	void Update ()
    {
        ActionToDo();
	}

    private void DoJob1()
    {
        Debug.Log("DoJob1");
    }
    private void DoJob2()
    {
        Debug.Log("DoJob2");
    }
    private void DoJob3()
    {
        Debug.Log("DoJob3");
    }
    /*
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
    }*/
}
