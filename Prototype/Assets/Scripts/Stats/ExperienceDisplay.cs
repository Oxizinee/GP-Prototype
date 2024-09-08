using IMPossible.Stats;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace IMPossible.Stats
{
    public class ExperienceDisplay : MonoBehaviour
    {
        private Experience _experience;
        private float _maxEXP;
        private GameObject _player;
        private void Start()
        {
            _player = GameObject.FindWithTag("Player");
            _experience = _player.GetComponent<Experience>();
            _maxEXP = _player.GetComponent<BaseStats>().GetStat(Stat.Experience);
            _player.GetComponent<BaseStats>().OnLevelUp += OnLevelUp;
        }
        private void OnLevelUp()
        {
            _maxEXP = _player.GetComponent<BaseStats>().GetStat(Stat.Experience);
        }

        void Update()
        {
            GetComponent<Image>().fillAmount = Mathf.Clamp(_experience.GetPoints(), 0, _maxEXP) / _maxEXP;
        }
    }
}
