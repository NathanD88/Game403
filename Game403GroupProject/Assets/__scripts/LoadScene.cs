using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Exit the game
	public void gameexit()
	{
		Application.Quit();
	}

    // Load the given scene
    public void LoadNextScene(string sName)
    {
		SceneManager.LoadScene(sName);
    }
}
