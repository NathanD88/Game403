﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Reference to HUDController
    private HUDController hudController;

    // Reference to the Car that the player is controlling
    public Car playerCar;

    // Array of all the car gameobjects
    GameObject[] allCars;

    public GameObject pauseMenu;
    public GameObject cd_text;
    
    private Text countDown;
    private float startTime = 0f;
    private bool isGameStarted = false;

    
	// Use this for initialization
	void Start ()
    {
        // Populate the cars array
        allCars = GameObject.FindGameObjectsWithTag("Car");

        // Attach the HUDController
        hudController = GameObject.FindObjectOfType<HUDController>();

        countDown = cd_text.GetComponent<Text>();
        StartCoroutine(StartCountdown());
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

        // Update HUD information
        hudController.RaceTime = Time.time - startTime;
        hudController.Position = playerCar.position;
        hudController.CurrentLap = playerCar.currentLap;
        hudController.CurrentArmor = playerCar.armor;
        hudController.MaxArmor = playerCar.maxArmor;
    }

    public void QuitButton()
    {
        LoadScene.Instance.LoadNextScene("StartScreen");
    }

    private IEnumerator StartCountdown()
    {
        hudController.DisableRaceTimeText();
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
        startTime = Time.time;
        hudController.RaceTime = Time.time - startTime;
        hudController.EnableRaceTimeText();
        
        if (allCars.Length > 1)
        {
            Debug.Log(allCars.Length);
            foreach (GameObject g in allCars)
            {
                g.GetComponent<CarEngine>().StartGame(true);
            }
        }
        isGameStarted = true;
    }

    public bool IsGameStarted()
    {
        return isGameStarted;
    }
}
