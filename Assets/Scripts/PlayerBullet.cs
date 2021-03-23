using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public Vector2 direction;
    [SerializeField]
    float speed;
    public float damage;

    float timeToDie = 5;
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);

        if(timeToDie <0)
        {
            Destroy(gameObject);
        }
        else
        {
            timeToDie -= Time.deltaTime;
        }
    }
}
