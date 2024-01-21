using System.Collections;
using UnityEngine;

public class SpawnEasyWaveScript : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING }; //3 SPAWNING states used for knowing if waves are spawning,waiting to finish or counting down to the next wave
    private SpawnEasyWaveScript thisScript;

    // ----- Class for storing wave variables -----

    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public int enemyCount;
        public float minSpawnrate;
        public float maxSpawnrate;
    }

    private Vector3[] spawnPoints;

    public Wave[] wave;
    private int nextWave;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private SpawnState state;


    private float randomFunction;

    // ----- Function taking spawnpoints -----

    public void TakeSpawnPoints(Vector3[] spawnpoints)
    {
        spawnPoints = spawnpoints;
    }

    private void OnEnable()
    {
        thisScript = this;
        waveCountdown = timeBetweenWaves;
        state = SpawnState.COUNTING;
    }

    private void Update()
    {
        randomFunction = Random.Range(1, 100);

        //Checks for when all enemies are killed to spawn the next wave
        if (state == SpawnState.WAITING)
        {
            if (RedEnemyAlive() == true || GreenEnemyAlive() == true || BlueEnemyAlive() == true)
            {
                return; //Enemies are still alive so back out
            }
            else
            {
                WaveCompleted(); //Enemies are dead so finish the wave
            }
        }
        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(wave[nextWave])); //Calls the IEnumerator function that spawns waves and gives the wave that you want to spawn(wave) with the index of [nextWave]
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
            WaveCountDownScript.countdownScript.CountdownText(waveCountdown);
        }
    }

    // ----- Checks if any enemy is alive -----

    private bool RedEnemyAlive()
    {
        for (int i = 0; i < RedEnemyPoolerScript.PoolerRE.pooledObjectsRE.Count; i++)
        {
            if (RedEnemyPoolerScript.PoolerRE.pooledObjectsRE[i].activeInHierarchy)
            {
                return true;
            }
        }

        return false;

    }
    private bool GreenEnemyAlive()
    {
        for(int i = 0; i < GreenEnemyPoolerScript.PoolerGE.pooledObjectsGE.Count; i++)
                {
            if (GreenEnemyPoolerScript.PoolerGE.pooledObjectsGE[i].activeInHierarchy)
            {
                return true;
            }
        }

        return false;

    }
    private bool BlueEnemyAlive()
    {
        for (int i = 0; i < BlueEnemyPoolerScript.PoolerBE.pooledObjectsBE.Count; i++)
        {
            if (BlueEnemyPoolerScript.PoolerBE.pooledObjectsBE[i].activeInHierarchy)
            {
                return true;
            }
        }

        return false;

    }

        // ----- Function for spawning a wave -----

        IEnumerator SpawnWave(Wave _wave)
        {

            state = SpawnState.SPAWNING;

            float spawnRate = Random.Range(_wave.minSpawnrate, _wave.maxSpawnrate);

            for (int i = 0; i < _wave.enemyCount; i++)
            {
                //Calls the functions that spawn one of the enemies
                if (randomFunction <= 40)
                {
                    SpawnGreenEnemy();
                }
                else if (randomFunction > 40 && randomFunction <= 75)
                {
                    SpawnBlueEnemy();
                }
                else
                {
                    SpawnRedEnemy();
                }

                yield return new WaitForSeconds(spawnRate);   //Old 1f / spawnRate
            }

            state = SpawnState.WAITING;

            yield break;
        }

        // ----- Function for spawning an enemy -----

        private void SpawnRedEnemy()
        {
            GameObject obj = RedEnemyPoolerScript.PoolerRE.GetPooledObjectRE();
            if (obj == null) return; // Backs out of the function if the returned value is null to not cause an error

            obj.transform.position = spawnPoints[Random.Range(0, 8)];
            obj.SetActive(true);
        }
        private void SpawnGreenEnemy()
        {
            GameObject obj = GreenEnemyPoolerScript.PoolerGE.GetPooledObjectGE();
            if (obj == null) return; // Backs out of the function if the returned value is null to not cause an error

            obj.transform.position = spawnPoints[Random.Range(0, 8)];
            obj.SetActive(true);
        }
        private void SpawnBlueEnemy()
        {
            GameObject obj = BlueEnemyPoolerScript.PoolerBE.GetPooledObjectBE();
            if (obj == null) return; // Backs out of the function if the returned value is null to not cause an error

            obj.transform.position = spawnPoints[Random.Range(0, 8)];
            obj.SetActive(true);
        }

        // ----- Function when a wave gets completed to get to the next wave -----

        private void WaveCompleted()
        {
            waveCountdown = timeBetweenWaves;

            if (nextWave + 1 > wave.Length - 1)
            {
                nextWave = 0;
                WaveCountDownScript.countdownScript.Victory();
                thisScript.enabled = false;
            }
            else
            {
                nextWave += 1;
                state = SpawnState.COUNTING;
            }

            state = SpawnState.COUNTING;

         }

        private void OnDisable()
        {
            StopAllCoroutines();
        }
}
