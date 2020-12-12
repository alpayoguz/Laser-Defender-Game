using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<EnemyConfig> enemyConfigs;

    int currentIndex;
    //EnemyConfig currentWave = enemyConfigs[currentIndex];

    int startingWave;
    







    void Start()
    {

        StartCoroutine(SpawnAllEnemies());

        /*
         * 
         * Bu şekilde de döngüye sokabiliriz. Ama direk startcoroutine yazmak daha mantıklı bence.

        do
        {
            StartCoroutine(SpawnAllEnemies());
        } while (true);

        */
    


    }

    private IEnumerator SpawnAllEnemies()
    {
        for(int waveIndex = startingWave; waveIndex < enemyConfigs.Count; waveIndex++)
        {
            var currentWave = enemyConfigs[waveIndex];
            yield return StartCoroutine(SpawnEnemy(currentWave));
            //yield return new WaitForSeconds(0.3f);

        }

        StartCoroutine(SpawnAllEnemies());
    }

    private IEnumerator SpawnEnemy(EnemyConfig enemyConfig)
    {
        for(int i = 0; enemyConfig.EnemyNumber() > i; i++)
        {

            var enemyBrand =  Instantiate(enemyConfig.GetEnemyPrefab(), enemyConfig.GetEnemyPath()[startingWave].transform.position, Quaternion.identity);
            enemyBrand.GetComponent<FollowThePath>().SetWaveConfig(enemyConfig);
            yield return new WaitForSeconds(enemyConfig.TimeBetweenEnemySpawn());
 
        }


       
    }

    private void Update()
    {

       
        
       
    }

    












}
