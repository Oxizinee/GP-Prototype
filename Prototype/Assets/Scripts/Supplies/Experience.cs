
using Unity.VisualScripting;
using UnityEngine;

namespace IMPossible.Resources
{
    public class Experience :MonoBehaviour
    {
        [SerializeField] private float _EXP = 0;
        
        public void GainExperience(float experience)
        {
            _EXP += experience;
        }
    }
}
