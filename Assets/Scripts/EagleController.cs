using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 pos;
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos.x -= 4f * Time.deltaTime;
        transform.position = pos;
    }
}
