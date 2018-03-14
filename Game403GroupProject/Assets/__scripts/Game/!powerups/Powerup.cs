using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Powerup  {
    
    public enum PowerupType
    {
        RepairKit,
        Boost,
        Missile,
        Oil,
    }

    public static int POWERUP_COUNT = Enum.GetNames(typeof(PowerupType)).Length;

    public PowerupType m_powerup;
    
    //duration, description, spawn rate
    public virtual void UsePowerup()
    {

    }
}
