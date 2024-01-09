using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameOb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Land")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "obstacles")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Blood")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "bullet")
        {
            Destroy(other.gameObject);
        }
    }
}
