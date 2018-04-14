using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Powerup {

    private HUDController _hudController;

    public Bomb(HUDController hc)
    {
        _hudController = hc;
    }
    public override void UsePowerup(Car c)
    {
        GameObject player = c.gameObject;
        GameObject.FindObjectOfType<PowerupManager>().DropBomb(player);
        c.powerup = null;
        _hudController.HeldPowerup = -1;
    }
}
