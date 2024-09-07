using UnityEngine;
using IMPossible.Movement;
using IMPossible.Combat;
using IMPossible.Resources;

namespace IMPossible.Controller
{
    public class Player : MonoBehaviour
    {
        // Start is called before the first frame update
        public float MovementSpeed = 8, JumpHeight = 8,DashDistance = 10, PassiveDamage = 10, EnemyDamage = 1, BulletSpeed = 12, BulletDamage = 6, TimeBetweenBullets = 1,
            BulletLifeSpan = 9, BulletStunDuration = 0.8f;
        public GameObject BulletPrefab, BombPrefab, FieldOfView;
        public bool HornsActive, CanPierceActive = false, CanShoot = true;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Enemy" && !collision.gameObject.GetComponent<Fighter>().IsStunned)
            {
                GetComponent<Health>().TakeDamage(collision.gameObject, 2);
                //if (HornsActive)
                //{
                //    collision.gameObject.GetComponent<HPBarBehaviour>().CurrentHP = collision.gameObject.GetComponent<HPBarBehaviour>().CurrentHP - 60;
                //}
            }

        }

        // Update is called once per frame
        void Update()
        {
            if (GetComponent<Fighter>().IsStunned) return;

            GetComponent<Mover>().Move(MovementSpeed, JumpHeight);
            GetComponent<Mover>().Rotate();

            BasicAttack();

            //if (GetComponent<PathHolder>().ChoosenPath == null)
            //{
                SpecialAttack();
                Dash();
            //}
            //else
            //{
            //    GetComponent<PathHolder>().ChoosenPath.Dash(this.gameObject);
            //    GetComponent<PathHolder>().ChoosenPath.SpecialAttack(this.gameObject);
            //}
        }
        private void SpecialAttack()
        {
            if (Input.GetMouseButtonDown(1) && GetComponent<Fighter>().CanShoot)
            {
                GetComponent<Fighter>().Shoot(BombPrefab, false, 5, 8, 6, 1, 3,0);
            }
        }
        private void BasicAttack()
        {
            if (!CanShoot) return;

            if (Input.GetMouseButton(0) && GetComponent<Fighter>().CanShoot)
            {
                    GetComponent<Fighter>().Shoot(BulletPrefab, CanPierceActive, BulletDamage, BulletSpeed, BulletLifeSpan, BulletStunDuration, TimeBetweenBullets, 0);
            }
        }
        public void Dash()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && GetComponent<Mover>().CanDash)
            {
                GetComponent<Mover>().Dash(DashDistance);
            }
        }

    }

}
