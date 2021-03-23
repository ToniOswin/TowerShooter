using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    [Header("Life")]
    [SerializeField]
    float maxHealth;
    public float health;
    [SerializeField]
    Slider lifeSlider;

    void Start()
    {
        health = maxHealth;
        lifeSlider.maxValue = maxHealth;
        lifeSlider.value = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            if (health > 1)
            {
                LostHealth(collision.GetComponent<PlayerBullet>().damage);
            }
            else
            {
                EnemyDie();
            }
        }

        if(collision.gameObject.CompareTag("Fireball"))
        {
            if (health > 1)
            {
               LostHealth(collision.GetComponent<FireBall>().damage);
                if(health < 1) { EnemyDie(); }
            }
            else
            {
                EnemyDie();
            }
        }
    }

    public void LostHealth(float Damage)
    {
        health -= Damage;
        lifeSlider.value = health;
    }

    public void EnemyDie()
    {
        Destroy(gameObject);
    }

}
