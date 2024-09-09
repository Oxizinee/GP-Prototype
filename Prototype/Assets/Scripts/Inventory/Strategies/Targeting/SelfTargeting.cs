using System.Collections.Generic;
using System;
using UnityEngine;
namespace IMPossible.Inventory.Strategies.Targeting
{
    [CreateAssetMenu(fileName = "Self Targeting", menuName = "Inventory/Targeting/Self", order = 0)]
    public class SelfTargeting : TargetingStrategy
    {
        public override void StartTargeting(GameObject user, Action<IEnumerable<GameObject>> callWhenFinished)
        {
            Debug.Log("Self Targeting");
            callWhenFinished(null);
        }
    }
}
