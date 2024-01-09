using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLand : MonoBehaviour
{
    [SerializeField] private bool landcheck;
    public GameObject Land1, Land2, Land3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (landcheck == true)
        {
            LandSpawn();
            landcheck = false;
        }
    }
    public void LandSpawn()
    {
        int ran = Random.Range(1, 4);
        GameObject test;
        if(ran == 1)
        {
            test = Instantiate(Land1, new Vector3(transform.position.x + 2f, -3.77f, 0), Quaternion.identity);
        }
        else if(ran == 2)
        {
            
            test = Instantiate(Land2, new Vector3(transform.position.x + 2f, -1.9f, 0), Quaternion.identity);
        }
        else if(ran == 3)
        {
            test = Instantiate(Land3, new Vector3(transform.position.x + 2f, -2.3f, 0), Quaternion.identity);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Land"))
        {
            landcheck = false;
        }
    }
  
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Land"))
        {
            landcheck = true;
        }
    }
}
