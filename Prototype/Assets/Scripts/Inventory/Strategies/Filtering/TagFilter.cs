using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Inventory.Strategies.Filtering
{
    [CreateAssetMenu(fileName = "Tag Filter", menuName = "Inventory/Filters/By Tag", order = 0)]
    public class TagFilter : FilteringStrategy
    {
        [SerializeField] private string _tagToFilter = "";
        public override IEnumerable<GameObject> Filter(IEnumerable<GameObject> objectsToFilter)
        {
           foreach(var obj in objectsToFilter)
            {
                if (obj.CompareTag(_tagToFilter))
                {
                    yield return obj;
                }
            }
        }
    }
}
