using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeForcePowerup : BasePowerup {
    public override void Apply(GameObject target)
    {
        PlayerStats playerStats = target.GetComponent<PlayerStats>();

        if (playerStats != null)
        {
            playerStats.DodgeForce = playerStats.MultiplicativeIncrease(playerStats.DodgeForce, powerupValue);
            Destroy(this.gameObject);
        }
    }
}
