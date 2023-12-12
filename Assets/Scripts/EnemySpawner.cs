using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WaveSpawner;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawnPoints;

    public GameObject enemy;
    public int count;
    public float rate;


    public float timeBeforeStart;

    private void Start()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(timeBeforeStart);
        Debug.Log("Start : " + gameObject.name);
        for (int i = 0; i < count; i++)
        {
            if (!enemy.activeSelf)
            {
                enemy.SetActive(true);
            }
            if (spawnPoints)
            {
                Instantiate(enemy, spawnPoints.position, spawnPoints.rotation);
                yield return new WaitForSeconds(1f / rate);
            }

        }
    }


    private void Update()
    {
        if (timeBeforeStart > 0)
        {
            timeBeforeStart -= Time.deltaTime;
        }
    }
}
