using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedPowerup : BasePowerup {

    public override void Apply(GameObject target)
    {
        PlayerStats playerStats = target.GetComponent<PlayerStats>();

        if(playerStats != null)
        {
            playerStats.MoveSpeed = playerStats.MultiplicativeIncrease(playerStats.MoveSpeed, powerupValue);
            Destroy(this.gameObject);
        }
        
    }
}
