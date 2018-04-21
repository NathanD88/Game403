﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairKit : Powerup {

    private HUDController _hudController;

	public RepairKit(HUDController hc)
    {
        _hudController = hc;
    }
    public RepairKit()
    {
        m_powerup = PowerupType.RepairKit;
    }

    public override void UsePowerup(Car c)
    {
        c.RestoreArmor(100);
        _hudController.HeldPowerup = -1;
        c.powerup = null;
    }
}
