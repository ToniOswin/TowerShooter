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
    [SerializeField]
    float maxDelay;
    float delay;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                ShootBullets();
                delay = maxDelay;
            }
        }

        Vector2 mouse = Input.mousePosition;
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void ShootBullets()
    {
        bulletPrefab.GetComponent<PlayerBullet>().direction = GetDirection().normalized;
        Instantiate(bulletPrefab, canon.transform.position, bulletPrefab.transform.rotation);
    }

    Vector2 GetDirection()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(canon.transform.position);
        Vector2 directionBullet = mousePos - screenPoint;
        return directionBullet;
    }
}