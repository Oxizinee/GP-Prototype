using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace IMPossible.Ability
{
    public abstract class Rune :MonoBehaviour
    {
        [SerializeField]private RuneData _runeData = null;
        [SerializeField] private int _currentLevel = 0;
        [SerializeField]private float _timer;
        public void OnAdd()
        {
            _currentLevel = 0;
            _currentLevel++;
            _timer = 0;
        }

        public void UpdateLevel()
        {
            if(_currentLevel < 6 )
            {
                _currentLevel++;
            }
        }

        public float GetStat(RuneStat stat)
        {
            return _runeData.GetStat(stat, _currentLevel);
        }
       
        public void Use(GameObject user)
        {
            _timer += Time.deltaTime;

            if (_timer > GetStat(RuneStat.Cooldown))
            {
                Behaviour(user);
                _timer = 0;
            }
        }

        public virtual void Behaviour(GameObject user)
        {

        }

        public int GetCurrentLevel()
        {
            return _currentLevel;
        }

        public RuneData GetRuneData()
        {
            return _runeData;
        }

        public string GetRuneName()
        {
            return _runeData.RuneName + " " + GetNextLevel();
        }

        public int GetNextLevel()
        {
            if (_currentLevel == 6)
            {
                return _currentLevel;
            }

            return _currentLevel + 1;
        }
    }
}
