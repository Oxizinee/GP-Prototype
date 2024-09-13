using IMPossible.Combat;
using System.Collections;
using UnityEngine;

namespace IMPossible.Controller
{
    public class ThrowerEnemy : EnemyController
    {
        public GameObject BulletPrefab;
        [SerializeField] private float _damage = 2, _bulletSpeed = 10;
        public override void SpecialAttack()
        {
                if (IsInRadius && GetComponent<Fighter>().CanShoot)
                {
                    GetComponent<Fighter>().Shoot(BulletPrefab, false, _damage, _bulletSpeed, 6, 0.5f, 3, 0.8f);
                }
        }

    }
}
