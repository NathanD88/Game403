using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : Powerup {

    private HUDController _hudController;

    public Boost(HUDController hc)
    {
        _hudController = hc;
    }
    public override void UsePowerup(Car c)
    {
        _hudController.HeldPowerup = -1;
    }
}
