using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static float score = 0f;
    public Text textScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>().isGameOver)
        {
            score += Time.deltaTime;
            textScore.text = "SCORE: " + score.ToString("F2");
            
        }
    }
}
