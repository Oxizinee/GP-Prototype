using IMPossible.Combat.Missle;
using UnityEngine;

namespace IMPossible.Combat
{
    public class Fighter : MonoBehaviour
    {
        public bool CanShoot { get; private set; } = true;
        private float _timer, _bulletCooldown;
        public void Shoot(GameObject BulletPrefab, bool CanPierce, float Damage, float Speed, float Duration, float StunDuration, float BulletCooldown)
        {
            GameObject go = Instantiate(BulletPrefab, new Vector3(transform.position.x, transform.localScale.y/2,transform.position.z), transform.rotation);
            go.GetComponent<BasicBullet>().SetProperties(gameObject, Speed, Duration, StunDuration, Damage, CanPierce);
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
