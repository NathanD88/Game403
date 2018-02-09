using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject pauseMenu;
    private HUDController hudController;

	// Use this for initialization
	void Start ()
    {
        hudController = GameObject.FindObjectOfType<HUDController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
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
            UIManager.Instance.ShowUIContent(pauseMenu);
            
        }
	}
    public void QuitButton()
    {
        LoadScene.Instance.LoadNextScene("StartScreen");
    }
}
