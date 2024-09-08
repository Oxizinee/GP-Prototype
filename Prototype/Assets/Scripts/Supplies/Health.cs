using IMPossible.Inventory;
using IMPossible.Stats;
using System;
using TMPro;
using UnityEngine;

namespace IMPossible.Resources
{
    public class Health : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private float _regenerationPercentage = 70;

        public float HP = 10;
        private bool IsDead = false;
        public GameObject FloatingText, BloodSplatterPrefab;
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

        public void TakeDamage(GameObject instigator, float damage)
        {
            HP = Mathf.Max(HP - damage, 0);
            ShowFloatingText(damage);
            SpawnBloodSplatter();

            if(HP == 0) 
            {
                Die();
                AwardExperience(instigator);
            }
        }
        public bool CanBeAttacked()
        {
            return !IsDead;
        }
        private void Die()
        {
            if (IsDead) return;
            GetComponent<Animator>().SetTrigger("Die");
            DropLoot();
            Destroy(gameObject, 4);
            IsDead = true;
        }

        private void DropLoot()
        {
            if (GetComponent<PickupSpawner>() != null)
            {
                GetComponent<PickupSpawner>().DropLoot();
            }
        }

        private void AwardExperience(GameObject instigator)
        {
            Experience experience = instigator.GetComponent<Experience>();
            if(experience == null) { return; }

            experience.GainExperience(GetComponent<BaseStats>().GetStat(Stat.Experience));
        }

        private void ShowFloatingText(float DamageValue)
        {
            GameObject text = Instantiate(FloatingText, transform.position, Quaternion.identity, transform);
            text.GetComponent<TextMeshPro>().text = DamageValue.ToString();
        }
        private void SpawnBloodSplatter()
        {
            Vector3 oppositeDirection = -transform.forward;
            Quaternion oppositeRotation = Quaternion.LookRotation(oppositeDirection);
            Instantiate(BloodSplatterPrefab, new Vector3(transform.position.x, transform.localScale.y ,transform.position.z), oppositeRotation);
        }
    }
}
