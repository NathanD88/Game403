using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {
    public Powerup powerup = null;

    public enum CAR_TYPE {Muscle, Sport, Tuner };
    public CAR_TYPE m_type;

    //public WheelCollider f_left, f_right;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        //powerup = new RepairKit();
        rb = GetComponent<Rigidbody>();
        //SetCarStats();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && powerup != null)
        {
            powerup.UsePowerup();
        }
        else if(Input.GetKeyDown(KeyCode.Space) && powerup == null)
        {
            Debug.Log("Sorry, no power to use :(");
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
}
