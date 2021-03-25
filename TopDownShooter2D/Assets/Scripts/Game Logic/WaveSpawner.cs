using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Transform[] spawnPoints;
    private int nextWave = 0;
    public int doubleEnemies = 2;

    public GameObject skillTreeUI;

    public float waveDelay = 5f;
    public float countDown;

    private float searchCountDown = 1f;
    // Default spawn state is the countdown till the next wave
    public SpawnState state = SpawnState.counting;

    private void Start()
    {
        // sets the default countdown to the time in between waves
        countDown = waveDelay;
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("NO SPAWN POINTS");
        }
    }
    private void Update()
    {
        // checks to see if the player is waiting for the next round
        if (state == SpawnState.waiting)
        {
            // checks to see if there are any enemies alive in the scene
            if (!EnemiesAlive())
            {

                StartNewRound();// calls start a new round
                
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
                //starts spawning enemies in the wave
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            //will countdown from the delay timer by 1 each second
            countDown -= Time.deltaTime;
        }
    }
    void StartNewRound()
    {
        IncreaseLevel();
        OpenSkillMenu();
        state = SpawnState.counting;// sets the state to counting before the next round starts

        // resets the timer
        countDown = waveDelay;
        
        //makes the game loop
        if(nextWave+ 1 > waves.Length - 1)
        {
            nextWave = 0;
            
            Debug.Log("All waves complete... Looping");
        }
        else
        {
            
            nextWave++;// increments the wave index
        }
        
    }

    bool EnemiesAlive()
    {
        
        searchCountDown -= Time.deltaTime;// checks to see if any enemies are alive every second
        if (searchCountDown <= 0)
        {
            searchCountDown = 1f;// makes the timer loop

            if (GameObject.FindGameObjectWithTag("Enemy") == null)// checks to see enemy tags
            {
               
                return false;// returns false as there are no enemies alive
            }
            else
            {
                //Debug.Log("EnemyFound");
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

        state = SpawnState.waiting;// makes the state waiting until the player has killed all the enemies

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        //Debug.Log("Spawning Enemy: " + _enemy.name);

        
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        //sp.position = sp.position + new Vector3(0.0f, 0.0f, 0.0f);
        Instantiate(_enemy, sp.position, sp.rotation);// spawns the enemy at a random spawn point
       
        
    }
    void OpenSkillMenu()
    {
        skillTreeUI.GetComponent<SkillTreeUI>().SkillTreeActive();

    }
    void IncreaseLevel()
    {
        skillTreeUI.GetComponent<SkillTreeUI>().levelPoints +=1;

    }

}
