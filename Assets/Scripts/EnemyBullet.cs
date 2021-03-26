using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    float speed;
    public float damage;
    Transform player;
    PlayerStats playerScript;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerScript = player.GetComponent<PlayerStats>();
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
        if(Mathf.Abs(player.position.x - transform.position.x) < 0.5)
        {
            playerScript.AttackSound();
            playerScript.PlayerGetDamage(damage);
            Destroy(gameObject);
        }
    }
    
   
}
