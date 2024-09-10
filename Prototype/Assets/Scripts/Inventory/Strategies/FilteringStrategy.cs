using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Inventory.Strategies
{
    public abstract class FilteringStrategy : ScriptableObject
    {
        public abstract IEnumerable<GameObject> Filter(IEnumerable<GameObject> objectsToFilter);
    }
}