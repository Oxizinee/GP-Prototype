using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Stats
{
    public class BaseStats : MonoBehaviour
    {
        [Range(1, 99)]
        [SerializeField] private int _startingLevel = 1;
        [SerializeField] private int _experienceToGive = 10;

        public float RewardExperience()
        {
            return _experienceToGive;
        }
    }
}
