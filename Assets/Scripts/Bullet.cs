using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 4;

    private void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Land")
        {
            Destroy(gameObject);
        }
        
        if (other.gameObject.tag == "obstacles")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
