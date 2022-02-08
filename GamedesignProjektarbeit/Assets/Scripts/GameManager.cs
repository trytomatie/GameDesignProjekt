using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private int dna = 30;
    public static GameManager instance;
    public TextMeshProUGUI dnaText;
    public GameObject pauseScreen;
    public Image hpBar;

    public UnityEvent unitAudio;
    public TextMeshProUGUI pause;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; // Sets Timescale to 1 to asure it is 1 at start of round

        // Singleton
        if(instance == null)
        {
            SetDNAText(dna);
            instance = this;

            UnitButton.unitAudio = unitAudio;
        }
        else
        {
            Destroy(this);
        }

    }

    // Update is called once per frame
    void Update()
    {
       
        UnitButton.PositionTargetedUnit();
        UnitButton.CheckForPlaceUnit();
        PauseMenu();
    }

    /// <summary>
    /// Creates a Normalized Direction
    /// by Christian Scherzer
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static Vector2 NormalizedDirection(Vector2 origin, Vector2 target)
    {
        Vector2 dir = (target - origin).normalized;
        return dir;
        // test
    }

    /// <summary>
    /// Set DNA Text 
    /// by Christian Scherzer
    /// </summary>
    /// <param name="amount"></param>
    private void SetDNAText(int amount)
    {
        dnaText.text = amount.ToString();
    }
    public int Dna 
    { 
        get => dna;
        set 
        {
            SetDNAText(value);
            dna = value;
        }
    }

    /// <summary>
    /// Goes back to titlescrren
    /// by Dilara Durmus
    /// </summary>
    public void BackToTitle()

    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }
    /// <summary>
    /// Loads this scene again
    /// by Dilara Durmus
    /// </summary>
    public void TryAgain(int scene)

    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }

    /// <summary>
    /// Quit game
    /// by Dilara Durmus
    /// </summary>
    public void QuitGame()
    {
        Application.Quit(0);

    }

    /// <summary>
    /// Exits to Levelselect
    /// by Dilara Durmus
    /// </summary>
    public void ExitButton()

    {
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
    }
    /// <summary>
    /// Opens Pause Menu
    /// by Dilara Durmus
    /// </summary>
    public void PauseMenu()
    {

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;


        }
    }
    /// <summary>
    /// Sets Timescale
    /// by Shaina Milde
    /// </summary>
    public void SetTimeScale(float n)
    {
        Time.timeScale = n;
    }

    public void SetTimeScale(Toggle toggle)
    {
        if (toggle.isOn == true)
        {
            pause.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pause.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        
    }

}
