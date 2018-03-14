using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Powerup {

    private HUDController _hudController;

    public Missile(HUDController hc)
    {
        _hudController = hc;
    }
    public override void UsePowerup()
    {
        _hudController.HeldPowerup = -1;
    }
}
