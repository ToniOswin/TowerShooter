using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    [Header("BaseStats")]
    public float baseMaxHealth;
    public float baseDamage;

    [Header("Stats")]
    public float maxHealth;
    public float health;
    public float damage;
    public int value;

    [SerializeField]
    Slider lifeSlider;
    PlayerStats playerScript;
    
    void Start()
    {
        health = maxHealth;
        lifeSlider.maxValue = maxHealth;
        lifeSlider.value = maxHealth;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            if (health > 0)
            {
                LostHealth(collision.GetComponent<PlayerBullet>().damage);
            }
        }

        if(collision.gameObject.CompareTag("Fireball"))
        {
            if (health > 1)
            {
               LostHealth(collision.GetComponent<FireBall>().damage);
            }
        }
    }

    public void LostHealth(float Damage)
    {
        playerScript.EnemyGetsHit();
        health -= Damage;
        lifeSlider.value = health;
        if(health <= 0)
        {
            EnemyDie();
        }
    }

    public void EnemyDie()
    {
        playerScript.GetMoney(value);
        Destroy(gameObject);
        playerScript.EnemyDie();
    }

}
