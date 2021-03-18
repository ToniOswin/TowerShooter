using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public Vector2 direction;
    [SerializeField]
    float speed;
    public float Damage;

    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }
}
