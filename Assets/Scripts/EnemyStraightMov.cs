using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyStraightMov : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    Transform target;

    void Start()
    {

        //transform.DOMoveX(target.position.x, timeToGet);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Pushed();
        }
    }

    void Pushed()
    {
        transform.DOMoveX(transform.position.x + 1, 0.5f).SetEase(Ease.OutBack);

    }
}
