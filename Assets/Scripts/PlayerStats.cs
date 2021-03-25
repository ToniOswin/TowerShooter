using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [Header("Life")]
    [SerializeField]
    float maxPlayerHealth;
    public float playerHealth;
    [Space]
    [Header("Damage")]
    public float bulletDamage;
    public float fireBallDamage;
    [Space]
    public int money;
    [SerializeField]
    TextMeshProUGUI moneyText;
    GameManager GameMan;

    void Start()
    {
        maxPlayerHealth = PlayerPrefs.GetFloat("PlayerHealth", 100);
        bulletDamage = PlayerPrefs.GetFloat("PlayerDamage", 1);
        fireBallDamage = PlayerPrefs.GetFloat("PlayerFireDamage", 10);
        money = PlayerPrefs.GetInt("Money", 0);
        moneyText.text = money.ToString();
        playerHealth = maxPlayerHealth;
        GameMan = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void PlayerGetDamage(float damage)
    {
        playerHealth -= damage;
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
}
