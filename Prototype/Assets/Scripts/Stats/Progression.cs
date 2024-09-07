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
        [SerializeField] ProgressionSinPath[] SinPaths = null;
            Dictionary<SinPath, Dictionary<Stat, float[]>> _lookupTable = null;
        public float GetStat(Stat stat, SinPath sinPath, int level)
        {
            BuildLookup();

            float[] levels = _lookupTable[sinPath][stat];
            
            if (levels.Length < level)
            {
                return 0;
            }
            return levels[level - 1];
        }

        public int GetLevels(Stat stat, SinPath sinPath)
        {
            BuildLookup();

            float[] levels = _lookupTable[sinPath][stat];
            return levels.Length;
        }
        private void BuildLookup()
        {
            if(_lookupTable != null) return; 

            _lookupTable = new Dictionary<SinPath, Dictionary<Stat, float[]>>();

            foreach(ProgressionSinPath progressionSinPath in SinPaths)
            {
                var statLookupTable = new Dictionary<Stat,float[]>();

                foreach (ProgressionStat progressionStat in progressionSinPath.ProgressionStats)
                {
                    statLookupTable[progressionStat.Stat] = progressionStat.Levels;
                }

                _lookupTable[progressionSinPath.SinPath] = statLookupTable;
            }
        }

        [System.Serializable]
        class ProgressionSinPath
        {
            public SinPath SinPath;
            public ProgressionStat[] ProgressionStats;
        }

        [System.Serializable]
        class ProgressionStat
        {
            public Stat Stat;
            public float[] Levels;
        }
    }
}
