using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private int dna = 40;
    public static GameManager instance;
    public TextMeshProUGUI dnaText;
    public GameObject pauseScreen;
    public Image hpBar;

    public UnityEvent unitAudio;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

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

    public static Vector2 NormalizedDirection(Vector2 origin, Vector2 target)
    {
        Vector2 dir = (target - origin).normalized;
        return dir;
        // test
    }

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


    public void BackToTitle()

    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }

    public void TryAgain()

    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }


    public void QuitGame()
    {
        Application.Quit(0);

    }


    public void ExitButton()

    {
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
    }

    public void PauseMenu()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;


        }
    }

    public void SetTimeScale(float n)
    {
        Time.timeScale = n;
    }

}
