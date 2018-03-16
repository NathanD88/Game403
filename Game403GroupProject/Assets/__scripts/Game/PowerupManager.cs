using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour {
    public GameObject pickup_prefab;
    private Transform[] allSpawns;
	// Use this for initialization
	void Start () {
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
}
