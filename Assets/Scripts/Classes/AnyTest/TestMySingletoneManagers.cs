using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMySingletoneManagers : MonoBehaviour {

	void Start ()
    {
        Debug.Log("1:" + MySingletonManager.Instance.MyTestProperty);
        MySingletonManager.Instance.HelloWorld();
	}
}
