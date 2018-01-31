using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    public static LoadScene Instance = null;

    private CanvasScaler cScale;
    private float fTime;
    private float screen_width;
    private float image_offsetX = 25f;
    private float image_offsetY = -15f;
    private float loadingChunk = 0f;
    // Use this for initialization
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            //Destroy(this);
        }
        DontDestroyOnLoad(this);
        screen_width = Screen.width;
        loadingChunk = screen_width / 100;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //custom function go here

    public void LoadNextScene(string sName)
    {
        if(Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        SceneManager.LoadScene("LoadingScreen");
        StartCoroutine(LoadNextSceneAsync(sName));
    }
    private IEnumerator LoadNextSceneAsync(string nextScene)
    {
        // wating 1 sec to look good
        yield return new WaitForSeconds(1.0f);

        Image loadingBar = GameObject.Find("barOverlap").GetComponent<Image>();
        loadingBar.rectTransform.sizeDelta = new Vector2(Screen.width, 30);
        float endTime = Time.time + 5f;
        AsyncOperation async_op = SceneManager.LoadSceneAsync(nextScene);
        async_op.allowSceneActivation = false;

        bool done = false;

        while(!done)
        {
            yield return new WaitForSeconds(0.1f);
            float progress = Time.time / endTime;
            if (Time.time >= endTime)
            {
                progress = 0;
                async_op.allowSceneActivation = true;
                done = true;
            }
            else
            {
                float width = Screen.width - (Screen.width * progress);
                loadingBar.rectTransform.sizeDelta = new Vector2(width, 30);
            }
        }
    }
}
