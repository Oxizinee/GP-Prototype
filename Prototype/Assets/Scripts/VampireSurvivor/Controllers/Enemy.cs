using IMPossible.Combat;
using IMPossible.Core;
using UnityEngine;
public enum EnemyType
{
    Basic,
    Ice,
    Charging,
    Big
}

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyType Type;
    public bool _isGrounded, _isStunned, _canCharge = true, _stunCharging;
    public float Speed = 5, StunDuration = 0.5f, InRadius = 10;

    public GameObject HPBar;

    public GameObject Player, BulletPrefab;
    [SerializeField]private float _stunTimer, _chargerTimer, _inChargeTimer;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        switch (Type)
        {
            case EnemyType.Big:
                {
                    GetComponent<Health>().HP = 50;
                    transform.localScale = transform.localScale * 1.4f;
                    break;
                }
        }

    }
    void Update()
    {
        if(GetComponent<Health>().IsDead) return;

        isGrounded();

        Move();
        StunBehaviour();
        IceEnemyBehaviour();
        ChargingEnemyBehaviour();
    }

    
    private void ChargingEnemyBehaviour()
    {
        if (Type == EnemyType.Charging)
        {
            GetComponent<LineRenderer>().SetPosition(0, transform.position);

            if (IsInRadius(InRadius) && _canCharge && Vector3.Distance(Player.transform.position, transform.position) >= 8)
            {
                StunDuration = 0.5f;
                _isStunned = true;
                _stunCharging = true;
                _canCharge = false;
            }

            if (_stunCharging)
            {
                GetComponent<LineRenderer>().SetPosition(1, Player.transform.position);

                Speed = 30;
                _inChargeTimer += Time.deltaTime;

                if (_inChargeTimer >= 0.8f)
                {
                    _stunCharging = false;
                    _inChargeTimer = 0;
                }

            }
            if (!_stunCharging)
            {
                GetComponent<LineRenderer>().SetPosition(1, transform.position);
                Speed = 5;
            }

            if (!_canCharge)
            {
                _chargerTimer += Time.deltaTime;
                if (_chargerTimer >= 3)
                {
                    //_stunCharging = false;
                    _canCharge = true;
                    _chargerTimer = 0;
                }
            }
        }
    }

    private void IceEnemyBehaviour()
    {
        if (Type == EnemyType.Ice)
        {
            if (IsInRadius(InRadius) && GetComponent<Fighter>().CanShoot)
            {
                StunDuration = 0.5f;
                _isStunned = true;
                GetComponent<Fighter>().Shoot(BulletPrefab, false, 2, 10, 9, 0.5f, 3);
            }
        }
    }

    private bool IsInRadius(float radius)
    {
        return Vector3.Distance(Player.transform.position, transform.position) <= radius;
    }

    private void StunBehaviour()
    {
        if (_isStunned)
        {
            _stunTimer += Time.deltaTime;
            if (_stunTimer >= StunDuration)
            {
                _isStunned = false;
                _stunTimer = 0;
            }
        }
    }

    private void Move()
    {
        if (_isStunned || !isGrounded()) return;  

        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);

        HPBar.transform.LookAt(Camera.main.transform.position);
        transform.LookAt(Player.transform.position);
    }

    public bool isGrounded()
    {
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z), -Vector3.up, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), -Vector3.up, out hit, 0.8f))
        {
            if (hit.collider.tag == "Floor")
            {
                _isGrounded = true;
                return true;
            }
            return false;
        }
        else
        {
                _isGrounded = false;
                return false;
           
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y + transform.localScale.y, transform.position.z), InRadius);
      
    }
}
