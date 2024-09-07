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

        public float GetStat(Stat stat, SinPath sinPath, int level)
        {
            foreach (ProgressionSinPath progressionPath in SinPaths)
            {
                if (progressionPath.SinPath != sinPath) continue;
                {
                    foreach (ProgressionStat progressionStat in progressionPath.ProgressionStats)
                    {
                        if(progressionStat.Stat != stat) continue;
                        if (progressionStat.Levels.Length < level) continue;
                        return progressionStat.Levels[level - 1];
                    }
                }
            }
            return 0;
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
