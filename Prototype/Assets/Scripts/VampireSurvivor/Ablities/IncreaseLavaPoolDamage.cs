using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IncreaseLavaPoolDamage : Ability
{
    private LavaPoolBehaviour[] _lavaPools;
    public float NewDamage = 18;
    public override void Active(GameObject parent)
    {

        _lavaPools = FindObjectsByType<LavaPoolBehaviour>(FindObjectsSortMode.None);
        if (_lavaPools != null)
        {
            foreach (var pool in _lavaPools)
            {
                pool.Damage = NewDamage;
            }
        }
    }
}
