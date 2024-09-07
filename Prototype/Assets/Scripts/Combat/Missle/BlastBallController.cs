using UnityEngine;
using IMPossible.Resources;
using UnityEngine.Rendering;

namespace IMPossible.Combat.Missle
{
    public class BlastBallController : BasicBullet
    {
        // Start is called before the first frame update
        public float Force = 800;
        public new float Speed = 5; 

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.rigidbody != null)
            {
                Collider[] insideBlastRadius = Physics.OverlapSphere(transform.position, 7);
                foreach (Collider collider in insideBlastRadius)
                {
                    Rigidbody rb = collider.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddExplosionForce(Force, transform.position, 7, 3);

                        if (rb.gameObject.tag == "Enemy" && rb.gameObject.GetComponent<Health>().CanBeAttacked())
                        {
                            rb.gameObject.GetComponent<Health>().TakeDamage(Shooter, Damage);
                        }
                    }
                }
            }
            Destroy(gameObject);
        }
    }
}