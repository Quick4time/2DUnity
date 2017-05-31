using UnityEngine.SceneManagement;
using UnityEngine;

public class MissionManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    int curLevel { get; set; } // Обьявляем публичным полем только при сохранении сцены, также устанавливаем свойство private set
    int maxLevel { get; set; } // Обьявляем публичным полем только при сохранении сцены, также устанавливаем свойство private set 

    public void Startup()
    {
        Debug.Log("Mission manager starting...");

        status = ManagerStatus.Started;
    }

    public void GoToNext()
    {
        if (curLevel < maxLevel)// Рассылаем аргументы вместе с обектом WWW, используя обьект WWWForm.
        {
            curLevel++;
            string name = "Level" + curLevel;// Нужно называть свои уровни так Level1 т.е string Level и номер уровня.
            Debug.Log("Loading " + name);
            SceneManager.LoadScene(name); // Проверяем, дстигнут ли последний уровень.// Application.LoadLevel устаревшая используем using UnityEngine.SceneManagement; 
        }
        else
        {
            Debug.Log("Last level");
            //Messenger.Broadcast(GameEvent.GAME_COMPLETE);
        }
    }
    public void UpdateData(int curLevel, int maxLevel)
    {
        this.curLevel = curLevel;
        this.maxLevel = maxLevel;
    }

    public void ReachObjective()
    {
        // здесь может быть код обработки нескольких целей.
        //Messenger.Broadcast(GameEvent.LEVEL_COMPLETE);
    }
    public void RestartCurrent()
    {
        string name = "Level" + curLevel;
        Debug.Log("Loading " + name);
        SceneManager.LoadScene(name);
    }
}
