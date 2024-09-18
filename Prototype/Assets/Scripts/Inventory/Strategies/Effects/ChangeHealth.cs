using IMPossible.Supplies;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Inventory.Strategies.Effects
{
    [CreateAssetMenu(fileName ="Change Health Effect", menuName ="Inventory/Effects/Health", order = 0)]
    public class ChangeHealth : EffectStrategy
    {
        [SerializeField] private float _damageAmount;
        private float _healAmount;

        public override void StartEffect(ItemAbilityData data, Action callWhenFinished)
        {
            _healAmount = HalfHP(data.GetUser().GetComponent<Health>().GetMaxHealth());
            foreach (var target in data.GetTargets())
            {
                if (_damageAmount < 0)
                {
                    target.GetComponent<Health>().TakeDamage(data.GetUser(), -_damageAmount);
                }
                else
                {
                    target.GetComponent<Health>().Heal(_healAmount);
                }
            }
            callWhenFinished();
        }

        public float HalfHP(float number)
        {
            return number / 2;
        }
    }
}
