using IMPossible.Inventory.Strategies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Inventory
{
    [CreateAssetMenu(menuName = "Inventory/Item")]
    public class InventoryItem : ScriptableObject
    {
        [SerializeField]private string _itemID = null;
        [SerializeField]private string _displayName = null;
        [SerializeField][TextArea] private string _description = null;
        [SerializeField] private Sprite _icon = null;
        [SerializeField] private Pickup _pickup = null;
        [SerializeField] TargetingStrategy _targetingStrategy;
        [SerializeField] FilteringStrategy[] _filteringStrategies;
        [SerializeField] EffectStrategy[] _effectStrategies;
       public void Use(GameObject user)
        {
            Debug.Log("Using action: " + this);
            _targetingStrategy.StartTargeting(user, (IEnumerable<GameObject> targets) => 
                {
                TargetAcquired(user, targets);
                });
        }
        public Pickup SpawnPickup(Vector3 position)
        {
            var pickup = Instantiate(_pickup);
            pickup.transform.position = position;
            pickup.Setup(this);
            return pickup;
        }
        public Sprite GetIcon()
        {
            return _icon;
        }

        public string GetItemID()
        {
            return _itemID;
        }
        public string GetDisplayName()
        {
            return _displayName;
        }
        public string GetDescription()
        {
            return _description;
        }

        private void TargetAcquired(GameObject user, IEnumerable<GameObject> targets)
        {
            Debug.Log("Target Aquired ");

            foreach(var filterStrategy in _filteringStrategies)
            {
                targets = filterStrategy.Filter(targets);
            }

            foreach (var effect in _effectStrategies)
            {
                effect.StartEffect(user, targets, EffectFinished);
            }
        }

        private void EffectFinished()
        {

        }
    }
}