using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace IMPossible.Combat
{
    public class Fighter : MonoBehaviour
    {
        public bool CanShoot { get; private set; } = true;
        private float _timer, _bulletCooldown;
        public void Shoot(GameObject BulletPrefab, bool CanPierce, float Damage, float Speed, float Duration, float StunDuration, float BulletCooldown)
        {
            GameObject go = Instantiate(BulletPrefab, transform.position, transform.rotation);
            go.GetComponent<BulletMovement>().CanPierce = CanPierce;
            go.GetComponent<BulletMovement>().Damage = Damage;
            go.GetComponent<BulletMovement>().Speed = Speed;
            go.GetComponent<BulletMovement>().BulletLifeSpan = Duration;
            go.GetComponent<BulletMovement>().StunDuration = StunDuration;
            _bulletCooldown = BulletCooldown;
            
            CanShoot = false;
        }

        private void Update()
        {
            if (!CanShoot)
            {
                _timer += Time.deltaTime;

                if (_timer >= _bulletCooldown)
                {
                    CanShoot = true;
                    _timer = 0;
                }
            }
        }
    }
}
