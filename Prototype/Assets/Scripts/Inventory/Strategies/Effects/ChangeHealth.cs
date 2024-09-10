﻿using IMPossible.Supplies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace IMPossible.Inventory.Strategies.Effects
{
    [CreateAssetMenu(fileName ="Change Health Effect", menuName ="Inventory/Effects/Health", order = 0)]
    public class ChangeHealth : EffectStrategy
    {
        [Tooltip("Only fill this field if you want this effect to do damage")]
        [SerializeField] private float _damageAmount;
        private float _healAmount;

        public override void StartEffect(GameObject user, IEnumerable<GameObject> targets, Action callWhenFinished)
        {
            _healAmount = HalfHP(user.GetComponent<Health>().GetMaxHealth());
            foreach (var target in targets)
            {
                if (_damageAmount < 0)
                {
                    target.GetComponent<Health>().TakeDamage(user, -_damageAmount);
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
