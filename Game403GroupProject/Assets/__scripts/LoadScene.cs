using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    public static LoadScene Instance = null;

    private float fTime;
    private float screen_width;
    private float image_offsetX = 25f;
    private float image_offsetY = -15f;
    // Use this for initialization
    void Start()
    {
        if (Instance = null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            //Destroy(this);
        }
        DontDestroyOnLoad(this);
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
        
        // wating 1 sec to look good
        yield return new WaitForSeconds(1.0f);

        AsyncOperation async_op = SceneManager.LoadSceneAsync(nextscene);
        async_op.allowSceneActivation = false;

        fTime = 0f;
        Image loadingBar = GameObject.Find("loadingBar").GetComponent<Image>();
        Text loadingText = GameObject.Find("loadingText").GetComponent<Text>();
        loadingBar.fillAmount = 0;
        loadingText.text = "0%";

        while (async_op.isDone == false)
        {
            
            yield return new WaitForSeconds(0.1f);
            fTime += Time.smoothDeltaTime;

            if (async_op.progress >= 0.9f)
            {
                //fill image
                loadingBar.fillAmount = Mathf.Lerp(loadingBar.fillAmount, 1f, fTime);

                //25 offset ( half size of image )
                float scr_pos_x = (loadingBar.fillAmount * Screen.width) + image_offsetX;
                //loading_screen_image.rectTransform.anchoredPosition = new Vector2(scr_pos_x, image_offsetY);
                // Debug.Log(loading_screen_image.rectTransform.anchoredPosition);

                float progress_num = loadingBar.fillAmount * 100.0f;
                int roundNum = Mathf.RoundToInt(progress_num);

                loadingText.text = roundNum.ToString() + "%";

                if (Mathf.Approximately(loadingBar.fillAmount, 1f) == true)
                {
                    async_op.allowSceneActivation = true;
                }
            }
            else
            {
                loadingBar.fillAmount = Mathf.Lerp(loadingBar.fillAmount, async_op.progress, fTime);

                //25 offset ( half size of image )
                float scr_pos_x = (loadingBar.fillAmount * screen_width) + image_offsetX;
                //loading_screen_image.rectTransform.anchoredPosition = new Vector2(scr_pos_x, image_offsetY);
                // Debug.Log(loading_screen_image.rectTransform.anchoredPosition);
                float progress_num_ = loadingBar.fillAmount * 100.0f;
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
