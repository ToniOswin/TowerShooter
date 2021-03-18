using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
    float maxHealth;
    public float health;

    void Start()
    {
        health = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            if(health > 0)
            {
                LostHealth(collision.GetComponent<PlayerBullet>().Damage);
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
    }

    public void EnemyDie()
    {
        Destroy(gameObject);
    }

}
