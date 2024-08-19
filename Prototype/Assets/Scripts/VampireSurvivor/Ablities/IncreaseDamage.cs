using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class IncreaseDamage : Ability
{
    [SerializeField]private float _currentDamage;
   
    public override void Active(GameObject parent)
    {
        parent.GetComponent<Player>().PassiveDamage = _currentDamage + 10;
    }
}
