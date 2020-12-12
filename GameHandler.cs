using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHandler : MonoBehaviour
{

    
    
    [SerializeField] int scorePerDeath = 15;
    int currentScore;


    

    public static GameHandler Instance => _instance;

    private static GameHandler _instance;

    private void Awake()
    {
        

        if (_instance)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }


    void Start()
    {
        

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
         currentScore += scorePerDeath;
         Debug.Log(currentScore);
         
  
    }

    public int GetScore()
    {
        return currentScore;
    }


}
