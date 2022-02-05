using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Speichere die Zu ladene Szene und lade den Loadingscreen
    /// </summary>
    /// <param name="index"></param>
    public void LoadScene(int sceneIndex) //
    {
        //
        PlayerPrefs.SetInt("loadSzene",sceneIndex);
        SceneManager.LoadScene("Loading Screen");
    }

}
