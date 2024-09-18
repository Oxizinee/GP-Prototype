using System;
using System.Collections;
using UnityEngine;

namespace IMPossible.Inventory.Strategies.Effects
{
    [CreateAssetMenu(fileName = "Spawn Effect", menuName = "Inventory/Effects/Spawn Effect", order = 0)]
    public class SpawnEffect : EffectStrategy
    {
        [SerializeField] private GameObject _prefabToSpawn;
        [SerializeField] private float _destroyDelay = -1;
        public override void StartEffect(ItemAbilityData data, Action callWhenFinished)
        {
            data.GetUser().GetComponent<MonoBehaviour>().StartCoroutine(Effect(data, callWhenFinished));
        }

        private IEnumerator Effect(ItemAbilityData data, Action finished)
        {
            GameObject instance = Instantiate(_prefabToSpawn, data.GetTargetedPoint(), Quaternion.identity);
            if (_destroyDelay > 0)
            {
                yield return new WaitForSeconds(_destroyDelay);
                Destroy(instance.gameObject);
            }
            finished();
        }
    }
}
