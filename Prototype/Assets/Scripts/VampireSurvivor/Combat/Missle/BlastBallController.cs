using UnityEngine;
using IMPossible.Core;

namespace IMPossible.Combat.Missle
{
    public class BlastBallController : MonoBehaviour
    {
        // Start is called before the first frame update
        public float Force = 3, Damage = 5;

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Bomb Hit  +" + collision.gameObject.name);
            if (collision.rigidbody != null)
            {
                Collider[] insideBlastRadius = Physics.OverlapSphere(transform.position, 7);
                foreach (Collider collider in insideBlastRadius)
                {
                    Rigidbody rb = collider.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddExplosionForce(800, transform.position, 7, 3);

                        if (rb.gameObject.tag == "Enemy" && rb.gameObject.GetComponent<Health>().CanBeAttacked())
                        {
                            rb.gameObject.GetComponent<Health>().TakeDamage(Damage);
                        }
                    }
                }
            }
            Destroy(gameObject);
        }
    }
}