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
        [SerializeField] private SinPath _sinPath = SinPath.Sinless;
        [SerializeField] private Progression _progression = null;
        [SerializeField] private GameObject _levelUpParticles = null;

        [SerializeField]private int _currentLevel = 0;
        private void Start()
        {
            _currentLevel = CalculateLevel();
            Experience experience = GetComponent<Experience>(); 
            if(experience != null)
            {
                experience.OnExperienceGained += UpdateLevel;
            }
        }
        private void UpdateLevel()
        {
            int newLevel = CalculateLevel();
            if(newLevel > _currentLevel)
            {
                _currentLevel = newLevel;
                Instantiate(_levelUpParticles, transform.position, transform.rotation, transform);
            }
        }
        public float GetStat(Stat stat)
        {
            return _progression.GetStat(stat, _sinPath, GetLevel());
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
            int maxLevel = _progression.GetLevels(Stat.Experience, _sinPath);
            for (int levels = 1; levels < maxLevel; levels++)
            {
                float XPToLevelUp = _progression.GetStat(Stat.Experience, _sinPath, levels);
                if(XPToLevelUp > currentXP)
                {
                    return levels;
                }
            }
            return maxLevel + 1;
        }
    }

}
