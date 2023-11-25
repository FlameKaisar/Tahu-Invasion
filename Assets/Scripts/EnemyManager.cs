using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public int enemiesPerWave;
    public int totalWaves;
    public float timeBetweenWaves = 5f;

    [SerializeField]
    private int currentWave = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (currentWave < totalWaves)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            SpawnWave();
        }
    }

    void SpawnWave()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            for(int j = 0; j < enemiesPerWave; j++)
            {
                GameObject enemy = Instantiate(enemyPrefab, spawnPoints[i].position, Quaternion.identity);
            }
        }

        currentWave++;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
