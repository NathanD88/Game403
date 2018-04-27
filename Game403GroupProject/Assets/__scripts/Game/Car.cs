using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    //race vars
    public int position;
    public int currentLap = 3;
    public float distance = 0;
    public int nextWaypoint = 0;
    public Vector3 resetPosition;
    public Quaternion resetView;

    //powerup vars
    public Powerup powerup = null;
    private bool BOOST = false;
    public bool isAI = true;
    public Transform MissileSpawn;
    public Transform BombSpawn;

    //car related vars
    public enum CAR_TYPE {Muscle, Sport, Tuner };
    public CAR_TYPE m_type;
    public float armor = 100;
    public float maxArmor = 100;
    private Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        resetView = GetComponent<Rigidbody>().rotation;
        resetPosition = GetComponent<Rigidbody>().transform.position;

        //SetCarStats();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButton("Use Powerup"))
        {
            if (!isAI)
            {
                checkFire();
            }
            else
            {
                if (powerup != null)
                {
                    UseAIPowerup();
                }
            }            
        }

        if (BOOST)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity *= 1.01f;
        }

        if(armor <= 0)
        {
            GameObject.FindObjectOfType<OutOfBounds>().ResetCar(this);
            armor = 100;
        }
    }

    private void UseAIPowerup()
    {
        if(powerup.m_powerup == Powerup.PowerupType.Missile && position != 1)
        {
            if(RaycastMissileTarget())
            {
                GameObject.FindObjectOfType<PowerupManager>().SpawnMissile(this.gameObject);
                powerup = null;
            }
        }
        else if(powerup.m_powerup == Powerup.PowerupType.Boost)
        {
            ActivateBoost(true);
            powerup = null;
        }
        else if(powerup.m_powerup == Powerup.PowerupType.RepairKit)
        {
            RestoreArmor(100);
            powerup = null;
        }
        else
        {
            GameObject.FindObjectOfType<PowerupManager>().DropBomb(this.gameObject);
            powerup = null;
        }
    }

    public void checkFire()
    {
        if (powerup != null)
        {
            powerup.UsePowerup(this);
        }
        
    }

    private bool RaycastMissileTarget()
    {
        bool hastarget = false;

        Ray ray = new Ray(MissileSpawn.position, transform.forward * 20f);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider.CompareTag("Car"))
            {
                hastarget = true;
            }
        }

        return hastarget;
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
