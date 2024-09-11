using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace IMPossible.Stats
{
    public class BaseStats : MonoBehaviour
    {
        [Range(1, 99)]
        [SerializeField] private int _startingLevel = 1;
        [SerializeField] private Progression _progression = null;
        [SerializeField] private GameObject _levelUpParticles = null;

        [SerializeField]private int _currentLevel = 0;
        private Experience _experience;

        public event Action OnLevelUp;
        private void Start()
        {
            _currentLevel = _startingLevel;//CalculateLevel();
            _experience = GetComponent<Experience>(); 

            if(_experience != null)
            {
                _experience.OnExperienceGained += UpdateLevel;
            }
        }
        private void UpdateLevel()
        {
            int newLevel = CalculateLevel();
            if(newLevel > _currentLevel)
            {
                _currentLevel = newLevel;
                Instantiate(_levelUpParticles, transform.position, transform.rotation, transform);
                _experience.ResetPoints();

                OnLevelUp();
            }
        }
        public float GetStat(Stat stat)
        {
            return _progression.GetStat(stat, GetLevel()) + GetAdditiveModifier(stat);
        }

        public int GetLevel()
        {
            if (_currentLevel < 1)
            {
                _currentLevel = CalculateLevel();
            }
            return _currentLevel;
        }
        public int CalculateLevel()
        {
            Experience experience = GetComponent<Experience>();
            if (experience == null) return _startingLevel;

            float currentXP = GetComponent<Experience>().GetPoints();
            int maxLevel = _progression.GetLevels(Stat.Experience);
            for (int levels = 1; levels < maxLevel; levels++)
            {
                float XPToLevelUp = _progression.GetStat(Stat.Experience, levels);
                if(XPToLevelUp > currentXP)
                {
                    return levels;
                }
            }
            return maxLevel + 1;
        }

        private float GetAdditiveModifier(Stat stat)
        {
            float total = 0;
            foreach(IModifierProvider provider in GetComponents<IModifierProvider>()) 
            {
                foreach(float modifiers in provider.GetAdditiveModifier(stat))
                {
                    total += modifiers;
                }
            }
            return total;
        }
    }

}
