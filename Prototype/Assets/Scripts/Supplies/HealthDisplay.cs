using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IMPossible.Resources
{
    public class HealthDisplay : MonoBehaviour
    {
        private Health _health;
        private float _maxHealth;
        private void Start()
        {
            _health = GameObject.FindWithTag("Player").GetComponent<Health>();
            _maxHealth = _health.HP;
        }
        void Update()
        {
            GetComponent<Image>().fillAmount = Mathf.Clamp(_health.HP, 0, _maxHealth) / _maxHealth;
        }
    }
}
