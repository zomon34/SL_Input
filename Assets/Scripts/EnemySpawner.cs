using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;

    float circleArea = 10;
    float minDistance = 6;

    int maxEnemies = 10;
    int deadEnemies = 0;
    int currentNumberOfEnemies = 0;

    void Start()
    {
        //SpawnEnemy();
    }

    public void SpawnMoreEnemies()
    {
        player.gameObject.GetComponent<Movement>().points++;
        //deadEnemies++;
        currentNumberOfEnemies--;
        SpawnEnemy();


        //for (int i = 0; i < deadEnemies; i++)
        //{
        //    SpawnEnemy();
        //}
    }

    void SpawnEnemy()
    {
        if (currentNumberOfEnemies < maxEnemies)
        {
            currentNumberOfEnemies++;
            Vector3 randomPosition = Random.insideUnitCircle * circleArea;

            while (randomPosition.sqrMagnitude < minDistance * minDistance)
            {
                randomPosition = Random.insideUnitCircle * circleArea;
            }

            Instantiate(enemyPrefab, player.transform.position + randomPosition, transform.rotation);

        }
    }
}
