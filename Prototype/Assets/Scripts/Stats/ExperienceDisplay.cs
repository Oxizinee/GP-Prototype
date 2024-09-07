using IMPossible.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace IMPossible.Stats
{
    public class ExperienceDisplay : MonoBehaviour
    {
        private Experience _experience;
        private GameObject _player;
        private void Start()
        {
            _player = GameObject.FindWithTag("Player");
            _experience = _player.GetComponent<Experience>();
        }
        void Update()
        {
            GetComponent<Image>().fillAmount = Mathf.Clamp(_experience.EXP, 0, _player.GetComponent<BaseStats>().GetStat(Stat.Experience)) / _player.GetComponent<BaseStats>().GetStat(Stat.Experience);
        }
    }
}
