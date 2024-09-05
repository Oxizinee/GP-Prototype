using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace IMPossible.Combat
{
    public class Health : MonoBehaviour
    {
        // Start is called before the first frame update
        public float HP = 10;
        public bool IsDead = false;
        public GameObject FloatingText, BloodSplatterPrefab;
        public void TakeDamage(float damage)
        {
            HP = Mathf.Max(HP - damage, 0);
            ShowFloatingText(damage);
            SpawnBloodSplatter();
            Debug.Log("Health " + HP);

            if(HP == 0) 
            {
                Die();
                IsDead = true;
            }
        }

        private void Die()
        {
            if (IsDead) return;
            GetComponent<Animator>().SetTrigger("Die");
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
