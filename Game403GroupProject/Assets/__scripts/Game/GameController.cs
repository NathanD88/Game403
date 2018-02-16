using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public GameObject pauseMenu;
    public GameObject cd_text;

    private Text countDown;
	// Use this for initialization
	void Start () {
        countDown = cd_text.GetComponent<Text>();
        StartCoroutine(StartCountdown());
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return))
        {
            if(pauseMenu.activeSelf)
            {
                Time.timeScale = 1f;
            }
            else
            {
                Time.timeScale = 0f;
            }
            UIManager.Instance.ShowUIContent("pauseMenu");
            
        }
	}
    public void QuitButton()
    {
        LoadScene.Instance.LoadNextScene("StartScreen");
    }

    private IEnumerator StartCountdown()
    {
        int cnt = 5;
        countDown.text = cnt.ToString();
        while(cnt > 0)
        {
            yield return new WaitForSeconds(1f);
            cnt -= 1;
            countDown.text = cnt.ToString();
        }
        cd_text.SetActive(false);
        StartRace();
    }
    private void StartRace()
    {
        GameObject[] allCars = GameObject.FindGameObjectsWithTag("Car");
        Debug.Log(allCars.Length);
        foreach(GameObject g in allCars)
        {
            g.GetComponent<CarEngine>().StartGame(true);
        }
    }
}
