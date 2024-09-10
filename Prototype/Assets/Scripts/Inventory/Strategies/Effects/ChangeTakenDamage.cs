using System;
using System.Collections.Generic;
using UnityEngine;
using IMPossible.Supplies;

namespace IMPossible.Inventory.Strategies.Effects
{
    [CreateAssetMenu(fileName = "Change Taken Damage", menuName = "Inventory/Effects/Change Damage", order = 0)]
    public class ChangeTakenDamage : EffectStrategy
    {
        [SerializeField] private float _newMultiplication;
        public override void StartEffect(GameObject user, IEnumerable<GameObject> targets, Action callWhenFinished)
        {
            user.GetComponent<Health>().ChangeMulltiplication(_newMultiplication);
        }
    }
}
