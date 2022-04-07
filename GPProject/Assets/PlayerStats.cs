using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    AnimatorManager animatorManager;

    private void Start()
    {
        animatorManager = GetComponent<AnimatorManager>();
        
    }

    public override void Die()
    {
        base.Die();
        // Kill player
        //PlayerManager.Respawn();
        animatorManager.PlayTargetAnimation("2Hand-Sword-Death1", true);
    }

    public override void TakeHit()
    {
        base.TakeHit();

       
        animatorManager.PlayTargetAnimation("2Hand-Sword-Knockback-Back1", true);
        
        

        // What happens when the player takes a hit


    }

    

}
