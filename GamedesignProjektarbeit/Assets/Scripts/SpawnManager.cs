using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject bacteriaPrefab;
    public GameObject virusPrefab;
    public Transform spawnPoint;

    public int bacteriaCount;
    public int virusCount;
    public int enemyCount;


    public WaveProperties[] waves;
    public WaveProperties currentWaveData;

    public float spawnDelay = 5f;

    public static SpawnManager instance;

    public TextMeshProUGUI roundCount;
    public TextMeshProUGUI timer;
    public float startTime = 30f;
    public float currentTime;
    public float timerDelay;

    private int spawnedEnemies;
    private int currentWave = 1;
    private int maxWave = 2;
    private bool hasRoundEnded = false;



    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            StartNewWave();

            instance = this;
        }
        else
        {
            Destroy(this);
        }

        
    }

    void Update()
    {
        CheckWaveEnd();

        roundCount.text = "Runde " + currentWave + "/" + waves.Length;
    }

    /// <summary>
    /// Creates Bacteria at Spawn Point
    /// </summary>
    private void SpawnBacteria ()
    {
            Instantiate(bacteriaPrefab, spawnPoint.position, bacteriaPrefab.transform.rotation);
    }

    /// <summary>
    /// Creates Virus at Spawn Point
    /// </summary>
    private void SpawnVirus ()
    {
        Instantiate(virusPrefab, spawnPoint.position, virusPrefab.transform.rotation);
    }


    /// <summary>
    /// Enemies are spawned ... Stops spawning enemies once the bacteri and virusCount reaches 0
    /// </summary>
    void SpawnEnemy ()
    {
        int randomNumber = Random.Range(0, 2);
        if (bacteriaCount > 0 && randomNumber == 1 || virusCount == 0)
        {
            SpawnBacteria();
            bacteriaCount = bacteriaCount - 1;
        }
        else if (virusCount > 0 && randomNumber == 0 || bacteriaCount == 0)
        {
            SpawnVirus();
            virusCount = virusCount - 1;
        }

        if (bacteriaCount == 0 && virusCount == 0)
        {
            CancelInvoke("SpawnEnemy");
        }
    }

    /// <summary>
    /// If the round has ended, a new round will start after 30 seconds
    /// </summary>
    void EndRound ()
    {
        if (hasRoundEnded == false)
        {
            hasRoundEnded = true;

            Invoke("StartNewWave", 30f);
            currentTime = startTime;
            InvokeRepeating("StartTimer", 0, 1);
            currentWave = currentWave + 1;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void CheckWaveEnd()
    {
        if (enemyCount == 0)
        {
            EndRound();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void StartNewWave()
    {
        currentWaveData = waves[currentWave - 1];

        enemyCount = currentWaveData.bacteriaCount + currentWaveData.virusCount;
        spawnDelay = currentWaveData.spawnDelay;
        bacteriaCount = currentWaveData.bacteriaCount;
        virusCount = currentWaveData.virusCount;

        InvokeRepeating("SpawnEnemy", 0f, spawnDelay);
        hasRoundEnded = false;
        
    }

    public void StartTimer()
    {
        currentTime = currentTime - 1;
        timer.text = "Round starts in: " + currentTime;
        if(currentTime <= 0)
        {
            CancelInvoke("StartTimer");
        }
    }
}
