using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PiercingBulletAbility : Ability
{
    public override void Active(GameObject parent)
    {
        parent.GetComponent<Player>().CanPierceActive = true;
    }
}
