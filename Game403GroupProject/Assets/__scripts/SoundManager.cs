using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("UIManager");
                    instance = go.AddComponent<SoundManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    private static SoundManager instance = null;

    public SoundManager GetInstance()
    {
        return Instance;
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Functions go here

}
