using UnityEngine;
using IMPossible.Core;

namespace IMPossible.Combat.Missle
{
    public class BasicBullet : MonoBehaviour
    {
        public float Speed { get; set; } = 10;
        public float BulletLifeSpan { get; set; } = 9;
        public float StunDuration { get; set; } = 0.5f;
        public float Damage { get; set; } = 2;
        public bool CanPierce { get; set; } = false;

        private float _timer;


        private void OnCollisionEnter(Collision collision)
        {
           if (collision.gameObject.GetComponent<Health>() != null && collision.gameObject.GetComponent<Health>().CanBeAttacked())
            {
                if (collision.gameObject.tag == "Enemy")
                {
                    collision.gameObject.GetComponent<Enemy>().StunDuration = StunDuration;
                    collision.gameObject.GetComponent<Enemy>()._isStunned = true;
                }

                collision.gameObject.GetComponent<Health>().TakeDamage(Damage);
                PiercingBehaviour();
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Health>() != null && other.gameObject.GetComponent<Health>().CanBeAttacked())
            {
                other.gameObject.GetComponent<Health>().TakeDamage(Damage);
                PiercingBehaviour();
            }
        }
        public void PiercingBehaviour()
        {
            if (!CanPierce)
            {
                Destroy(gameObject);
            }
            else
            {
                CanPierce = false;
            }
        }

     
        // Update is called once per frame
        void Update()
        {
            _timer += Time.deltaTime;
            transform.position += transform.forward * Speed * Time.deltaTime;

            if (_timer > BulletLifeSpan)
            {
                Destroy(gameObject);
            }
        }
    }
}
