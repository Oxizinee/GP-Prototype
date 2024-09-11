
using System;
using Unity.VisualScripting;
using UnityEngine;

namespace IMPossible.Stats
{
    public class Experience :MonoBehaviour
    {
        private float _EXP = 0;

        public event Action OnExperienceGained;
        
        public void GainExperience(float experience)
        {
            _EXP += experience;
            OnExperienceGained();
            return;
        }

        public float GetPoints()
        {
            return _EXP;
        }

        public float ResetPoints()
        {
            return _EXP = 0;
        }
    }
}
