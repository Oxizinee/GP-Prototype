using IMPossible.Combat;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Inventory.Strategies.Effects
{
    [CreateAssetMenu(fileName = "Stun Effect", menuName = "Inventory/Effects/Stun", order = 0)]
    public class Stun : EffectStrategy
    {
        [SerializeField] private float _stunDuration;

        public override void StartEffect(GameObject user, IEnumerable<GameObject> targets, Action callWhenFinished)
        {
            foreach (var target in targets)
            {
               target.GetComponent<Fighter>().GetStunned(_stunDuration);
            }
            callWhenFinished();
        }
       
    }
}
