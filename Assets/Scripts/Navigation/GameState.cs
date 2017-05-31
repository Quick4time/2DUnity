using System.Collections.Generic;
using UnityEngine;

public static class GameState
{
    // Код возвращает позицию возле позиции прехода сцены.
    // Track the player's stats
    public static Player CurrentPlayer = ScriptableObject.CreateInstance<Player>();
    // A flag to note whether the player is running home away from a battle.
    public static bool PlayerReturningHome;
    // A dictonaru to record the scenes the player has been to and the last position they were in that scene.
    public static Dictionary<string, Vector3> LastScenePosition = new Dictionary<string, Vector3>();

    public static Vector3 GetLastScenePosition (string sceneName)
    {
        // When you request a value from dictonary, it checks whether it exists first and then returns it.
        if (LastScenePosition.ContainsKey(sceneName))
        {
            Vector3 lastPos = LastScenePosition[sceneName];
            return lastPos;
        }
        // if the value dosen't exist in the dictonary yet, it returns a default value.
        else
        {
            return Vector3.zero;
        }
    }

    public static void SetLastScenePosition (string sceneName, Vector3 position)
    {
        // When you add a new value to the dictionary, it checks whether it already exists, and if it does, then it updates the existing value.
        if (LastScenePosition.ContainsKey(sceneName))
        {
            LastScenePosition[sceneName] = position;
        }
        // if valye does not exist when you try to add it, it just adds it to the dictonary.
        else
        {
            LastScenePosition.Add(sceneName, position);
        }
    }
}
