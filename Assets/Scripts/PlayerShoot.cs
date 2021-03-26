using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject canon;
    [SerializeField]
    AudioSource audioS;

    [Header("Bullets")]
    [SerializeField]
    GameObject bulletPrefab;
    PlayerStats PlayerStatsScript;
    [SerializeField]
    float maxDelay;
    float delay;
    [SerializeField]
    AudioClip shootSound;

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
    Image fill;
    [SerializeField]
    AudioClip fireSound;

    void Start()
    {
        PlayerStatsScript = gameObject.GetComponent<PlayerStats>();
        actualTimeToFireBall = 0;
    }

 
    void Update()
    {
        ShootBullets();

        ChargeFireBall();

        ShootFireball();

    }

    void CreateBullets(Quaternion rotation)
    {
        float damage = PlayerStatsScript.bulletDamage;
        bulletPrefab.GetComponent<PlayerBullet>().damage = damage;
        Instantiate(bulletPrefab, canon.transform.position, rotation);
        audioS.PlayOneShot(shootSound);
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
        if(delay > 0)
        {
            delay -= Time.deltaTime;
        }
       
        if (Input.GetMouseButton(0))
        {
            if (delay <= 0)
            {
                CreateBullets(Quaternion.Euler(0, 0, angle));
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
                audioS.PlayOneShot(fireSound);
                FireballPrefab.GetComponent<FireBall>().damage = PlayerStatsScript.fireBallDamage;
                Instantiate(FireballPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), FireballPrefab.transform.rotation);
                FireBallReady = false;
                actualTimeToFireBall =0;
                target.SetActive(false);
            }
        }
    }

    void ChargeFireBall()
    {
        if (actualTimeToFireBall >= timeToFireBall)
        {
            FireBallReady = true;
            fill.fillAmount = 1;
        }
        else
        {
            actualTimeToFireBall += Time.deltaTime;
            fill.fillAmount = actualTimeToFireBall / timeToFireBall;
        }
    }
}