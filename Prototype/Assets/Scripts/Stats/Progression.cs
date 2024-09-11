using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace IMPossible.Stats
{
    [CreateAssetMenu(fileName ="Progression", menuName ="Stats/New Progression", order = 0)]
    public class Progression :ScriptableObject
    {
        [SerializeField] ProgressionStats StatsToLevelUp = null;
        private Dictionary<Stat, float[]> _lookupTable = null;
        public float GetStat(Stat stat, int level)
        {
            BuildLookup();

            float[] levels = _lookupTable[stat];
            
            if (levels.Length < level)
            {
                return 0;
            }
            return levels[level - 1];
        }

        public int GetLevels(Stat stat)
        {
            BuildLookup();

            float[] levels = _lookupTable[stat];
            return levels.Length;
        }
        private void BuildLookup()
        {
            if (_lookupTable != null) return;

            _lookupTable = new Dictionary<Stat, float[]>();

                foreach (ProgressionStat progressionStat in StatsToLevelUp.Stats)
                {
                    _lookupTable[progressionStat.Stat] = progressionStat.Levels;
                }
        }

        [System.Serializable]
        class ProgressionStats
        {
            public ProgressionStat[] Stats;
        }

        [System.Serializable]
        class ProgressionStat
        {
            public Stat Stat;
            public float[] Levels;
        }
    }
}
