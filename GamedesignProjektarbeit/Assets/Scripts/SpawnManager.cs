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
    public float startTime = 15f;
    public float currentTime;
    public float timerDelay;

    public GameObject wonDialog;

    public AudioClip winSound;
    public AudioSource winDialogAudioSource;

    public AudioClip roundSound;
    public AudioSource roundAudioSource;

    private int spawnedEnemies;
    private int currentWave = 0;
    private bool hasRoundEnded = false;



    // Start is called before the first frame update
    void Start()
    {
        winDialogAudioSource = GetComponent<AudioSource>();
        roundAudioSource = GetComponent<AudioSource>();

        if (instance == null)
        {

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

        roundCount.text = "Round " + currentWave + "/" + waves.Length;
    }

    /// <summary>
    /// Creates Bacteria at Spawn Point
    /// by Shaina Milde
    /// </summary>
    private void SpawnBacteria ()
    {
        GameObject go = Instantiate(bacteriaPrefab, spawnPoint.position, bacteriaPrefab.transform.rotation);
        go.GetComponent<StatusManager>().level = currentWave;
    }

    /// <summary>
    /// Creates Virus at Spawn Point
    /// by Shaina Milde
    /// </summary>
    private void SpawnVirus ()
    {
        GameObject go = Instantiate(virusPrefab, spawnPoint.position, virusPrefab.transform.rotation);
        go.transform.GetChild(0).GetComponent<StatusManager>().level = currentWave;
    }


    /// <summary>
    /// Enemies are spawned ... Stops spawning enemies once the bacteri and virusCount reaches 0
    /// by Shaina Milde
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
    /// If the round has ended, a new round will start after the timer reaches 0
    /// by Shaina Milde
    /// </summary>
    void EndRound ()
    {
        if (hasRoundEnded == false)
        {
            hasRoundEnded = true;
            if(currentWave == waves.Length)
            {
                wonDialog.SetActive(true);                                          // if the current round is the last one, you win the game (Dilara)
                winDialogAudioSource.PlayOneShot(winSound, 0.2f);                   // plays sound when the game is won (Shaina)
                Time.timeScale = 0;                                                 // freezes the game (Shaina)
                return;
            }

            Invoke("StartNewWave", startTime);
            currentTime = startTime;
            InvokeRepeating("StartTimer", 0, 1);
            currentWave = currentWave + 1;

            roundAudioSource.PlayOneShot(roundSound, 0.2f);
            roundAudioSource.enabled = true;
        }
    }

    /// <summary>
    /// if the enemy count has reached 0, the round is over
    /// by Shaina Milde
    /// </summary>
    void CheckWaveEnd()
    {
        if (enemyCount == 0)
        {
            EndRound();
        }
    }

    /// <summary>
    /// Starts new wave
    /// by Shaina Milde
    /// </summary>
    void StartNewWave()
    {
        roundAudioSource.PlayOneShot(roundSound, 0.2f);

        currentWaveData = waves[currentWave - 1];

        enemyCount = currentWaveData.bacteriaCount + currentWaveData.virusCount;
        spawnDelay = currentWaveData.spawnDelay;
        bacteriaCount = currentWaveData.bacteriaCount;
        virusCount = currentWaveData.virusCount;

        InvokeRepeating("SpawnEnemy", 0f, spawnDelay);
        hasRoundEnded = false;
        
    }

    /// <summary>
    /// Starts new wave
    /// by Shaina Milde
    /// </summary>
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
