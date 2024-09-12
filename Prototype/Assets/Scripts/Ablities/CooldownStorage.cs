using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Ability
{
    public class CooldownStorage : MonoBehaviour
    {
        Dictionary<AbilityData, float> cooldownTimers = new Dictionary<AbilityData, float>();
        Dictionary<AbilityData, float> initialCooldownTimes = new Dictionary<AbilityData, float>();

        void Update()
        {
            var keys = new List<AbilityData>(cooldownTimers.Keys);
            foreach (AbilityData ability in keys)
            {
                cooldownTimers[ability] -= Time.deltaTime;
                if (cooldownTimers[ability] < 0)
                {
                    cooldownTimers.Remove(ability);
                   initialCooldownTimes.Remove(ability);
                }
            }
        }

        public void StartCooldown(AbilityData ability, float cooldownTime)
        {
            cooldownTimers[ability] = cooldownTime;
            initialCooldownTimes[ability] = cooldownTime;
        }

        public float GetTimeRemaining(AbilityData ability)
        {
            if (!cooldownTimers.ContainsKey(ability))
            {
                return 0;
            }

            return cooldownTimers[ability];
        }

        public float GetFractionRemaining(AbilityData ability)
        {
            if (ability == null)
            {
                return 0;
            }

            if (!cooldownTimers.ContainsKey(ability))
            {
                return 0;
            }

            return cooldownTimers[ability] / initialCooldownTimes[ability];
        }
    }
}