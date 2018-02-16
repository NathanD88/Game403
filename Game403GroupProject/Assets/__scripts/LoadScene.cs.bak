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
        DontDestroyOnLoad(this);
        if (Instance == null)
        {
            Instance = this;
        }
        if (Instance != this)
        {
           Destroy(this);
        }
        
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
        float finishtime = Time.time + 5f;
        // wating 1 sec to look good
        yield return new WaitForSeconds(1f);

        Image loadingBar = GameObject.Find("barOverlap").GetComponent<Image>();
        loadingBar.rectTransform.sizeDelta = new Vector2(Screen.width, 30);
        float endTime = Time.time + 5f;
        AsyncOperation async_op = SceneManager.LoadSceneAsync(nextScene);
        async_op.allowSceneActivation = false;
        fTime = 0f;
        Text loadingText = GameObject.Find("loadingText").GetComponent<Text>();
        cScale = GameObject.Find("Canvas").GetComponent<CanvasScaler>();
        //loadingBar.fillAmount = 0;
        loadingBar.rectTransform.sizeDelta = new Vector2 (Screen.width - (Screen.width * async_op.progress), 30);
        loadingText.text = (async_op.progress * 100).ToString() + "%";

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
