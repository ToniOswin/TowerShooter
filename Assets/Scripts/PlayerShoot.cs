using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    [SerializeField]
    float timeToFireBall;
    float actualTimeToFireBall;
    bool FireBallReady = false;
    [SerializeField]
    TextMeshProUGUI Fire;

    void Start()
    {
        PlayerStatsScript = gameObject.GetComponent<PlayerStats>();
        actualTimeToFireBall = timeToFireBall;
    }

 
    void Update()
    {
        ShootBullets();

        ChargeFireBall();

        ShootFireball();

        Fire.text = actualTimeToFireBall.ToString("F0");
    }

    void ShootBullets(Quaternion rotation)
    {
        float damage = PlayerStatsScript.bulletDamage;
        bulletPrefab.GetComponent<PlayerBullet>().damage = damage;
        Instantiate(bulletPrefab, canon.transform.position, rotation);
    }

    void ShootBullets()
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
    }

    void ShootFireball()
    {
        if(FireBallReady == true)
        {
            if (Input.GetMouseButton(1))
            {
                target.SetActive(true);
            }
            if (Input.GetMouseButtonUp(1))
            {
                Instantiate(FireballPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), FireballPrefab.transform.rotation);
                FireBallReady = false;
                actualTimeToFireBall = timeToFireBall;
                target.SetActive(false);
            }
        }
    }

    void ChargeFireBall()
    {
        if (actualTimeToFireBall <= 0)
        {
            FireBallReady = true;
        }
        else
        {
            actualTimeToFireBall -= Time.deltaTime;
        }
    }
}