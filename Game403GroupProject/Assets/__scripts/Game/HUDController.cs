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
    private float raceTime;

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

    public RectTransform currentArmorHUD;
    public Text lapText;
    public Text raceTimeText;

    // Use this for initialization
    void Start ()
    {
        currentArmor = 10.0f;
        maxArmor = 10.0f;
        currentLap = 2;
        totalLaps = 3;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float raceTimeMinutes = (int)(raceTime / 60);
        float raceTimeSeconds = raceTime % 60;

        // Demo purposes
        currentArmor = Mathf.Abs(Mathf.Sin(Time.time)) * 10.0f;
        //

        currentArmorHUD.localScale = new Vector3(currentArmor / maxArmor, 1.0f, 1.0f);
        lapText.text = currentLap.ToString() + " / " + totalLaps.ToString();
        raceTimeText.text = raceTimeMinutes.ToString() + ":" + raceTimeSeconds.ToString("00.00");
	}

}
