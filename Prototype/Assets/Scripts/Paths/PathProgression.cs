using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace IMPossible.Paths
{
    [CreateAssetMenu(menuName = "Paths/New Path Data")]
    public class PathProgression : ScriptableObject
    {
        public string PathName;
        [TextArea] public string PathDescription;
        public Sprite PathIcon;
        [SerializeField] ProgressionStats StatsToLevelUp = null;
        private Dictionary<PathStat, float[]> _lookupTable = null;
        public float GetStat(PathStat stat, int level)
        {
            BuildLookup();

            float[] levels = _lookupTable[stat];

            if (levels.Length < level)
            {
                return 0;
            }
            return levels[level - 1];
        }

        public int GetLevels(PathStat stat)
        {
            BuildLookup();

            float[] levels = _lookupTable[stat];
            return levels.Length;
        }
        private void BuildLookup()
        {
            if (_lookupTable != null) return;

            _lookupTable = new Dictionary<PathStat, float[]>();

            foreach (ProgressionStat progressionStat in StatsToLevelUp.Stats)
            {
                _lookupTable[progressionStat.PathStat] = progressionStat.Levels;
            }
        }

        public Sprite GetIcon()
        {
            return PathIcon;
        }


        [System.Serializable]
        class ProgressionStats
        {
            public ProgressionStat[] Stats;
        }
        [System.Serializable]
        class ProgressionStat
        {
            public PathStat PathStat;
            public float[] Levels;
        }
    }

    public enum PathStat
    { 
        NumberOfSpawners,
        RateOfFire,
        Size,
        Speed
    
    }
}
