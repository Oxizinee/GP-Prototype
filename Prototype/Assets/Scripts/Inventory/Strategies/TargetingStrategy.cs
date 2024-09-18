using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Inventory.Strategies
{
    public abstract class TargetingStrategy : ScriptableObject
    {
        public abstract void StartTargeting(ItemAbilityData data, Action callWhenFinished);
    }
}
