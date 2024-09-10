using UnityEngine;
using IMPossible.Supplies;
using UnityEngine.Rendering;

namespace IMPossible.Combat.Missle
{
    public class BasicBullet : MonoBehaviour
    {
        public float Speed { get; set; } = 10;
        public float LifeSpan { get; set; } = 9;
        public float StunDuration { get; set; } = 0.5f;
        public float Damage { get; set; } = 2;
        public bool CanPierce { get; set; } = false;
        public GameObject Shooter { get; set; } = null;
        public void SetProperties(GameObject shooter, float speed, float lifeSpan, float stunDuration,float damage, bool canPierce)
        {
            Shooter = shooter;
            Speed = speed;
            LifeSpan = lifeSpan;
            StunDuration = stunDuration;
            Damage = damage;
            CanPierce = canPierce;
        }
        private void OnCollisionEnter(Collision collision)
        {
           if (collision.gameObject.GetComponent<Health>() != null && collision.gameObject.GetComponent<Health>().CanBeAttacked())
            {
                
                collision.gameObject.GetComponent<Fighter>().GetStunned(StunDuration);
                collision.gameObject.GetComponent<Health>().TakeDamage(Shooter, Damage);
                PiercingBehaviour();
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Health>() != null && other.gameObject.GetComponent<Health>().CanBeAttacked())
            {
                other.gameObject.GetComponent<Health>().TakeDamage(Shooter, Damage);
                PiercingBehaviour();
            }
        }

        private void Start()
        {
            DestroyAfterTime();
        }
        private void PiercingBehaviour()
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
            transform.position += transform.forward * Speed * Time.deltaTime;
        }

        private void DestroyAfterTime()
        {
            Destroy(gameObject, LifeSpan);
        }

        
    }
}
