using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceAttack : MonoBehaviour
{
    float damage;
    [SerializeField]
    float maxShootDelay;
    float shootDelay;
    [SerializeField]
    GameObject enemyBullet;
    bool isOnPlace;

    EnemyStraightMov enemyMoveScript;
    EnemyStats statsScript;
    PlayerStats playerScript;
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        statsScript = GetComponent<EnemyStats>();
        damage = statsScript.damage;

        enemyMoveScript = GetComponent<EnemyStraightMov>();
        isOnPlace = enemyMoveScript.isOnPlace;
        shootDelay = maxShootDelay;
    }

    void Update()
    {
        isOnPlace = enemyMoveScript.isOnPlace;

        if(isOnPlace)
        {
            EnemyShoot();
        }
    }
    void EnemyShoot()
    {
        if(shootDelay <= 0)
        {
            playerScript.ShootSound();
            enemyBullet.GetComponent<EnemyBullet>().damage = damage;
            Instantiate(enemyBullet, transform.position, enemyBullet.transform.rotation);
            shootDelay = maxShootDelay;
        }
        else
        {
            shootDelay -= Time.deltaTime;
        }
    }
    
}
