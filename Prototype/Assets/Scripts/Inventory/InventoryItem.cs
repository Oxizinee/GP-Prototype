using UnityEngine;
using IMPossible.Inventory.Strategies;

namespace IMPossible.Inventory
{
    [CreateAssetMenu(menuName = "Inventory/Item")]
    public class InventoryItem : ScriptableObject
    {
        [SerializeField]private string _displayName = null;
        [SerializeField][TextArea] private string _description = null;

        [SerializeField] private Sprite _icon = null;
        [SerializeField] private Pickup _pickup = null;
        [SerializeField] private float _cooldownTime = 0;

        private ItemAbilityData _data = null;

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
            CooldownStorage cooldownStorage = user.GetComponent<CooldownStorage>();
            if (cooldownStorage.GetTimeRemaining(this) > 0)
            {
                return; //if cooldown is still above 0 return - dont let the player use it
            }

            _data = new ItemAbilityData(user);

            _OnUse_targetingStrategy.StartTargeting(_data,() => 
                {
                TargetAquired(_data, _OnUse_filteringStrategies, _OnUse_effectStrategies);
                });
            cooldownStorage.StartCooldown(this, _cooldownTime);
        }
        public void GetPassiveEffect(GameObject user)
        {
            if(user == null) return;    
            if( _hasPassiveEffect )
            {
                _Passive_targetingStrategy.StartTargeting(_data,() =>
                {
                    TargetAquired(_data, _Passive_filteringStrategies, _Passive_effectStrategies);
                }); 
            }
        }
        public Pickup SpawnPickup(Vector3 position)
        {
            var pickup = Instantiate(_pickup);
            pickup.transform.position = new Vector3(position.x + 1.5f, position.y + 1.5f, position.z);
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
        private void TargetAquired(ItemAbilityData data, FilteringStrategy[] filtering, EffectStrategy[] effects)
        {
            foreach(var filterStrategy in filtering)
            {
                data.SetTargets(filterStrategy.Filter(data.GetTargets()));
            }

            foreach (var effect in effects)
            {
                effect.StartEffect(data, EffectFinished);
            }
        }

        private void EffectFinished()
        {

        }

        public ItemAbilityData GetData()
        {
            if (_data != null)
            {
                return _data;
            }
            return null;
        }
    }
}