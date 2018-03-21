using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    private HUDController hudController;
    public GameObject pauseMenu;
    public GameObject cd_text;

    private Text countDown;
    private float startTime = 0f;
    private bool isGameStarted = false;

    /*public void GenerateRandomPowerup(GameObject player)
    {
        int random_powerup = Random.Range(0, Powerup.POWERUP_COUNT - 1);
        Powerup currentpowerup;
        switch(random_powerup)
        {
            case 0:
                currentpowerup = new RepairKit(hudController);
                break;
            case 1:
                currentpowerup = new Boost(hudController);
                break;
            case 2:
                currentpowerup = new Missile(hudController);
                break;
            case 3:
                currentpowerup = new OilSlick(hudController);
                break;
            default:
                currentpowerup = null;
                break;
        }
        player.GetComponent<Car>().SetPowerup(currentpowerup);
        FindObjectOfType<HUDController>().HeldPowerup = random_powerup;
    }*/
	// Use this for initialization
	void Start () {
        
        hudController = GameObject.FindObjectOfType<HUDController>();
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
            UIManager.Instance.ShowUIContent(pauseMenu);
            
        }
        hudController.RaceTime = Time.time - startTime;
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
        GameObject[] allCars = GameObject.FindGameObjectsWithTag("Car");
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
