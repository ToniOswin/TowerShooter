using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    SpawnManager spawnManScript;
    PlayerStats playerScript;
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
    bool gamePaused;
    [SerializeField]
    Canvas pausedCanvas;
    void Start()
    {
        gamePaused = false;
        actualTime = LevelTime;
        IsWaveOn = true;
        spawnManScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
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

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if( gamePaused == false)
            {
                PauseGame();
            }
            else
            {
                ContinueGame();
            }
        }
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
        PlayerPrefs.SetInt("Money", playerScript.money);
        SceneManager.LoadScene("GamePlay");
    }

    public void LoseGame()
    {
        PlayerPrefs.SetInt("Money", playerScript.money);
        SceneManager.LoadScene("Shop");
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        gamePaused = true;
        pausedCanvas.gameObject.SetActive(true);
    }

    void ContinueGame()
    {
        Time.timeScale = 1;
        gamePaused = false;
        pausedCanvas.gameObject.SetActive(false);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
