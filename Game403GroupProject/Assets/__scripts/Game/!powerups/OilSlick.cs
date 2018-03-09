using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilSlick : Powerup {

	public OilSlick()
    {
        //create oil ref
    }
    public override void UsePowerup()
    {
        Debug.Log("oiled");
    }
}
