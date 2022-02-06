using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private int dna = 100;
    public static GameManager instance;
    public TextMeshProUGUI dnaText;
    public GameObject pauseScreen;
    public Image hpBar;



    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            SetDNAText(dna);
            instance = this;
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
        SceneManager.LoadScene(0);

    }

    public void TryAgain()

    {

        SceneManager.LoadScene(1);
    }


    public void QuitGame()
    {
        Application.Quit(0);

    }


    public void ExitButton()

    {
        SceneManager.LoadScene(3);
    }

    public void PauseMenu()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            pauseScreen.SetActive(true);

        }
    }



}
