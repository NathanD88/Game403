using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Powerup powerup = null;
    public int position;
    public int currentLap = 0;
    public float distance = 0;
    public int nextWaypoint = 0;
    public float armor = 100;
    public float maxArmor = 100;

    private bool BOOST = false;

    public Transform MissileSpawn;
    public Transform BombSpawn;

    public enum CAR_TYPE {Muscle, Sport, Tuner };
    public CAR_TYPE m_type;

    //public WheelCollider f_left, f_right;

    private Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        //powerup = new Boost(FindObjectOfType<HUDController>());
        rb = GetComponent<Rigidbody>();
        //SetCarStats();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButton("Use Powerup") && powerup != null)
        {
            powerup.UsePowerup(this);
        }
        else if (Input.GetButton("Use Powerup") && powerup == null)
        {
            Debug.Log("Sorry, no power to use :(");
        }
        //Debug.Log("Lap: " + currentLap + "  Next Waypoint: " + nextWaypoint);
        if(BOOST)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity *= 1.015f;
        }
    }

    public void SetPowerup(Powerup p)
    {
        powerup = p;
    }

    private void SetCarStats()
    {
        //initialize the cars with the appropriate vehicle properties
        int c_type = (int)m_type;
        switch(c_type)
        {//adjust mass, drag and suspension
            case 0:
                rb.mass = 1000;
                break;
            case 1:
                rb.mass = 1000;
                break;
            case 2:
                rb.mass = 1000;
                break;
        }
    }

    public void TakeDamage(float damage)
    {
        armor = (armor - damage < 0) ? 0 : armor - damage;
    }

    public void RestoreArmor(float restore)
    {
        armor = (armor + restore > maxArmor) ? maxArmor : armor + restore;
    }

    public void SetMaxArmor(float newArmor)
    {
        maxArmor = newArmor;
    }

    public void ActivateBoost(bool b)
    {
        BOOST = b;
        if(b == true)
        {
            StartCoroutine(BoostDelay());
        }
        else
        {
            powerup = null;
        }
    }

    private IEnumerator BoostDelay()
    {
        yield return new WaitForSeconds(0.5f);

        ActivateBoost(false);
    }
}
