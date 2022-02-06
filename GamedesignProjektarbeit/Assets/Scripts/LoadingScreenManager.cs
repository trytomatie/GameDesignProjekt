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
        string text = "Loading ";
        for(int i = 0; i < dotAmount;i++)
        {
            text += ".";
        }
        loadingScreenText.text = text;
    }

    public void LoadScreen (int sceneIndex)
    {
        slider.fillAmount = 0f;
        slider.sprite = loadingSprites[Random.Range(0, loadingSprites.Length)];
        StartCoroutine(LoadingScreen(sceneIndex));
    }

    private IEnumerator LoadingScreen(int sceneIndex)
    {
        loadingScreen.SetActive(true);
        async = SceneManager.LoadSceneAsync(sceneIndex);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            //slider.fillAmount = async.progress;

            print(slider);
            if (async.progress == 0.9f)
            {
                float time = 0;
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
