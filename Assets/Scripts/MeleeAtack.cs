using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAtack : MonoBehaviour
{
    Transform player;
    PlayerStats playerScript;
    EnemyStats statsScript;

    float damage;
    float attackDelay;
    [SerializeField]
    float maxAttackDelay;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        statsScript = GetComponent<EnemyStats>();
        damage = statsScript.damage; 
        playerScript = player.GetComponent<PlayerStats>();
    }
    void Update()
    {
        if(Mathf.Abs(player.position.x - transform.position.x) < 1)
        {
            attack();
        }
    }

    void attack()
    {
        if(attackDelay <=0)
        {
            playerScript.AttackSound();
            playerScript.PlayerGetDamage(damage);
            attackDelay = maxAttackDelay;
        }
        else
        {
            attackDelay -= Time.deltaTime;
        }
    }
}
