using IMPossible.Combat;
using System;
using UnityEngine;

namespace IMPossible.Inventory.Strategies.Effects
{
    [CreateAssetMenu(fileName = "Stun Effect", menuName = "Inventory/Effects/Stun", order = 0)]
    public class StunEffect : EffectStrategy
    {
        [SerializeField] private float _stunDuration;

        public override void StartEffect(ItemAbilityData data, Action callWhenFinished)
        {
            foreach (var target in data.GetTargets())
            {
               target.GetComponent<Fighter>().GetStunned(_stunDuration);
            }
            callWhenFinished();
        }
       
    }
}
