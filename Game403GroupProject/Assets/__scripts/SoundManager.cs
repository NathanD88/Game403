using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager Instance = null;


	// Use this for initialization
	void Start () {
        if (Instance == null)
        {
            Instance = this;
        }
        if (Instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Functions go here

}
