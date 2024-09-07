
using System;
using Unity.VisualScripting;
using UnityEngine;

namespace IMPossible.Stats
{
    public class Experience :MonoBehaviour
    {
        public float EXP = 0;

        public event Action OnExperienceGained;
        
        public void GainExperience(float experience)
        {
            EXP += experience;
            OnExperienceGained();
        }

        public float GetPoints()
        {
            return EXP;
        }
    }
}
