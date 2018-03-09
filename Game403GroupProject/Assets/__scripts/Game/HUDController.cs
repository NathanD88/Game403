using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    private float currentArmor;
    private float maxArmor;
    private int currentLap;
    private int totalLaps;
    private int position;
    private int heldPowerup;
    private float raceTime;
    private float speed;

    private bool lapTimeShowing;

    private GameController _gameController;

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    public int HeldPowerup
    {
        get
        {
            return heldPowerup;
        }
        set
        {
            heldPowerup = value;
        }
    }

    public int Position
    {
        get
        {
            return position;
        }
        set
        {
            position = value;
        }
    }

    public float RaceTime
    {
        get
        {
            return raceTime;
        }
        set
        {
            raceTime = value;
        }
    }

    public int CurrentLap
    {
        get
        {
            return currentLap;
        }
        set
        {
            if (value < 0)
            {
                currentLap = 1;
            }
            else if (value > totalLaps)
            {
                currentLap = totalLaps;
            }
            else
            {
                currentLap = value;
            }
        }
    }

    public int TotalLaps
    {
        get
        {
            return totalLaps;
        }
        set
        {
            if (value < 0)
            {
                totalLaps = 1;
            }
            else
            {
                totalLaps = value;
            }
        }
    }

    public float CurrentArmor
    {
        get
        {
            return currentArmor;
        }
        set
        {
            currentArmor = value;
        }
    }

    public float MaxArmor
    {
        get
        {
            return maxArmor;
        }
        set
        {
            maxArmor = value;
        }
    }

    // HUD Element References
    [Header("Element References")]
    public RectTransform currentArmorHUD;
    public RectTransform speedometerNeedleHUD;
    public Text lapText;
    public Text raceTimeText;
    public Text lapTimeText;
    public Text positionText;
    public Image heldItemHUD;
    //
    public Text item_text;
    //

    [Space(10)]
    [Header("Speedometer Needle")]
    public float needleStartAngle = 90.0f;
    public float needleMaxAngle = -45.0f;

    [Space(10)]
    [Header("Powerup Images")]
    public Sprite[] powerups;

    // Use this for initialization
    void Start()
    {
        _gameController = GameObject.FindObjectOfType<GameController>();
        // Defaults
        lapTimeShowing = false;
        heldPowerup = -1;
        currentArmor = 10.0f;
        maxArmor = 10.0f;
        currentLap = 1;
        totalLaps = 3;
        position = 1;

        // Ensures that the number of powerup images matches the length of the powerups enum
        if (Powerup.POWERUP_COUNT != powerups.Length)
        {
            Debug.LogError("powerups enum from GameController script does not match number of powerup images in HUDController script!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Demo purposes ***
        currentArmor = Mathf.Abs(Mathf.Sin(Time.time)) * 10.0f;
        speed = Mathf.Abs(Mathf.Sin(Time.time)) * 200.0f;
        //raceTime = Time.time;
        if (Time.time % 4 >= 3 && !lapTimeShowing && _gameController.IsGameStarted())
        {
            StartCoroutine(showLapTime(RaceTime, 2.0f));
        }
        // ***

        // Convert race time into minutes and seconds
        float raceTimeMinutes = (int)(raceTime / 60);
        float raceTimeSeconds = raceTime % 60;

        // Update HUD elements
        currentArmorHUD.localScale = new Vector3(currentArmor / maxArmor, 1.0f, 1.0f);
        lapText.text = currentLap.ToString() + " / " + totalLaps.ToString();
        raceTimeText.text = raceTimeMinutes.ToString() + ":" + raceTimeSeconds.ToString("00.00");
        positionText.text = intToOrdinal(position);
        float needleZ = Mathf.Lerp(needleStartAngle, needleMaxAngle, speed / 200.0f);
        speedometerNeedleHUD.transform.eulerAngles = new Vector3(1.0f, 1.0f, needleZ);

        // Update held item image
        if (heldPowerup < -1 || heldPowerup > Powerup.POWERUP_COUNT)
        {
            heldPowerup = -1;
            Debug.LogWarning("Attempted to allocate a powerup outside of the range.");
        }
        else if (heldPowerup == -1)
        {
            heldItemHUD.sprite = null;
        }
        else
        {
            heldItemHUD.sprite = powerups[heldPowerup];
        }
	}

    // Display the lap time for a specified number of seconds
    public IEnumerator showLapTime(float lapTime, float timeToDisplay)
    {
        // Ensures the coroutine is only running once
        lapTimeShowing = true;
        
        // Convert lap time into minutes and seconds
        float lapTimeMinutes = (int)(lapTime / 60);
        float lapTimeSeconds = lapTime % 60;

        // Display lap time
        lapTimeText.text = "Lap Time  " + lapTimeMinutes.ToString() + ":" + lapTimeSeconds.ToString("00.00");
        lapTimeText.enabled = true;

        // Wait for the specified time before hiding again
        yield return new WaitForSeconds(timeToDisplay);
        hideLapTime();

        lapTimeShowing = false;
    }

    // Hide the lap time
    public void hideLapTime()
    {
        lapTimeText.enabled = false;
    }

    // Convert an integer into an ordinal number
    private string intToOrdinal(int i)
    {
        string s = i.ToString();

        switch (i % 10)
        {
            case 1:
                s = s + "st";
                break;
            case 2:
                s = s + "nd";
                break;
            case 3:
                s = s + "rd";
                break;
            default:
                s = s + "th";
                break;
        }

        return s;
    }
    public void DisableRaceTimeText()
    {
        raceTimeText.gameObject.SetActive(false);
    }
    public void EnableRaceTimeText()
    {
        raceTimeText.gameObject.SetActive(true);
    }
}
