using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Create A New Enemy") ]
public class EnemyConfig : ScriptableObject
{
    
    
    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField] 
    GameObject enemyPathPrefab;

    [SerializeField] 
    int moveSpeed;

    [SerializeField] 
    int enemyNumber;

    [SerializeField] 
    float randomFactor;

    [SerializeField]
    float timeBetweenEnemySpawn;



    public GameObject GetEnemyPrefab() { return enemyPrefab; }
    public List<Transform> GetEnemyPath()
    {
        var esp = new List<Transform>();
        foreach(Transform child in enemyPathPrefab.transform)
        {
            esp.Add(child); 
        }

        return esp;
    }

    public int MoveSpeed() { return moveSpeed; }
    public int EnemyNumber() { return enemyNumber; }
    public float TimeBetweenEnemySpawn() { return timeBetweenEnemySpawn; }
    public float RandomFactor() { return randomFactor; }


    





}
