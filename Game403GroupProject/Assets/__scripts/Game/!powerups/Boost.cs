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
