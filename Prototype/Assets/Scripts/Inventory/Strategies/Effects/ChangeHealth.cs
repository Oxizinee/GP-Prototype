using IMPossible.Supplies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace IMPossible.Inventory.Strategies.Effects
{
    [CreateAssetMenu(fileName ="Change Health Effect", menuName ="Inventory/Effects/Health", order = 0)]
    public class ChangeHealth : EffectStrategy
    {
        [SerializeField] bool _isHealing;
        [SerializeField] private float _damageAmount;
        private float _healAmount;

        public override void StartEffect(GameObject user, IEnumerable<GameObject> targets, Action callWhenFinished)
        {
            foreach (var target in targets)
            {
                float healHalfHP = GetHalfOfMaxHHp(target);
                if (!_isHealing)
                {
                    target.GetComponent<Health>().TakeDamage(user, _damageAmount);
                }
                else
                {
                    target.GetComponent<Health>().Heal(healHalfHP);
                }
            }
            callWhenFinished();
        }

        private float GetHalfOfMaxHHp(GameObject target)
        {
            float maxHP = target.GetComponent<Health>().GetMaxHealth();
            return maxHP / 2;
        }
    }
}
