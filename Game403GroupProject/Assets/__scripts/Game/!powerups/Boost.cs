using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : Powerup {

	public Boost()
    {
        Debug.Log("boost powerup created");
    }
    public override void UsePowerup()
    {
        Debug.Log("speeeeeeeeeed!!!");
    }
}
