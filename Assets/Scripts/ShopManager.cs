using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    int money;
    float damage;
    float health;
    float fireDamage;

    int damagePrice = 300;
    int healthPrice = 500;
    int fireDamagePrice = 700;
    
    [Header("ActualStatsText")]
    [SerializeField]
    TextMeshProUGUI actualMoney;
    [SerializeField]
    TextMeshProUGUI actualDamage;
    [SerializeField]
    TextMeshProUGUI actualHealth;
    [SerializeField]
    TextMeshProUGUI actualFireDamage;
    [Space]
    [Header("Prices")]
    [SerializeField]
    TextMeshProUGUI healthPriceT;
    [SerializeField]
    TextMeshProUGUI damagePriceT;
    [SerializeField]
    TextMeshProUGUI fireDamagePriceT;
    [Space]
    [Header("Buttons")]
    [SerializeField]
    Button healthButton;
    [SerializeField]
    Button damageButton;
    [SerializeField]
    Button fireDamageButton;

    // Start is called before the first frame update
    void Start()
    {
        healthPriceT.text = healthPrice.ToString();
        damagePriceT.text = damagePrice.ToString();
        fireDamagePriceT.text = fireDamagePrice.ToString();
        GetStats();
        
    }

    public void UpgradeHealth()
    {
        money -= healthPrice;
        health += 50;
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetFloat("PlayerHealth", health);
        GetStats();
    }

    public void UpgradeDamage()
    {
        money -= damagePrice;
        damage += 0.5f;
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetFloat("PlayerDamage", damage);
        GetStats();
    }
    public void UpgradeFireDamage()
    {
        money -= damagePrice;
        fireDamage += 5;
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetFloat("PlayerFireDamage", fireDamage);
        GetStats();
    }
    void GetStats()
    {
        actualMoney.text = PlayerPrefs.GetInt("Money", 0).ToString();
        actualDamage.text ="Actual: " + PlayerPrefs.GetFloat("PlayerDamage", 1).ToString();
        actualHealth.text = "Actual: " + PlayerPrefs.GetFloat("PlayerHealth", 100).ToString();
        actualFireDamage.text = "Actual: " + PlayerPrefs.GetFloat("PlayerFireDamage", 10).ToString();

        money = PlayerPrefs.GetInt("Money", 0);
        health = PlayerPrefs.GetFloat("PlayerHealth", 100);
        damage = PlayerPrefs.GetFloat("PlayerDamage", 1);
        fireDamage = PlayerPrefs.GetFloat("PlayerFireDamage", 10);

        CheckPrices();
    }

    void CheckPrices()
    {
        if(money < healthPrice)
        {
            healthButton.interactable = false;
        }
        else { healthButton.interactable = true; }

        if (money < damagePrice)
        {
            damageButton.interactable = false;
        }
        else { damageButton.interactable = true; }

        if (money < fireDamagePrice)
        {
            fireDamageButton.interactable = false;
        }
        else { fireDamageButton.interactable = true; }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
