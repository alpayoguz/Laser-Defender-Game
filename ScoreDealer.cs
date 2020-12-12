using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDealer : MonoBehaviour
{

    TextMeshProUGUI scoreText;
    

    
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = GameObject.Find("GameHandler").GetComponent<GameHandler>().GetScore().ToString();
    }
}
