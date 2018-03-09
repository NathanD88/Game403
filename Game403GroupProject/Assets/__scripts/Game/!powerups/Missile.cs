using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Powerup {

	public Missile()
    {
        //create missile ref
    }
    public override void UsePowerup()
    {
        Debug.Log("missile has been shot");
    }
}
