using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {
    public static SceneManager Instance = null;


	// Use this for initialization
	void Start () {
		if(Instance = null)
        {
            Instance = this;
        }
        if(Instance != this)
        {
            Destroy(this);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //custom function go here

}
