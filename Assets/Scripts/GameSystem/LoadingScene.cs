using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingScene : MonoBehaviour
{
    public Slider slider;            //로딩 진행도를 알려줄 슬라이더 UI

    void Start()
    {
            StartCoroutine(SceneLoad());
    }
    IEnumerator SceneLoad()
    {
        yield return null;
        //씬 로딩 시작
        AsyncOperation async = Application.LoadLevelAsync(2);
        //async.allowSceneActivation = false;

        float timer = 0.0f;
        while (!async.isDone)
        {
            yield return null;

            timer += Time.deltaTime;

            if (async.progress >= 0.9f)
            {
                slider.value = async.progress;

                if (slider.value == 1f)
                    async.allowSceneActivation = true;
            }
            else
            {
                slider.value = async.progress;
                if (slider.value >= async.progress)
                {
                    timer = 0f;
                }
            }
        }
    }
}