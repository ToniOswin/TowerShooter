using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAtack : MonoBehaviour
{
    Transform player;
    PlayerStats playerScript;

    [SerializeField]
    float Damage;
    float attackDelay;
    [SerializeField]
    float maxAttackDelay;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerScript = player.GetComponent<PlayerStats>();
        attackDelay = maxAttackDelay;
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
            playerScript.PlayerGetDamage(Damage);
            attackDelay = maxAttackDelay;
        }
        else
        {
            attackDelay -= Time.deltaTime;
        }
    }
}
