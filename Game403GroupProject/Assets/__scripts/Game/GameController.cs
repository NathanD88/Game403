using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        allCars = GameObject.FindGameObjectsWithTag("PlayerCar");
        foreach(GameObject g in allCars)
        {
            RVP.BasicInput bi = g.GetComponent<RVP.BasicInput>();
            bi.enabled = false;
        }

        // Attach the HUDController
        hudController = GameObject.FindObjectOfType<HUDController>();

        countDown = cd_text.GetComponent<Text>();
        StartCoroutine(StartCountdown());

        Debug.Log(PlayerPrefs.GetInt("SelectedCar"));

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
        hudController.Speed = playerCar.GetComponentInParent<RVP.VehicleParent>().localVelocity.magnitude * 3.5f;
    }

	public void ResumeButton()
	{
		Time.timeScale = 1f;
		pauseMenu.SetActive (false);
	}

    public void QuitButton()
    {
        //LoadScene.Instance.LoadNextScene("StartScreen");
		SceneManager.LoadScene("StartScreen");
		Time.timeScale = 1f;
    }

    private IEnumerator StartCountdown()
    {
        hudController.DisableRaceTimeText();
        int cnt = 3;
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
        
        /*if (allCars.Length > 1)
        {
            Debug.Log(allCars.Length);
            foreach (GameObject g in allCars)
            {
                RVP.BasicInput bi = g.GetComponent<RVP.BasicInput>();
                bi.enabled = true;
            }
        }*/
        foreach (GameObject g in allCars)
        {
            RVP.BasicInput bi = g.GetComponent<RVP.BasicInput>();
            bi.enabled = true;
        }
        isGameStarted = true;
    }

    public bool IsGameStarted()
    {
        return isGameStarted;
    }
}
