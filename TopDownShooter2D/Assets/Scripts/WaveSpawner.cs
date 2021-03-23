using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    // creates the states for spawnstate
    public enum SpawnState { spawning, waiting, counting }

    // makes it so the wave class is able to be accessed inside the editor
    [System.Serializable]

    public class Wave
    {
        public int roundNum;
        public Transform enemy;
        public int count;
        public float spawnRate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    

    public float waveDelay = 5f;
    public float countDown;

    private float searchCountDown = 1f;
    // Default spawn state is the countdown till the next wave
    public SpawnState state = SpawnState.counting;

    private void Start()
    {
        // sets the default countdown to the time in between waves
        countDown = waveDelay;
    }
    private void Update()
    {
        if (state == SpawnState.waiting)
        {
            if (!enemiesAlive())
            {
                Debug.Log("Completed");
            }
            else
            {
                return;
            }
        }

        //checks to see if the countdown is at 0
        if (countDown <= 0) 
        {
            // if the system is not already spawning 
            if (state != SpawnState.spawning)
            {
                //starts spawning
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            //will countdown from the delay timer by 1 each second
            countDown -= Time.deltaTime;
        }
    }
    bool enemiesAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    // allows the program to wait a certain amount of seconds.
    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave:" + _wave.roundNum);
        // makes the state spawning
        state = SpawnState.spawning;

        // spawns the amount of enemies that are needed to spawn
        for(int i = 0; i < _wave.count; i++)
        {
            // for each enemy spawned it calls the spawn enemy method
            SpawnEnemy(_wave.enemy);

            // waits for the delay
            yield return new WaitForSeconds(1f / _wave.spawnRate);
        }

        state = SpawnState.waiting;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning Enemy: " + _enemy.name);
        Instantiate(_enemy, transform.position, transform.rotation);
        
    }

}
