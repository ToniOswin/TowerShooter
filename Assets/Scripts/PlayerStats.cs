using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("Life")]
    [SerializeField]
    float maxPlayerHealth;
    public float playerHealth;
    [SerializeField]
    Slider healthBar;
    [Space]
    [Header("Damage")]
    public float bulletDamage;
    public float fireBallDamage;
    [Space]
    public int money;
    [SerializeField]
    TextMeshProUGUI moneyText;
    GameManager GameMan;

    [Space]
    [Header("EnemySounds")]
    [SerializeField]
    AudioSource audioS;
    [SerializeField]
    AudioClip enemyShootSound;
    [SerializeField]
    AudioClip enemyDieSound;
    [SerializeField]
    AudioClip enemyAttackSound;
    [SerializeField]
    AudioClip enemyGetsHit;

    void Start()
    {
        maxPlayerHealth = PlayerPrefs.GetFloat("PlayerHealth", 100);
        bulletDamage = PlayerPrefs.GetFloat("PlayerDamage", 1);
        fireBallDamage = PlayerPrefs.GetFloat("PlayerFireDamage", 10);
        money = PlayerPrefs.GetInt("Money", 0);
        moneyText.text = money.ToString();
        playerHealth = maxPlayerHealth;
        GameMan = GameObject.Find("GameManager").GetComponent<GameManager>();
        healthBar.maxValue = maxPlayerHealth;
        healthBar.value = maxPlayerHealth;
    }

    public void PlayerGetDamage(float damage)
    {
        playerHealth -= damage;
        healthBar.value = playerHealth;
        if(playerHealth <= 0)
        {
            GameMan.LoseGame();
        }
    }

    public void GetMoney(int value)
    {
        money += value;
        moneyText.text = money.ToString();
    }

    public void ShootSound()
    {
        audioS.PlayOneShot(enemyShootSound);
    }
    public void AttackSound()
    {
        audioS.PlayOneShot(enemyAttackSound);
    }
    public void EnemyDie()
    {
        audioS.PlayOneShot(enemyDieSound);
    }
    public void EnemyGetsHit()
    {
        audioS.PlayOneShot(enemyGetsHit);
    }
}
