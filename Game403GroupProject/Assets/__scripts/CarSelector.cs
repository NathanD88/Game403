using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSelector : MonoBehaviour {

	private GameObject[] Models;
	//Default index of the car

	private int index;

	// Use this for initialization
	void Start ()
    {

        index = PlayerPrefs.GetInt("SelectedCar");

		Models = new GameObject[transform.childCount];

		//fill the array with models
		for (int i = 0; i < transform.childCount; i++) 
		{
			Models[i] = transform.GetChild(i).gameObject;
		}

		//toggle off renderer for all
		foreach (GameObject cars in Models) 
		{
			cars.SetActive (false);
		}

		//toggle the first index to be visible
		if (Models[index]) 
		{
			Models[index].SetActive (true);
            Models[index].GetComponent<Car>().isAI = false;
		}
        
        if(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RVP.CameraControl>() != null)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RVP.CameraControl>().target = Models[index].transform;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RVP.CameraControl>().Initialize();
            GameObject.FindObjectOfType<PlayerWaypoint>().car = Models[index].gameObject;
            GameObject.FindObjectOfType<GameController>().playerCar = Models[index].GetComponent<Car>();
            GameObject.FindObjectOfType<GameController>().nowStart();
        }


	}

	public void ToggleLeft ()
	{
		//Off current model
		Models[index].SetActive(false);

		index--; // index 
		if (index < 0) //Set index within range 
		{
			index = Models.Length - 1;
		}

		//turn On new Models
		Models [index].SetActive (true);
	}

	public void ToggleRight ()
	{
		//Off current model
		Models[index].SetActive(false);

		index++; // index 
		if (index == Models.Length ) //Set index within range 
		{
			index = 0;
		}

		//turn On new Models
		Models [index].SetActive (true);
	}
		
	public void ConfirmCar()
	{
		PlayerPrefs.SetInt ("SelectedCar", index);
		SceneManager.LoadScene ("LevelSelectScreen");
	}
}