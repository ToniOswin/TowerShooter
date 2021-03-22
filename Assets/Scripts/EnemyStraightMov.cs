using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyStraightMov : MonoBehaviour
{
    [SerializeField]
    float speed;
    Transform target;
    [SerializeField]
    float attackDistance;

    [SerializeField]
    bool canBePushed;
    public bool isOnPlace;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        isOnPlace = false;
    }


    void Update()
    {
        if(Mathf.Abs(target.position.x - transform.position.x) > attackDistance)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        else { isOnPlace = true; }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet") && canBePushed == true)
        {
            Pushed();
        }
    }

    void Pushed()
    {
        transform.DOMoveX(transform.position.x + 1, 0.5f).SetEase(Ease.OutBack);

    }
}
