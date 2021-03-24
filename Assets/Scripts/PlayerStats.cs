using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        playerHealth = maxPlayerHealth;
    }

    public void PlayerGetDamage(float damage)
    {
        playerHealth -= damage;
    }
}
