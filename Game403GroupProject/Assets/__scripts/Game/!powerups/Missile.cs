using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Powerup {

    private HUDController _hudController;

    public Missile(HUDController hc)
    {
        _hudController = hc;
        
    }
    public Missile()
    {
        m_powerup = PowerupType.Missile;
    }
    public override void UsePowerup(Car c)
    {
        GameObject player = c.gameObject;
        GameObject.FindObjectOfType<PowerupManager>().SpawnMissile(player);
        _hudController.HeldPowerup = -1;
        c.powerup = null;
    }
}
