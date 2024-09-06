using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMPossible.Controller;

[CreateAssetMenu(menuName = "Abilities/Increase Bullet Speed")]
public class IncreaseBulletSpeed : Ability
{
    public float NewSpeed = 12;

    public override void Active(GameObject parent)
    {
        parent.GetComponent<Player>().BulletSpeed = NewSpeed;   
    }
}
