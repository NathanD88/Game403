using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    private CanvasScaler cScale;
    private float fTime;
    private float screen_width;
    private float image_offsetX = 25f;
    private float image_offsetY = -15f;
    private float loadingChunk = 0f;

    public static LoadScene Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LoadScene>();
                if (instance == null)
                {
                    GameObject go = new GameObject("SceneManager");
                    instance = go.AddComponent<LoadScene>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    private static LoadScene instance = null;

    public LoadScene GetInstance()
    {
        return Instance;
    }
    // Use this for initialization
    void Start()
    {        
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
        //SceneManager.LoadScene("LoadingScreen");
        Debug.Log("After load scene: loading screen");
        // wating 1 sec to look good
        //yield return new WaitForSeconds(1f);

        AsyncOperation async_op = SceneManager.LoadSceneAsync(nextScene);
        async_op.allowSceneActivation = false;

        //debug only
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);

        Image loadingBar = UIManager.Instance.LoadingBar.GetComponent<Image>();
        loadingBar.rectTransform.sizeDelta = new Vector2(Screen.width, 30);
        loadingBar.rectTransform.sizeDelta = new Vector2 (Screen.width - (Screen.width * async_op.progress), 30);

        bool done = false;

        while(!done)
        {
            Debug.Log("inside the while loop");
            float progress = async_op.progress;
            Debug.Log(progress);
            yield return new WaitForSeconds(0.1f);
            
            if (progress >=1f)
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
        Debug.Log("after the while loop");
    }
}
