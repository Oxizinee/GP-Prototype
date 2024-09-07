using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Stats
{
    public class BaseStats : MonoBehaviour
    {
        [Range(1, 99)]
        [SerializeField] private int _startingLevel = 1;
        [SerializeField] private SinPath _sinPath = SinPath.Sinless;
        [SerializeField] private Progression _progression = null;
        public float GetStat(Stat stat)
        {
            return _progression.GetStat(stat, _sinPath, _startingLevel);
        }
    }

}
