
using Unity.VisualScripting;
using UnityEngine;

namespace IMPossible.Resources
{
    public class Experience :MonoBehaviour
    {
        public float EXP = 0;
        
        public void GainExperience(float experience)
        {
            EXP += experience;
        }
    }
}
