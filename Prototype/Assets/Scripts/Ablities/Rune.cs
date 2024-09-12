using IMPossible.Ability.Strategies;
using UnityEngine;

namespace IMPossible.Ability
{
    [CreateAssetMenu(menuName = "Runes/Rune")]
    public class Rune : ScriptableObject
    {
        [SerializeField] private string _displayName = null;
        [SerializeField][TextArea] private string _description = null;

        [SerializeField] private Sprite _icon = null;
        [SerializeField] private float _cooldownTime = 0;
        [SerializeField] private int _level = 1;

        private AbilityData _data = null;

        [SerializeField] TargetingStrategy _targetingStrategy;
        [SerializeField] FilteringStrategy[] _filteringStrategies;
        [SerializeField] EffectStrategy[] _effectStrategies;

        public void GetPassiveEffect(GameObject user)
        {
            if (user == null) return;

            if (_data == null)
            {
                _data = new AbilityData(user);
            }
            CooldownStorage cooldownStorage = user.GetComponent<CooldownStorage>();
            if (cooldownStorage.GetTimeRemaining(_data) > 0)
            {
                return; //if cooldown is still above 0 return - dont let the player use it
            }

            _targetingStrategy.StartTargeting(_data, () =>
                {
                    TargetAquired(_data, _filteringStrategies, _effectStrategies);
                });

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
        private void TargetAquired(AbilityData data, FilteringStrategy[] filtering, EffectStrategy[] effects)
        {
            CooldownStorage cooldownStorage = data.GetUser().GetComponent<CooldownStorage>();
            cooldownStorage.StartCooldown(_data, _cooldownTime);

            foreach (var filterStrategy in filtering)
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

        public AbilityData GetData()
        {
            return _data;
        }
    }
}
