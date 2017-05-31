using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject[] EnemySpawnPoints;
    public GameObject[] EnemyPrefab;
    public AnimationCurve SpawnAnimationCurve;

    private int enemyCount;

    enum BattlePhase
    {
        PlayerAttack,
        EnemyAttack
    }
    private BattlePhase phase;

    private void Start()
    {
        // Calculate how many enemies
        enemyCount = Random.Range(1, EnemySpawnPoints.Length);
        // Spawn the enemies in 
        StartCoroutine(SpawnEnemies());
        // Set the begginning battle phase
        phase = BattlePhase.PlayerAttack;
    }
    // Now that we know how many Goblins we need in the battle, we can spawn them in. I've used a coroutine here soe we can animate them one by one as follow.
    IEnumerator SpawnEnemies()
    {
        // Spawn enemies in over time
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject newEnemy = (GameObject)Instantiate(EnemyPrefab[0]);
            newEnemy.transform.position = new Vector3(10, -1, 0);
            yield return StartCoroutine(MoveCharacterToPoint(EnemySpawnPoints[i], newEnemy));
            newEnemy.transform.parent = EnemySpawnPoints[i].transform;
        }
    }
    // So that the Goblins don't appear, we use the AnimationCurve parameter we added to the script and a coroutine to move the Goblin from off screen to its intended spawn point, as follows.
    IEnumerator MoveCharacterToPoint(GameObject destination, GameObject character)
    {
        float timer = 0.0f;
        Vector3 StartPosition = character.transform.position;
        if (SpawnAnimationCurve.length > 0)
        {
            while (timer < SpawnAnimationCurve.keys[SpawnAnimationCurve.length - 1].time)
            {
                character.transform.position = Vector3.Lerp(StartPosition, destination.transform.position, SpawnAnimationCurve.Evaluate(timer));
                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            character.transform.position = destination.transform.position;
            yield return null;
        }
    }

    private void OnGUI()
    {
        if (phase == BattlePhase.PlayerAttack)
        {
            if (GUI.Button(new Rect(10, 10, 100, 50), "Run Away"))
            {
                NavigationManager.NavigateTo("World");
            }
        }
    }
}
