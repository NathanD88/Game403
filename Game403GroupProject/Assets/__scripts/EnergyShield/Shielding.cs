using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shielding : MonoBehaviour {

    public float decaying = 10;

    void Update ()
    {
        decaying -= Time.deltaTime;

        if(decaying <= 0)
        {
            gameObject.SetActive(false);
        }
	}
}
