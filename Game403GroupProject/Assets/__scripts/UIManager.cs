using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject LoadingBar;
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
        GameObject obj = null;
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas)
        {
            Debug.Log("in here " + uiName);
            Transform test = canvas.transform.Find(uiName);
            if (test != null)
            {
                Debug.Log("in here 2 " + uiName);
                obj = test.gameObject;
            }
        }
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
    public void ShowUIContent(GameObject obj)
    {
        if (!obj.activeSelf)
        {
            obj.SetActive(true);
        }
        else
        {
            obj.SetActive(false);
        }
    }

    public Image FindImageInScene(string iName)
    {
        GameObject canv = GameObject.Find("Canvas");
        Image[] images = canv.GetComponentsInChildren<Image>();
        foreach(Image i in images)
        {
            if(i.gameObject.name == iName)
            {
                return i;
            }
        }
        return null;
    }

    public void ShowRaceStandings(GameObject pos_panel)
    {
        if (!pos_panel.activeSelf)
            pos_panel.SetActive(true);

        Image[] pos_text = pos_panel.GetComponentsInChildren<Image>();

        Car[] allCars = GameObject.FindObjectsOfType<Car>();
        for(int i = 1; i < pos_text.Length;i++)
        {
            foreach(Car c in allCars)
            {
                if(c.position == i-1)
                {
                    pos_text[i].GetComponentInChildren<Text>().text = c.gameObject.name;
                    break;
                }
            }
        }
    }
}
