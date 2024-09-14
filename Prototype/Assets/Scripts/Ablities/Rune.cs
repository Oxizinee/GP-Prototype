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
        [Range(1, 6)]
        [SerializeField] private int _startingLevel = 1;
        [SerializeField]private RuneData _runeData = null;
        [SerializeField] private int _currentLevel = 1;
        [SerializeField]private float _timer;
        public void OnAdd()
        {
            _currentLevel = _startingLevel;
            _timer = 0;
        }

        public void UpdateLevel()
        {
            _currentLevel++;
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

        public RuneData GetRuneData()
        {
            return _runeData;
        }
    }
}
