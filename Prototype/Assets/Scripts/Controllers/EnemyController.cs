using IMPossible.Combat;
using IMPossible.Inventory;
using IMPossible.Movement;
using IMPossible.Supplies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Controller
{
   public class EnemyController :MonoBehaviour
    {
        public float Speed = 5;

        private GameObject _player;

        private void Update()
        {
            Move();
        }
        private void Start()
        {
        }
        public virtual void Move()
        {
            if (!GetComponent<Health>().CanBeAttacked() || GetComponent<Fighter>().IsStunned) return;

            GetComponent<EnemyMover>().Move(_player, Speed);
        }
        private void Awake()
        {
            GetComponent<Health>().OnDeath.AddListener(Die);
            _player = GameObject.FindGameObjectWithTag("Player");
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