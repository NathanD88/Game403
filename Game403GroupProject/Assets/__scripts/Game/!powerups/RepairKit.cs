using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairKit : Powerup {

	public RepairKit()
    {
        Debug.Log("repair kit created");
    }

    public override void UsePowerup()
    {
        Debug.Log("Have some armor");
    }
}

/*
 * if(input.getbutton(use)
 *      player.currentPower.usepowerup() 
 */