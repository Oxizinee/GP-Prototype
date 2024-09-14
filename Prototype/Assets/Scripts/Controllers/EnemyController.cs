using IMPossible.Combat;
using IMPossible.Inventory;
using IMPossible.Movement;
using IMPossible.Supplies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Controller
{
    public class EnemyController : MonoBehaviour
    {
        public float Speed = 5, InRadius = 10;

        public Vector3 Target { get; set; }
        public bool IsInRadius
        {
            get 
            {
                return Vector3.Distance(Target, transform.position) <= InRadius;
            }
        }
        private void Awake()
        {
            GetComponent<Health>().OnDeath.AddListener(Die);
            OnStart();
        }

        public virtual void OnStart()
        {

        }
        private void Update()
        {
            Move();
            SpecialAttack();
        }
        public virtual void SpecialAttack()
        {

        }
        public virtual void Move()
        {
            if (!GetComponent<Health>().CanBeAttacked() || GetComponent<Fighter>().IsStunned) return;

            Target = GameObject.FindGameObjectWithTag("Player").transform.position;

            GetComponent<EnemyMover>().Move(Target, Speed);
        }
        protected void Die()
        {
            GetComponent<Animator>().SetTrigger("Die");
            DropLoot();
            Destroy(gameObject, 4);
        }
        protected void DropLoot()
        {
            if (GetComponent<PickupSpawner>() != null)
            {
                GetComponent<PickupSpawner>().DropLoot();
            }
        }
    }
}