using IMPossible.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace IMPossible.Resources
{
    public class ExperienceDisplay : MonoBehaviour
    {
        private Experience _experience;
        private float _maxExperience;
        private void Start()
        {
            _experience = GameObject.FindWithTag("Player").GetComponent<Experience>();
            _maxExperience = GameObject.FindWithTag("Player").GetComponent<BaseStats>().GetStat(Stat.Experience);
        }
        void Update()
        {
            GetComponent<Image>().fillAmount = Mathf.Clamp(_experience.EXP, 0, _maxExperience) / _maxExperience;
        }
    }
}
