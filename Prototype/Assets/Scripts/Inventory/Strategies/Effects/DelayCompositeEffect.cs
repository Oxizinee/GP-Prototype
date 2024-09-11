using System;
using System.Collections;
using UnityEngine;

namespace IMPossible.Inventory.Strategies.Effects
{
    [CreateAssetMenu(fileName = "Delay Composite Effect",menuName = "Inventory/Effects/Delay Effects", order = 0)]
    public class DelayCompositeEffect : EffectStrategy
    {
        [SerializeField] float _delay = 0;
        [SerializeField] EffectStrategy[] _delayEffects;
        public override void StartEffect(AbilityData data, Action callWhenFinished)
        {
            data.GetUser().GetComponent<MonoBehaviour>().StartCoroutine(DelayedEffect(data, callWhenFinished));
        }

        private IEnumerator DelayedEffect(AbilityData data, Action callWhenFinished)
        {
            yield return new WaitForSeconds(_delay);
            foreach(var effect in _delayEffects)
            {
                effect.StartEffect(data, callWhenFinished);
            }
        }
    }
}
