using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public static int loadScene;
    

    /// <summary>
    /// Speichere die Zu ladene Szene und lade den Loadingscreen
    /// by Markus Schwalb
    /// </summary>
    /// <param name="index"></param>
    public void LoadScene(int sceneIndex) //
    {
        //
        loadScene = sceneIndex;
        SceneManager.LoadScene("Loading Screen");
    }


    /// <summary>
    /// lade die nächste Scene (in der Build herarchie)
    /// by Markus Schwalb
    /// </summary>
    public void LoadNextSceene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;        //hol dir den BuildIndex dieser Szene und addiere eins drauf
        loadScene += 1;
        SceneManager.LoadScene("Loading Screen");
    }

}
