using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Racer names!
    public string[] names;
    private List<string> racer_names = new List<string>();

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
    [HideInInspector]
    public bool isGameOver = false;


    // Use this for initialization
    public void nowStart ()
    {
        FillNameList();

        // Populate the cars array
        allCars = GameObject.FindGameObjectsWithTag("PlayerCar");

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

        FindObjectOfType<PositionTracker>().nowStart();

        countDown = cd_text.GetComponent<Text>();
        StartCoroutine(StartCountdown());
    }

    public void pauseButton()
    {
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
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

	public void ResumeButton()
	{
		Time.timeScale = 1f;
		pauseMenu.SetActive (false);
	}

    public void RestartButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitButton()
    {
		Time.timeScale = 1f;
        SceneManager.LoadScene("StartScreen");
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
        
        isGameStarted = true;
    }

    public bool IsGameStarted()
    {
        return isGameStarted;
    }

    private void FillNameList()
    {
        foreach(string s in names)
        {
            racer_names.Add(s);
        }
    }
}
