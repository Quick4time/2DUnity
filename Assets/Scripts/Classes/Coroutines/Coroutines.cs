using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutines : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Example2());
    }
    IEnumerator Print10Lines()
    {
        print("I started printing lines");
         for (int i = 1; i < 11; i++)
        {
            print("Line " + i.ToString());
            yield return new WaitForSeconds(2.0f);
           
        } 
    }
    void Example1()
    {
        StartCoroutine(Print10Lines());
    }
    IEnumerator Example2()
    {
        yield return StartCoroutine(Print10Lines());
        print("I have finished printing lines");
    }
}
