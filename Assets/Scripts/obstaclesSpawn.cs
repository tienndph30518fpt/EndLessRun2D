using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclesSpawn : MonoBehaviour
{
    [SerializeField] private GameObject obstacle1, obstacle2, heart, bullet;
    [SerializeField] private float Time;
    public Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("spawnObstacles");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>().isGameOver)
        {
            StopCoroutine("spawnObstacles");
        }
    }
    private void spawnObstacle()
    {
        GameObject test;
        test = Instantiate(obstacle1, new Vector3(transform.position.x + 3f, transform.position.y, 0), Quaternion.identity);
        int ran = Random.Range(1, 4);
        if(ran == 1)
        {
            test = Instantiate(heart, new Vector3(transform.position.x + 1f, transform.position.y + 2.5f, 0), Quaternion.identity);
            test = Instantiate(obstacle2, new Vector3(transform.position.x + 1f, transform.position.y + 2f, 0), Quaternion.identity);
            test = Instantiate(bullet, new Vector3(transform.position.x + 2f, transform.position.y + 1f, 0), Quaternion.identity);
        }
        else if(ran == 2)
        {
            test = Instantiate(obstacle2, new Vector3(transform.position.x + 1f, transform.position.y + 2.5f, 0), Quaternion.identity);
            test = Instantiate(bullet, new Vector3(transform.position.x + 1.5f, transform.position.y + 0.5f, 0), Quaternion.identity);
            test = Instantiate(heart, new Vector3(transform.position.x + 1f, transform.position.y + 2f, 0), Quaternion.identity);
        }
        else if(ran == 3)
        {
            test = Instantiate(bullet, new Vector3(transform.position.x + 1f, transform.position.y + 2.5f, 0), Quaternion.identity);
            test = Instantiate(obstacle2, new Vector3(transform.position.x + 1f, transform.position.y + 1.5f, 0), Quaternion.identity);
        }
    }
    IEnumerator spawnObstacles()
    {
        while(true)
        {
            spawnObstacle();
            yield return new WaitForSeconds(Time);
        }
    }
}
