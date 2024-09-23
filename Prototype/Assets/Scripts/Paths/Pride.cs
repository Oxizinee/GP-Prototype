using IMPossible.Combat;
using IMPossible.Combat.Missle;
using IMPossible.Movement;
using IMPossible.Supplies;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace IMPossible.Paths
{
    public class Pride : Path
    {
        public LayerMask EnemyLayerMask;
        public GameObject LaserPrefab, BulletPrefab;
        [SerializeField]private float _dashDistance = 50, _radius = 2;

        private float _shootingTimer, _specialAttackTimer, _rechargeTimer;
        [SerializeField]private bool _canUseSpecialAttack = true, _canUseBasicAttack = true;

        private int _maxDashCharges = 3, _currentDashCharges, _bulletCounter;
        private GameObject _laser = null;

        public override void OnStart()
        {
            base.OnStart();
            _laser = null;
            _canUseSpecialAttack = true;
            _currentDashCharges = _maxDashCharges;
        }

        public override void BasicAttack(GameObject user)
        {
            if(Input.GetMouseButton(0) && _canUseBasicAttack) 
            {
                for (int i = 0; i < GetStat(PathStat.NumberOfSpawners); i++)
                {
                    GameObject go = Instantiate(BulletPrefab, new Vector3(user.transform.position.x + i, user.transform.localScale.y / 2, user.transform.position.z), user.transform.rotation);
                    _bulletCounter++;

                    if (_bulletCounter == 7 && GetCurrentLevel() == 5)
                    {
                        go.GetComponent<BasicBullet>().SetProperties(user, 8, GetStat(PathStat.Speed), 0.8f, 12, true);
                    }

                    go.GetComponent<BasicBullet>().SetProperties(user, 8, GetStat(PathStat.Speed), 0.8f, 6, false);

                }
                _canUseBasicAttack = false;
            }

            if (!_canUseBasicAttack)
            {
                _shootingTimer += Time.deltaTime;
                if (_shootingTimer >= GetStat(PathStat.RateOfFire))
                {
                    _canUseBasicAttack= true;
                    _shootingTimer = 0;
                }
            }
        }
        public override void Dash(GameObject parent)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && _currentDashCharges > 0)
            {
                parent.GetComponent<Mover>().Dash(_dashDistance, 0.5f);
                _currentDashCharges--;
            }

            RechargeCharges();
        }
        private void RechargeCharges()
        {
            if (_currentDashCharges < _maxDashCharges)
            {
                _rechargeTimer += Time.deltaTime;
                if (_rechargeTimer >= 8)
                {
                    _currentDashCharges++;
                    _rechargeTimer = 0f;
                }
            }
        }
        public override void SpecialAttack(GameObject user)
        {
            if (Input.GetMouseButtonDown(1) && _canUseSpecialAttack && GetCurrentLevel() < 3)
            {
                if (_laser == null)
                {
                    _laser = Instantiate(LaserPrefab, new Vector3(user.transform.position.x, user.transform.position.y + user.transform.localPosition.y, user.transform.position.z), user.transform.rotation, user.transform);
                }
                _laser.SetActive(true);
                _laser.transform.localScale = new Vector3(_radius, _radius, 10);

                RaycastHit[] hit = Physics.SphereCastAll(new Vector3(user.transform.position.x, user.transform.position.y + user.transform.localPosition.y, user.transform.position.z), _radius, user.transform.forward, Mathf.Infinity, EnemyLayerMask);
                foreach(RaycastHit enemy in hit)
                {
                    enemy.collider.GetComponent<Health>().TakeDamage(user, 200);
                }
                
                _canUseSpecialAttack = false;
            }

            if (!_canUseSpecialAttack)
            {
                _specialAttackTimer += Time.deltaTime;
                if (_specialAttackTimer >= 120)
                {
                    _canUseSpecialAttack = true;
                    _specialAttackTimer = 0;
                }
            }
        }

        public override void UpdateLevel(GameObject user)
        {

        }
        public override void Passive(GameObject parent)
        {
            //parent.GetComponent<Player>().BulletDamage = 2 + Level;

            //if (Level >= 1)
            //{
            //    ShootBullet(parent, parent.transform.position + parent.transform.right, parent.transform.rotation);

            //    if (Level >= 2)
            //    {
            //        parent.GetComponent<Player>().TimeBetweenBullets = NewRateOfFire;

            //        if (Level >= 3)
            //        {
            //            ShootMoreBullets(parent, parent.transform.position - parent.transform.right, parent.transform.rotation);
            //        }
            //    }
            //}
        }
    }
}