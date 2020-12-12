using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowThePath : MonoBehaviour
{

    // Array of waypoints to walk from one to the next one
    
     List<Transform> waypoints;
     EnemyConfig enemyConfig;

    // [SerializeField]List<EnemyConfig> enemyConfigs;

     int currentIndex = 0;

     private int waypointIndex = 0;



    
    private void Start()
    {

        waypoints = enemyConfig.GetEnemyPath();
        
        
    }

    
    private void Update()
    {
        Move();

    }

    public void SetWaveConfig(EnemyConfig enemyConfig)
    {
        this.enemyConfig = enemyConfig;
    }

    private void Move()
    {
        if (waypoints.Count - 1 >= waypointIndex)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, Time.deltaTime * enemyConfig.MoveSpeed());


            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex++;
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method that actually make Enemy walk
    
}