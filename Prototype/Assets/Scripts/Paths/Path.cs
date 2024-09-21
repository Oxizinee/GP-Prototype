using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Paths
{
    public abstract class Path : MonoBehaviour
    {
        [SerializeField] private PathProgression _pathProgression;
        private int _currentLevel = 0;
        public int GetCurrentLevel()
        {
            return _currentLevel;
        }
        public virtual void OnStart()
        {
            _currentLevel = 0;
            _currentLevel++;
        }
        public float GetStat(PathStat stat)
        {
            return _pathProgression.GetStat(stat, _currentLevel);
        }
        public virtual void BasicAttack(GameObject user) { }
        public virtual void Passive(GameObject user) { }
        public virtual void SpecialAttack(GameObject parent) { }
        public virtual void Dash(GameObject parent) { }
        public virtual void UpdateLevel(GameObject user) { }

    }
}