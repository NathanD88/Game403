using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : Powerup {
    private float endBoost = 0f;
    private HUDController _hudController;

    public Boost(HUDController hc)
    {
        _hudController = hc;
    }
    public Boost()
    {
        m_powerup = PowerupType.Boost;
    }
    public override void UsePowerup(Car c)
    {
        c.ActivateBoost(true);
        ApplyBoost(c.gameObject);
        _hudController.HeldPowerup = -1;
    }

    private void ApplyBoost(GameObject player)
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.velocity *= 2f;
        _hudController.HeldPowerup = -1;
        player.GetComponent<Car>().SetPowerup(null);
    }
}
