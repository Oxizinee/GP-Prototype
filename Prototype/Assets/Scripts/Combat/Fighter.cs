using IMPossible.Combat.Missle;
using UnityEngine;

namespace IMPossible.Combat
{
    public class Fighter : MonoBehaviour
    {
        public bool CanShoot { get; private set; } = true;
        public bool IsStunned { get; private set; } = false;
        private float _timer, _bulletCooldown, _stunTimer, _stunDuration;
        public void Shoot(GameObject BulletPrefab, bool CanPierce, float Damage, float Speed, float Duration, float StunDuration, float BulletCooldown, float StopToShootDuration)
        {
            GetStunned(StopToShootDuration);
            GameObject go = Instantiate(BulletPrefab, new Vector3(transform.position.x, transform.localScale.y/2,transform.position.z), transform.rotation);
            go.GetComponent<BasicBullet>().SetProperties(gameObject, Speed, Duration, StunDuration, Damage, CanPierce);
            _bulletCooldown = BulletCooldown;
            CanShoot = false;
        }

        public void GetStunned(float StunDuration)
        {
            _stunDuration = StunDuration;
            IsStunned = true;
        }
        private void Update()
        {
            ShootingCooldown();
            StunCooldown();

        }
        private void StunCooldown()
        {
            if (IsStunned)
            {
                _stunTimer += Time.deltaTime;
                if (_stunTimer >= _stunDuration)
                {
                    IsStunned = false;
                    _stunTimer = 0;
                }
            }
        }

        private void ShootingCooldown()
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
