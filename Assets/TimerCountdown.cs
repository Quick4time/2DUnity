using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
[System.Serializable]
 public class Human
{
    string name;
    int Age;
}
*/
public class TimerCountdown : MonoBehaviour
{
    private float startTime;
    TMPro.TextMeshProUGUI tMesh;

   //public Human[] human = new Human[3];

	// Use this for initialization
	void Start ()
    {
        tMesh = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        startTime = Time.time;
	}
	void Update ()
    {
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2"); // f2 это сколько чисел чисел будет в string

        float floatTest = 8.0f;

        string test = (floatTest % 1.0f).ToString();

        //tMesh.text = test;

        tMesh.text = minutes + ":" + seconds;
	}
}
