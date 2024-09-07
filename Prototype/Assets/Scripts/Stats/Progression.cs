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
        [SerializeField] ProgressionCharacterClass[] CharacterClasses = null;

        [System.Serializable]
        class ProgressionCharacterClass
        {
            public ProgressionStats[] ProgressionStats;
        }

        [System.Serializable]
        class ProgressionStats
        {
            public Stats Stat;
            public float[] Levels;
        }
    }
}
