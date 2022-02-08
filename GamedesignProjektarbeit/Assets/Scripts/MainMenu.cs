using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    /// <summary>
    /// Closes Application
    /// by Dilara Durmus
    /// </summary>
    public void QuitGame()
    {
        Application.Quit(0);
    }

    /// <summary>
    /// Opens Cutscene
    /// by Dilara Durmus
    /// </summary>
    public void NewGame()

    {
        SceneManager.LoadScene(1);

    }


}
