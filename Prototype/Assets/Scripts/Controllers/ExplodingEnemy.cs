using IMPossible.Supplies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Controller
{
    public class ExplodingEnemy : EnemyController
    {
        public GameObject ExplosionPrefab;
        public float ExplosionRadius = 4;
        public float Damage = 10;

        private GameObject _explosionGO;
        public override void SpecialAttack()
        {
            if (IsInRadius)
            {
                Explode();
            }
        }

        private void Explode()
        {
            RaycastHit[] hits = Physics.SphereCastAll(transform.position, ExplosionRadius, Vector3.up, 0);
            if (_explosionGO = null)
            {
                _explosionGO = Instantiate(ExplosionPrefab, transform.position, transform.rotation);
            }
            foreach (RaycastHit hit in hits)
            {
                if(hit.collider.GetComponent<Health>() != null)
                {
                    hit.collider.GetComponent<Health>().TakeDamage(gameObject, Damage);
                }
            }
            Destroy(gameObject, 0.2f);
        }
    }
}