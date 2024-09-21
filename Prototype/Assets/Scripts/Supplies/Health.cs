using IMPossible.Stats;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace IMPossible.Supplies
{
    public class Health : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private float _regenerationPercentage = 70;

        public float HP = 10;
        public bool ShouldUseModifier = false;
        public GameObject BloodSplatterPrefab;
        private float _invincibleTimer, _invincibleDuration;

        private bool _isInvincible;

        public event Action<float> OnDamageTaken;
        public UnityEvent OnDeath;
        private void Start()
        {
            GetComponent<BaseStats>().OnLevelUp += RegenerateHealth;
            HP = GetComponent<BaseStats>().GetStat(Stat.Health);
        }

        private void RegenerateHealth()
        {
            float regenHealthPoints = GetComponent<BaseStats>().GetStat(Stat.Health) * (_regenerationPercentage / 100);
            HP = Mathf.Max(HP, regenHealthPoints);
        }
        public bool IsDead()
        {
            return HP <= 0;
        }
        public void TakeDamage(GameObject instigator, float damage)
        {
            if (!CanBeAttacked() || _isInvincible) return;

            float newDamage = damage + ModifiedDamage(damage);
            HP = Mathf.Max(HP - newDamage, 0);
            OnDamageTaken?.Invoke(newDamage);
            SpawnBloodSplatter();

            if(IsDead()) 
            {
                OnDeath?.Invoke();
                AwardExperience(instigator);
            }
        }

        public void BecomeInvincible(float duration)
        {
            _isInvincible = true;
            _invincibleDuration = duration;
        }
        private void Update()
        {
            if (_isInvincible)
            {
                _invincibleTimer += Time.deltaTime;
                if (_invincibleTimer >= _invincibleDuration)
                {
                    _isInvincible = false;
                    _invincibleTimer = 0;
                }
            }
        }
        private float ModifiedDamage(float damage)
        {
            if (!ShouldUseModifier) return 0;

            return damage;
        }
        public bool CanBeAttacked()
        {
            return !IsDead();
        }
       
        public void Heal(float healPoints)
        {
            HP = Mathf.Min(HP + healPoints, GetMaxHealth());
        }

        public float GetMaxHealth()
        {
            return GetComponent<BaseStats>().GetStat(Stat.Health);
        }

        private void AwardExperience(GameObject instigator)
        {
            Experience experience = instigator.GetComponent<Experience>();
            if(experience == null) { return; }

            experience.GainExperience(GetComponent<BaseStats>().GetStat(Stat.Experience));
        }

        private void SpawnBloodSplatter()
        {
            Vector3 oppositeDirection = -transform.forward;
            Quaternion oppositeRotation = Quaternion.LookRotation(oppositeDirection);
            Instantiate(BloodSplatterPrefab, new Vector3(transform.position.x, transform.localScale.y ,transform.position.z), oppositeRotation);
        }

       
    }
}
