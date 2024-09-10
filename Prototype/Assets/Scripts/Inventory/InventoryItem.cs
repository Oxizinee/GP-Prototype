using IMPossible.Inventory.Strategies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Inventory
{
    [CreateAssetMenu(menuName = "Inventory/Item")]
    public class InventoryItem : ScriptableObject
    {
        [SerializeField]private string _displayName = null;
        [SerializeField][TextArea] private string _description = null;

        [SerializeField] private Sprite _icon = null;
        [SerializeField] private Pickup _pickup = null;

        [Header("On use strategies")]
        [SerializeField] TargetingStrategy _OnUse_targetingStrategy;
        [SerializeField] FilteringStrategy[] _OnUse_filteringStrategies;
        [SerializeField] EffectStrategy[] _OnUse_effectStrategies;

        [Header("Passive strategies")]
        [SerializeField] private bool _hasPassiveEffect;

        [SerializeField] TargetingStrategy _Passive_targetingStrategy;
        [SerializeField] FilteringStrategy[] _Passive_filteringStrategies;
        [SerializeField] EffectStrategy[] _Passive_effectStrategies;
        public void Use(GameObject user)
        {
            Debug.Log("Using action: " + this);
            _OnUse_targetingStrategy.StartTargeting(user, (IEnumerable<GameObject> targets) => 
                {
                OnUseTargetAcquired(user, targets);
                });
        }
        public void GetPassiveEffect(GameObject user)
        {
            if( _hasPassiveEffect )
            {
                _Passive_targetingStrategy.StartTargeting(user, (IEnumerable<GameObject> targets) =>
                {
                    PassiveTargetAcquired(user, targets);
                }); 
            }
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
        public string GetDisplayName()
        {
            return _displayName;
        }
        public string GetDescription()
        {
            return _description;
        }
        private void PassiveTargetAcquired(GameObject user, IEnumerable<GameObject> targets)
        {
            foreach (var filterStrategy in _Passive_filteringStrategies)
            {
                targets = filterStrategy.Filter(targets);
            }

            foreach (var effect in _Passive_effectStrategies)
            {
                effect.StartEffect(user, targets, EffectFinished);
            }
        }
        private void OnUseTargetAcquired(GameObject user, IEnumerable<GameObject> targets)
        {
            Debug.Log("Target Aquired ");

            foreach(var filterStrategy in _OnUse_filteringStrategies)
            {
                targets = filterStrategy.Filter(targets);
            }

            foreach (var effect in _OnUse_effectStrategies)
            {
                effect.StartEffect(user, targets, EffectFinished);
            }
        }

        private void EffectFinished()
        {

        }
    }
}