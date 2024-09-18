using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Ability
{
    [CreateAssetMenu(menuName = "Runes/New Rune")]
    public class RuneData : ScriptableObject
    {
        public string RuneName;
        [TextArea]public string RuneDescription;
        public Sprite RuneIcon;
        [SerializeField] ProgressionStats StatsToLevelUp = null;
        private Dictionary<RuneStat, float[]> _lookupTable = null;
        public float GetStat(RuneStat stat, int level)
        {
            BuildLookup();

            float[] levels = _lookupTable[stat];

            if (levels.Length < level)
            {
                return 0;
            }
            return levels[level - 1];
        }

        public int GetLevels(RuneStat stat)
        {
            BuildLookup();

            float[] levels = _lookupTable[stat];
            return levels.Length;
        }
        private void BuildLookup()
        {
            if (_lookupTable != null) return;

            _lookupTable = new Dictionary<RuneStat, float[]>();

            foreach (ProgressionStat progressionStat in StatsToLevelUp.Stats)
            {
                _lookupTable[progressionStat.RuneStat] = progressionStat.Levels;
            }
        }

        public Sprite GetIcon()
        {
            return RuneIcon;
        }


        [System.Serializable]
        class ProgressionStats
        {
            public ProgressionStat[] Stats;
        }
        [System.Serializable]
        class ProgressionStat
        {
            public RuneStat RuneStat;
            public float[] Levels;
        }
    }
}  

   
