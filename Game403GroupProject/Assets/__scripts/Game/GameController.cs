using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Racer names!
    public string[] names;
    private List<string> racer_names;

    // Reference to HUDController
    private HUDController hudController;

    // Reference to the Car that the player is controlling
    public Car playerCar;

    // Array of all the car gameobjects
    GameObject[] allCars;

    // Reference to Pause Menu and Countdown text object
    public GameObject pauseMenu;
    public GameObject cd_text;
    
    private Text countDown;
    private float startTime = 0f;
    private bool isGameStarted = false;

    [HideInInspector]
    public bool isGameOver = false;


    // Use this for initialization
    public void nowStart ()
    {
        racer_names = new List<string>();
        FillNameList();

        // Populate the cars array
        allCars = GameObject.FindGameObjectsWithTag("PlayerCar");

        // Give each car a random name and disable inputs
        int j = racer_names.Count;
        foreach(GameObject g in allCars)
        {
            int i = Random.Range(0, j);
            g.name = racer_names[i];
            racer_names.RemoveAt(i);
            j--;

            RVP.BasicInput bi = g.GetComponent<RVP.BasicInput>();
            RVP.MobileInputGet mi = g.GetComponent<RVP.MobileInputGet>();
            bi.enabled = false;
            mi.enabled = false;
        }

        // Attach the HUDController
        hudController = GameObject.FindObjectOfType<HUDController>();

        // Start the Position Tracker Script
        FindObjectOfType<PositionTracker>().nowStart();

        countDown = cd_text.GetComponent<Text>();

        // Start the countdown
        StartCoroutine(StartCountdown());
    }

    // Update is called once per frame
    void Update ()
    {
		if(isGameOver)
        {
            if(Input.anyKeyDown)
            {
                SceneManager.LoadScene("CarSelectScene");
            }
        }

        if (Input.GetButtonDown("Pause"))
        {
            pauseButton();
        }

        // Update HUD information
        if(hudController == null)
        {
            hudController = GameObject.FindObjectOfType<HUDController>();
        }

        hudController.RaceTime = Time.time - startTime;
        hudController.Position = playerCar.position;
        hudController.CurrentLap = playerCar.currentLap;
        hudController.CurrentArmor = playerCar.armor;
        hudController.MaxArmor = playerCar.maxArmor;
        hudController.Speed = playerCar.GetComponentInParent<RVP.VehicleParent>().localVelocity.magnitude * 3.5f;
    }

    // Pause Button to activate the menu
    public void pauseButton()
    {
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
    }

    // Resume Button from Pause Menu
    public void ResumeButton()
	{
		Time.timeScale = 1f;
		pauseMenu.SetActive (false);
	}

    // Restart Button from Pause Menu
    public void RestartButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Quit Button from Pause Menu
    public void QuitButton()
    {
		Time.timeScale = 1f;
        SceneManager.LoadScene("StartScreen");
    }

    // The countdown script
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

    // Start the Race
    private void StartRace()
    {
        // Initialize the race time
        startTime = Time.time;
        hudController.RaceTime = Time.time - startTime;
        hudController.EnableRaceTimeText();
        
        // Go through each car and turn on the appropriate input based on platform
        foreach (GameObject g in allCars)
        {
            RVP.BasicInput bi = g.GetComponent<RVP.BasicInput>();
            RVP.MobileInputGet mi = g.GetComponent<RVP.MobileInputGet>();
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                bi.enabled = true;
                mi.enabled = false;
            }
            else if (Application.platform == RuntimePlatform.Android)
            {
                mi.enabled = true;
                bi.enabled = false;
            }
            else if (Application.platform == RuntimePlatform.WSAPlayerX64)
            {
                bi.enabled = true;
                mi.enabled = false;
            }
        }
        
        // Set game started
        isGameStarted = true;
    }

    // Getter for if the game is started
    public bool IsGameStarted()
    {
        return isGameStarted;
    }

    // Fill the name list with the string array from editor
    private void FillNameList()
    {
        foreach(string s in names)
        {
            racer_names.Add(s);
        }
    }
}
