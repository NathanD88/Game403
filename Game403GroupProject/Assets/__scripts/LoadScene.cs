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
    public void LoadSceneByButton(string scene)
    {
        SceneManager.LoadScene("LoadingScreen");
        StartCoroutine(LoadSceneAsync(scene));
        //LoadSceneAsync.LoadScene(scene);
    }
    private IEnumerator LoadSceneAsync(string nextscene)
    {
        float finishtime = Time.time + 5f;
        // wating 1 sec to look good
        yield return new WaitForSeconds(1f);

        AsyncOperation async_op = SceneManager.LoadSceneAsync(nextscene);
        async_op.allowSceneActivation = false;
        fTime = 0f;
        Image loadingBar = GameObject.Find("barOverlap").GetComponent<Image>();
        Text loadingText = GameObject.Find("loadingText").GetComponent<Text>();
        cScale = GameObject.Find("Canvas").GetComponent<CanvasScaler>();
        //loadingBar.fillAmount = 0;
        loadingBar.rectTransform.sizeDelta = new Vector2 (Screen.width - (Screen.width * async_op.progress), 30);
        loadingText.text = (async_op.progress * 100).ToString() + "%";

        while (async_op.isDone == false)
        {
            
            yield return new WaitForSeconds(0.1f);
            fTime += Time.smoothDeltaTime;

            if (async_op.progress >= 0.9f)
            {
                //fill image
                //loadingBar.fillAmount = Mathf.Lerp(loadingBar.fillAmount, 1f, fTime);
                float w = Screen.width - (Screen.width * async_op.progress);
                loadingBar.rectTransform.sizeDelta = new Vector2(w, 30);
                //25 offset ( half size of image )
                float scr_pos_x = (loadingBar.fillAmount * Screen.width) + image_offsetX;
                //loading_screen_image.rectTransform.anchoredPosition = new Vector2(scr_pos_x, image_offsetY);
                // Debug.Log(loading_screen_image.rectTransform.anchoredPosition);

                float progress_num = async_op.progress * 100.0f;
                int roundNum = Mathf.RoundToInt(progress_num);

                loadingText.text = roundNum.ToString() + "%";

                if (Mathf.Approximately(loadingBar.fillAmount, 1f) == true)
                {
                    async_op.allowSceneActivation = true;
                }
            }
            else
            {
                //loadingBar.fillAmount = Mathf.Lerp(loadingBar.fillAmount, async_op.progress, fTime);
                float w = Screen.width - (Screen.width * async_op.progress);
                loadingBar.rectTransform.sizeDelta = new Vector2(w, 30);
                //25 offset ( half size of image )
                //float scr_pos_x = (loadingBar.fillAmount * screen_width) + image_offsetX;
                //loading_screen_image.rectTransform.anchoredPosition = new Vector2(scr_pos_x, image_offsetY);
                // Debug.Log(loading_screen_image.rectTransform.anchoredPosition);
                float progress_num_ = async_op.progress * 100.0f;
                int round_progress_num = Mathf.RoundToInt(progress_num_);
                loadingText.text = round_progress_num.ToString() + "%";

                if (loadingBar.fillAmount >= async_op.progress)
                {
                    fTime = 0f;
                }
            }
        }
    }
}
