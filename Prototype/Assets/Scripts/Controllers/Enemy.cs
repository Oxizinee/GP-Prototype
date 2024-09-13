using IMPossible.Combat;
using IMPossible.Inventory;
using IMPossible.Movement;
using IMPossible.Supplies;
using UnityEngine;

namespace IMPossible.Controller
{
    public class Enemy : MonoBehaviour
    {
        // Start is called before the first frame update
        public bool _canCharge = true, _stunCharging;
        public float Speed = 5, InRadius = 10;

        public GameObject Player, BulletPrefab;
        [SerializeField] private float _chargerTimer, _inChargeTimer;

        private void Awake()
        {
            GetComponent<Health>().OnDeath.AddListener(Die);
        }
        private void Die()
        {
            GetComponent<Animator>().SetTrigger("Die");
            DropLoot();
            Destroy(gameObject, 4);
        }
        private void DropLoot()
        {
            if (GetComponent<PickupSpawner>() != null)
            {
                GetComponent<PickupSpawner>().DropLoot();
            }
        }
        void Start()
        {
            Player = GameObject.FindGameObjectWithTag("Player");

            //switch (Type)
            //{
            //    case EnemyType.Big:
            //        {
            //            gameObject.AddComponent<PickupSpawner>();
            //            transform.localScale = transform.localScale * 1.4f;
            //            break;
            //        }
            //}

        }
        void Update()
        {
            if (!GetComponent<Health>().CanBeAttacked() || GetComponent<Fighter>().IsStunned) return;

            Move();

            IceEnemyBehaviour();
            ChargingEnemyBehaviour();
        }


        private void ChargingEnemyBehaviour()
        {
            //if (Type == EnemyType.Charging)
            //{
            //    GetComponent<LineRenderer>().SetPosition(0, transform.position);

            //    if (IsInRadius(InRadius) && _canCharge && Vector3.Distance(Player.transform.position, transform.position) >= 8)
            //    {
            //        GetComponent<Fighter>().GetStunned(0.5f);
            //        _stunCharging = true;
            //        _canCharge = false;
            //    }

            //    if (_stunCharging)
            //    {
            //        GetComponent<LineRenderer>().SetPosition(1, Player.transform.position);

            //        Speed = 30;
            //        _inChargeTimer += Time.deltaTime;

            //        if (_inChargeTimer >= 0.8f)
            //        {
            //            _stunCharging = false;
            //            _inChargeTimer = 0;
            //        }

            //    }
            //    if (!_stunCharging)
            //    {
            //        GetComponent<LineRenderer>().SetPosition(1, transform.position);
            //        Speed = 5;
            //    }

            //    if (!_canCharge)
            //    {
            //        _chargerTimer += Time.deltaTime;
            //        if (_chargerTimer >= 3)
            //        {
            //            //_stunCharging = false;
            //            _canCharge = true;
            //            _chargerTimer = 0;
            //        }
            //    }
            //}
        }
        private void IceEnemyBehaviour()
        {
            //if (Type == EnemyType.Ice)
            //{
            //    if (IsInRadius(InRadius) && GetComponent<Fighter>().CanShoot)
            //    {
            //        GetComponent<Fighter>().Shoot(BulletPrefab, false, 2, 10, 9, 0.5f, 3, 0.8f);
            //    }
            //}
        }
        private bool IsInRadius(float radius)
        {
            return Vector3.Distance(Player.transform.position, transform.position) <= radius;
        }
        private void Move()
        {
            GetComponent<EnemyMover>().Move(Player, Speed);
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y + transform.localScale.y, transform.position.z), InRadius);

        }
    }
}
