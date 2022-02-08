using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadLevelSelection", 30f);                  //automatically forwards player to level selection after cutscene is done (Shaina)
    }
    
    public void LoadLevelSelection ()
    {
        SceneManager.LoadScene(2);
    }
}
