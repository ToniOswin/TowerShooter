using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject canon;

    [Header("Bullets")]
    [SerializeField]
    GameObject bulletPrefab;
    PlayerStats PlayerStatsScript;
    [SerializeField]
    float maxDelay;
    float delay;

    [Header("Fireball")]
    [SerializeField]
    GameObject FireballPrefab;
    [SerializeField]
    GameObject target;

    void Start()
    {
        PlayerStatsScript = gameObject.GetComponent<PlayerStats>();
        
    }

 
    void Update()
    {
        Vector2 mouse = Input.mousePosition;
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        Vector2 mouseOnWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.transform.position = mouseOnWorld; 

        if (Input.GetMouseButton(0))
        {
            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                ShootBullets(Quaternion.Euler(0, 0, angle));
                delay = maxDelay;
            }
        }

        if(Input.GetMouseButton(1))
        {
            target.SetActive(true);
        }
        if(Input.GetMouseButtonUp(1))
        {
            Instantiate(FireballPrefab, Camera.main.ScreenToWorldPoint(mouse), FireballPrefab.transform.rotation);
            target.SetActive(false);
        }
    }

    void ShootBullets(Quaternion rotation)
    {
        float damage = PlayerStatsScript.bulletDamage;
        bulletPrefab.GetComponent<PlayerBullet>().damage = damage;
        Instantiate(bulletPrefab, canon.transform.position, rotation);
    }

}