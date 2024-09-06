using IMPossible.Resources;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace IMPossible.Combat
{
    public class EnemyHealthDisplay : MonoBehaviour
    {
        private Health _health;
        private float _maxHP;
        [SerializeField] private Transform _HpPivot;
        private void Start()
        {
            _health = GetComponentInParent<Health>();
            _maxHP = _health.HP;
        }

        private void Update()
        {
            _HpPivot.localScale = new Vector3(Mathf.Clamp(_health.HP, 0, _maxHP) / _maxHP, _HpPivot.localScale.y, _HpPivot.localScale.z);
            transform.LookAt(Camera.main.transform.position);
        }
    }
}
