using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
    
    public static UIManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<UIManager>();
                if(instance == null)
                {
                    GameObject go = new GameObject("UIManager");
                    instance = go.AddComponent<UIManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    private static UIManager instance = null;

    public UIManager GetInstance()
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
    private GameObject GetObject(string uiName)
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find(uiName).gameObject;
        return obj;
    }
    public void ShowUIContent(string name)
    {
        GameObject obj = GetObject(name);
        if(!obj.activeSelf)
        {
            obj.SetActive(true);
        }
        else
        {
            obj.SetActive(false);
        }
    }

    
}
