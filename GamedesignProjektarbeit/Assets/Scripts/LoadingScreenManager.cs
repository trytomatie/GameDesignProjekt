using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenManager : MonoBehaviour
{
    public int dotAmount;
    public GameObject loadingScreen;
    public Image slider;
    public Sprite[] loadingSprites;
    public TextMeshProUGUI loadingScreenText;


    private AsyncOperation async;


    private void Start()
    {
        LoadScreen(LoadLevel.loadScene);
    }

    private void Update()
    {
        LoadinScreenDots();
    }

    /// <summary>
    /// Shows Dots depending on dotAmount(Animated Value)
    /// by Christian Scherzer
    /// </summary>
    private void LoadinScreenDots()
    {
        string text = "Loading ";
        for (int i = 0; i < dotAmount; i++)
        {
            text += ".";
        }
        loadingScreenText.text = text;
    }

    /// <summary>
    /// Loads screen
    /// by Shaina Milde
    /// </summary>
    /// <param name="sceneIndex"></param>
    public void LoadScreen (int sceneIndex)
    {
        slider.fillAmount = 0f;
        slider.sprite = loadingSprites[Random.Range(0, loadingSprites.Length)];
        StartCoroutine(LoadingScreen(sceneIndex));
    }

    /// <summary>
    /// Corutine for loading screen
    /// by Shaina Milde
    /// </summary>
    /// <param name="sceneIndex"></param>
    /// <returns></returns>
    private IEnumerator LoadingScreen(int sceneIndex)
    {
        loadingScreen.SetActive(true);
        async = SceneManager.LoadSceneAsync(sceneIndex);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            //slider.fillAmount = async.progress; // Fills amount dependinding on progress (Commented out to show loading screen)

            print(slider);
            if (async.progress == 0.9f)
            {
                float time = 0;
                // Makes sure to show loading screen for 5 seconds (Just to show it off)
                while(time <= 5)
                {
                    slider.fillAmount = time / 5f;
                    time += Time.deltaTime;
                    yield return new WaitForEndOfFrame();
                }
                slider.fillAmount = 1f;
                async.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
