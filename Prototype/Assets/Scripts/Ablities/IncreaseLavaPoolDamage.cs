using IMPossible.Combat.Missle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Increase Lava Pool Damage")]
public class IncreaseLavaPoolDamage : Ability
{
    private LavaPool[] _lavaPools;
    public float NewDamage = 18;
    public override void Active(GameObject parent)
    {

        _lavaPools = FindObjectsByType<LavaPool>(FindObjectsSortMode.None);
        if (_lavaPools != null)
        {
            foreach (var pool in _lavaPools)
            {
                pool.Damage = NewDamage;
            }
        }
    }
}
