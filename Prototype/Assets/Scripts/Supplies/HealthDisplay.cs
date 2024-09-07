using IMPossible.Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IMPossible.Resources
{
    public class HealthDisplay : MonoBehaviour
    {
        private Health _health;
        private GameObject _player;
        private void Start()
        {
            _player = GameObject.FindWithTag("Player");
            _health = _player.GetComponent<Health>();
        }
        void Update()
        {
            GetComponent<Image>().fillAmount = Mathf.Clamp(_health.HP, 0, _player.GetComponent<BaseStats>().GetStat(Stat.Health)) / _player.GetComponent<BaseStats>().GetStat(Stat.Health);
        }
    }
}
