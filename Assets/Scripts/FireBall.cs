using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
     public float damage;
    void Start()
    {
        Destroy(gameObject, 1f);
    }
}
