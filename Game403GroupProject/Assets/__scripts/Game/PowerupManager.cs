using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour {
    public GameObject pickup_prefab;
    private Transform[] allSpawns;

    //random pickup vars
    private bool generating = false;
    private float endTime = 0.0f;
    private HUDController _hudcontroller;
    private GameObject player = null;
    int last = -1;
    int rand_pickup = -1;
    // Use this for initialization
    void Start () {
        _hudcontroller = FindObjectOfType<HUDController>();
        allSpawns = gameObject.GetComponentsInChildren<Transform>();
        SpawnPickups();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void SpawnPickups()
    {
        foreach(Transform t in allSpawns)
        {
            Instantiate(pickup_prefab, t.position, pickup_prefab.transform.rotation);
        }
    }

    public void RandomPickupPlayer(GameObject targetPlayer)
    {
        if (!generating)
        {
            player = targetPlayer;
            generating = true;
            endTime = Time.time + 5f;
            //GeneratePickup();
            StartCoroutine(GeneratePickup());
        }
    }
    /*
    private void GeneratePickup()
    {
        int rand_pickup;
        if (Time.time < endTime)
        {
            rand_pickup = Random.Range(0, Powerup.POWERUP_COUNT - 1);
            _hudcontroller.HeldPowerup = rand_pickup;
            GeneratePickup();
        }
        rand_pickup = Random.Range(0, Powerup.POWERUP_COUNT - 1);
        Powerup currentpowerup;
        switch (rand_pickup)
        {
            case 0:
                currentpowerup = new RepairKit(_hudcontroller);
                break;
            case 1:
                currentpowerup = new Boost(_hudcontroller);
                break;
            case 2:
                currentpowerup = new Missile(_hudcontroller);
                break;
            case 3:
                currentpowerup = new OilSlick(_hudcontroller);
                break;
            default:
                currentpowerup = null;
                break;
        }
        player.GetComponent<Car>().SetPowerup(currentpowerup);
        _hudcontroller.HeldPowerup = rand_pickup;
        player = null;
        generating = false;
    }*/
    
    private IEnumerator GeneratePickup()
    {
        yield return new WaitForSeconds(0.05f);
        if (Time.time < endTime)
        {
            //last = rand_pickup;
            rand_pickup = Random.Range(0, Powerup.POWERUP_COUNT - 1);
            if(rand_pickup == last)
            {
                if(rand_pickup + 1 > Powerup.POWERUP_COUNT - 1)
                {
                    rand_pickup = 0;
                }
                else
                {
                    rand_pickup += 1;
                }
            }
            last = rand_pickup;
            _hudcontroller.HeldPowerup = rand_pickup;
            
            StartCoroutine(GeneratePickup());
        }
        else
        {
            rand_pickup = Random.Range(0, Powerup.POWERUP_COUNT - 1);
            if (rand_pickup == last)
            {
                if (rand_pickup + 1 > Powerup.POWERUP_COUNT - 1)
                {
                    rand_pickup = 0;
                }
                else
                {
                    rand_pickup += 1;
                }
            }
            Powerup currentpowerup;
            switch (rand_pickup)
            {
                case 0:
                    currentpowerup = new RepairKit(_hudcontroller);
                    break;
                case 1:
                    currentpowerup = new Boost(_hudcontroller);
                    break;
                case 2:
                    currentpowerup = new Missile(_hudcontroller);
                    break;
                case 3:
                    currentpowerup = new OilSlick(_hudcontroller);
                    break;
                default:
                    currentpowerup = null;
                    break;
            }
            player.GetComponent<Car>().SetPowerup(currentpowerup);
            _hudcontroller.HeldPowerup = rand_pickup;
            player = null;
            generating = false;
        }
    }
}
