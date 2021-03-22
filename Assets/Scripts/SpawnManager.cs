using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] spawnPoints;
    [SerializeField]
    GameObject[] enemiesPrefabs;


    [SerializeField]
    float timeBetweenWaves;
    float timeUntilNextWave;

    int nextEnemy;
    void Start()
    {
        timeUntilNextWave = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeUntilNextWave <=0)
        {
            for(int i = 0; i < spawnPoints.Length; i++)
            {
                nextEnemy = Random.Range(0, enemiesPrefabs.Length);
                Instantiate(enemiesPrefabs[nextEnemy], spawnPoints[i].transform.position, enemiesPrefabs[nextEnemy].transform.rotation);
            }
            timeUntilNextWave = timeBetweenWaves;
        }
        else
        {
            timeUntilNextWave -= Time.deltaTime;
        }
    }
}
