using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    SpawnManager spawnManScript;
    GameObject[] enemies;

    float LevelTime = 60;
    float actualTime;
    int wave;
    public bool IsWaveOn;

    [Header("Canvas")]
    [SerializeField]
    TextMeshProUGUI WaveText;
    [SerializeField]
    TextMeshProUGUI TimeText;
    void Start()
    {
        actualTime = LevelTime;
        IsWaveOn = true;
        spawnManScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        enemies = spawnManScript.enemiesPrefabs;
        wave = PlayerPrefs.GetInt("Wave", 1);
        WaveText.text = "Wave " + wave;
        if(wave >1)
        {
            UpgradeEnemies();
        }
        else
        {
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<EnemyStats>().damage = enemy.GetComponent<EnemyStats>().baseDamage;
                enemy.GetComponent<EnemyStats>().maxHealth = enemy.GetComponent<EnemyStats>().baseMaxHealth;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameTime();
    }

    void GameTime()
    {
        TimeText.text = actualTime.ToString("F0");
        if(actualTime <= 0)
        {
            IsWaveOn = false;
            if(GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                WinGame();
            }
        }
        else
        {
            actualTime -= Time.deltaTime;
        }
    }

    void UpgradeEnemies()
    {
        float damageMult = (wave * 0.1f) + 1;
        float healthMult = ((wave * 0.1f) * 2) + 1;

        foreach(GameObject enemy in enemies)
        {
            float waveDamage = enemy.GetComponent<EnemyStats>().baseDamage * damageMult;
            float waveHealth = enemy.GetComponent<EnemyStats>().baseMaxHealth * healthMult;
            enemy.GetComponent<EnemyStats>().damage = waveDamage;
            enemy.GetComponent<EnemyStats>().maxHealth = waveHealth;
        }
    }

    void WinGame()
    {
        PlayerPrefs.SetInt("Wave", wave + 1);
        SceneManager.LoadScene("GamePLay");
    }
}
