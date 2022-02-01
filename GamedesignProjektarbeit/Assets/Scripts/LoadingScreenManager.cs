using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenManager : MonoBehaviour
{

    public GameObject loadingScreen;
    public Image slider;

    private AsyncOperation async;

    public void LoadScreen (int sceneIndex)
    {
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
