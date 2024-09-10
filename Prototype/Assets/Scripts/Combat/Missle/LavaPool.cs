using IMPossible.Supplies;
using UnityEngine;
using UnityEngine.VFX;

namespace IMPossible.Combat.Missle
{
    public class LavaPool : MonoBehaviour
    {
        public float TimeToDie = 6, Damage = 10, id;
        private float _dmgTimer = 0;
        private VisualEffect _visualEffect;

        private void Start()
        {
            _visualEffect = GetComponent<VisualEffect>();
            id = Shader.PropertyToID("Duration");
            _visualEffect.SetFloat((int)id, TimeToDie);
            Destroy(gameObject, TimeToDie);
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Enemy")
            {
                _dmgTimer += Time.deltaTime;

                if (_dmgTimer >= 1)
                {
                    other.GetComponent<Health>().TakeDamage(gameObject, Damage);
                    _dmgTimer = 0;
                }
            }
        }
    }
}
