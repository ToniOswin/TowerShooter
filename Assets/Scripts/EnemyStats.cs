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
        Debug.Log("detectao");
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            LostHealth(collision.GetComponent<PlayerBullet>().Damage);
        }
    }

    public void LostHealth(float Damage)
    {
        health -= Damage;
    }

}
