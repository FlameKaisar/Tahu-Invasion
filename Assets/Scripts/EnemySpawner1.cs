using System.Collections;
using UnityEngine;

public class EnemySpawner1 : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public int waves = 5;
    public float timeBetweenWaves = 5f;
    public float timeBetweenEnemies = 1f;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        for (int wave = 0; wave < waves; wave++)
        {
            Debug.Log("Wave " + (wave + 1));
            yield return new WaitForSeconds(timeBetweenWaves);

            for (int i = 0; i < spawnPoints.Length; i++)
            {
                for (int j = 0; j < enemyPrefabs.Length; j++)
                {
                    SpawnEnemy(spawnPoints[i], enemyPrefabs[j]);
                    yield return new WaitForSeconds(timeBetweenEnemies);
                }
            }
        }
    }

    void SpawnEnemy(Transform spawnPoint, GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}