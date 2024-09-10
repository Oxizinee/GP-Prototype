using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Inventory.Strategies
{
    public abstract class EffectStrategy : ScriptableObject
    {
        public abstract void StartEffect(GameObject user, IEnumerable<GameObject> targets, Action callWhenFinished);
    }
}