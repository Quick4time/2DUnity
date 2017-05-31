using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySingletonManager : MonoBehaviour {
    // статическое свойство синглтона
    public static MySingletonManager Instance { get; private set; }

    // public свойство менеджера
    public string MyTestProperty = "Hello World";

    private void Awake()
    {
        // First we  check if there are any other instances conflicting.
        // Сперва мы проверяем сцену на наличие других примеров (other instances conflicting).
        if (Instance != null && Instance != this)
        {
            // Destroy other instances if they are not the same.
            // Уничтожаем эти примеры если они присутствуют в сцене.
            Destroy(gameObject);
        }

        // Save our current singletone instance.
        // Сохраняем текущий пример синглтон.
        Instance = this;

        // Make sure that the instance is not destroyed between scenes
        // Делам так что бы пример не уничтожался при переходе между сценами.
        DontDestroyOnLoad(gameObject);
    }
    // public method for manager.
    public void HelloWorld()
    {
        Debug.Log(MyTestProperty);
    }
}
