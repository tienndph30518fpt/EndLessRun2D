using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    public Text textBulletCount;
    private int bulletCount = 5;
    public Transform bulletSpawnPoint;
    public GameObject bullet;
    public float bulletSpeed = 10;
    
    public GameObject hat;
    public GameObject circle;
    
    private int blood = 100;
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    [SerializeField]private float speedRun = 3f;
    private Rigidbody2D rb;
    [SerializeField] private float speedJump;
    private Animator animator;
    [SerializeField] private bool canJump;
    [SerializeField] private int spaceCount;
    public GameObject GameOverPanel;
    public bool isGameOver;
    private int style;

    private void Awake()
    {
        style = PlayerPrefs.GetInt("style", -1);
        
            if (style == 0)
            {
                
            }else if (style == 1)
            {
                hat.SetActive(true);
            }else if (style == 2)
            {
                circle.SetActive(true);
            }
         
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        fill.color = gradient.Evaluate(1f);
        slider.value = blood;
        textBulletCount.text = "Bullet: " + bulletCount;
    }

   
    void Update()
    {
        if(!isGameOver)
        {
            transform.position += Time.deltaTime * speedRun * Vector3.right;
        }
        
        if(spaceCount > 2)
        {
            canJump = false;
        }
        if(Input.GetKeyDown("space") && canJump && !isGameOver)
        {
            rb.velocity = Vector3.up * speedJump;
            spaceCount += 1;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (bulletCount <= 0)
            {
                return;
            }
            bulletCount -= 1;
            textBulletCount.text = "Bullet: " + bulletCount;
            var bulletSpawn = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bulletSpawn.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;
        }
        
        
    }
   
    public void GameOver()
    {
        blood -= 20;
        slider.value = blood;
        speedRun += 0.2f;
        bulletSpeed += 0.3f;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        if (blood <= 0)
        {
            isGameOver = true;
            GameOverPanel.SetActive(true);
            animator.SetTrigger("die");
        }
        
        
    } 
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Land"))
        {
            spaceCount = 0;
            canJump = true;
        }
        if (other.gameObject.CompareTag("obstacles"))
        {
            GameOver();
        }
        if(other.gameObject.CompareTag("DesTroyBottom"))
        {
            isGameOver = true;
            blood = 0;
            slider.value = blood;
            fill.color = gradient.Evaluate(slider.normalizedValue);
            GameOverPanel.SetActive(true);
            animator.SetTrigger("die");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Blood")
        {
            if (blood >= 100)
            {
                return;
            }
            blood += 20;
            speedRun += 0.2f;
            bulletSpeed += 0.3f;
            Destroy(other.gameObject);
            slider.value = blood;
            fill.color = gradient.Evaluate(slider.normalizedValue);
        }
        if (other.gameObject.tag == "bullet")
        {
            bulletCount += 1;
            textBulletCount.text = "Bullet: " + bulletCount;
            Destroy(other.gameObject);
        }
    }

    public void Jumpbtn()
    {
        if (canJump && !isGameOver)
        {
            rb.velocity = Vector3.up * speedJump;
            spaceCount += 1;
        }
    }
    
    public void Shoot()
    {
        if (bulletCount <= 0)
        {
            return;
        }
        bulletCount -= 1;
        textBulletCount.text = "Bullet: " + bulletCount;
        var bulletSpawn = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bulletSpawn.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;
    }
    
}