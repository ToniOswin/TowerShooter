using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] spawnPoints;
    public GameObject[] enemiesPrefabs;


    [SerializeField]
    float timeBetweenWaves;
    float timeUntilNextWave;

    int nextEnemy;

    GameManager _GameManager;
    void Start()
    {
        timeUntilNextWave = 1;
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_GameManager.IsWaveOn == true)
        {
            if(timeUntilNextWave <=0)
            {
                for(int i = 0; i < spawnPoints.Length; i++)
                {
                    nextEnemy = Random.Range(0, enemiesPrefabs.Length);
                    Instantiate(enemiesPrefabs[nextEnemy], spawnPoints[i].transform.position, enemiesPrefabs[nextEnemy].transform.rotation);
                }
                timeUntilNextWave = timeBetweenWaves;
                if(timeBetweenWaves > 3)
                {
                    timeBetweenWaves -= 0.2f;
                }
            }
            else
            {
                timeUntilNextWave -= Time.deltaTime;
            }
        }
    }
}
