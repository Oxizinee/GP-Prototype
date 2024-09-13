using IMPossible.Combat;
using IMPossible.Controller;
using IMPossible.Movement;
using IMPossible.Supplies;
using System.Collections;
using UnityEngine;

namespace IMPossible.Controller
{
    public class ChargerEnemy : EnemyController
    {
        public float PrepareToChargeDuration = 0.8f, Cooldown = 3, ChargeDuration = 1.5f;
        private bool _canCharge = true, _isCharging = false, _isOnCooldown;

        private Vector3 _targetPosition;
        public override void Move()
        {
            if (!GetComponent<Health>().CanBeAttacked() || GetComponent<Fighter>().IsStunned) return;

            Target = GameObject.FindGameObjectWithTag("Player").transform.position;
            if (IsInRadius && _canCharge)
            {
                StartCoroutine(PrepareToCharge());
            }
            if (_isCharging)
            {
                StartCoroutine(Charge());
            }


            GetComponent<EnemyMover>().Move(Target, Speed);
        }
        private IEnumerator PrepareToCharge()
        {
            GetComponent<Fighter>().GetStunned(PrepareToChargeDuration);

            _targetPosition = Target;

            _canCharge = false;
            _isCharging = true;

            yield break;
        }

        private IEnumerator Charge()
        {
            Target = _targetPosition;
            Speed = 30;
            
            _isCharging = false;

            yield return new WaitForSeconds(ChargeDuration);
            _isOnCooldown = true;

            StartCoroutine(ChargeCooldown());
            yield break;
        }
        private IEnumerator ChargeCooldown()
        {
            Speed = 5;
            Target = GameObject.FindGameObjectWithTag("Player").transform.position;
            yield return new WaitForSeconds(Cooldown);
            _canCharge = true;
            _isOnCooldown = false; 
        }

    }
}
