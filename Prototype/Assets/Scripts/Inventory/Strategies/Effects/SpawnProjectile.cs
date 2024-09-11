using IMPossible.Combat;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Inventory.Strategies.Effects
{
    [CreateAssetMenu(fileName = "Spawn Projectile Effect", menuName = "Inventory/Effects/Spawn Projectile", order = 0)]
    public class SpawnProjectileEffect : EffectStrategy
    {
        [SerializeField] private GameObject _bulletToSpawn;
        public override void StartEffect(AbilityData data, Action callWhenFinished)
        {
            GameObject instance = Instantiate(_bulletToSpawn, data.GetTargetedPoint(), data.GetUser().transform.rotation);
            callWhenFinished();
        }

    }
}
