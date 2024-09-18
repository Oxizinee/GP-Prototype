using IMPossible.Supplies;
using UnityEngine;
using UnityEngine.VFX;

namespace IMPossible.Combat.Missle
{
    public class LavaPool : MonoBehaviour
    {
        private VisualEffect _visualEffect;

        private int _id;
        private float _damage, _duration, _dmgTimer;

        private GameObject _player;

        private void Start()
        {
            _visualEffect = GetComponent<VisualEffect>();
            _id = Shader.PropertyToID("Duration");
            _visualEffect.SetFloat((int)_id, _duration);
            Destroy(gameObject, _duration);
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Enemy")
            {
                _dmgTimer += Time.deltaTime;

                if (_dmgTimer >= 1)
                {
                    other.GetComponent<Health>().TakeDamage(_player, _damage);
                    _dmgTimer = 0;
                }
            }
        }
        public void SetLavaPool(GameObject player, float Damage, float Size, float Duration)
        {
            _player = player;
            _damage = Damage;
            transform.localScale = new Vector3(Size, Size, Size);
            _duration = Duration;
        }

    }
}
