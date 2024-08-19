using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyType
{
    Basic,
    Ice,
    Charging
}

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyType Type;
    public bool _isGrounded, _isStunned, _canShoot = true, _canCharge = true, _stunCharging;
    public float Speed = 5, StunDuration = 0.5f;

    public Material BasicImpMat, IceImpMat, ChargingImpMat, StunnedMat;

    private Material DeafultMat;
    public GameObject Player, BulletPrefab;
    [SerializeField]private float _stunTimer, _shootingTimer, _chargerTimer, _inChargeTimer;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        switch (Type)
        {
            case EnemyType.Basic:
                {
                    GetComponent<MeshRenderer>().sharedMaterial = BasicImpMat;
                    break;
                }
           case EnemyType.Ice:
                {
                    GetComponent<MeshRenderer>().sharedMaterial = IceImpMat;
                    break;
                }
           case EnemyType.Charging: 
                {
                    GetComponent<MeshRenderer>().sharedMaterial = ChargingImpMat;
                    break;
                }
        }

        DeafultMat = GetComponent<MeshRenderer>().sharedMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            StunDuration = 0.5f;
            _isStunned =true;
            GetComponent<HPBarBehaviour>().CurrentHP = GetComponent<HPBarBehaviour>().CurrentHP - other.GetComponent<BulletMovement>().Damage;
            Destroy(other.gameObject);
        }
       
    }
    // Update is called once per frame
    void Update()
    {
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

            if (Vector3.Distance(Player.transform.position, transform.position) <= 10 && _canCharge && Vector3.Distance(Player.transform.position, transform.position) >= 8)
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
            if (Vector3.Distance(Player.transform.position, transform.position) <= 10 && _canShoot)
            {
                StunDuration = 0.5f;
                _isStunned=true;
                GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
                Vector3 direction = Player.transform.position - transform.position;
                bullet.transform.rotation = Quaternion.LookRotation(direction);
                _canShoot = false;
            }
            if (!_canShoot)
            {
                _shootingTimer += Time.deltaTime;
                if (_shootingTimer >= 3)
                {
                    _canShoot = true;
                    _shootingTimer = 0;
                }
            }
        }
    }

    private void StunBehaviour()
    {
        if (_isStunned)
        {
            GetComponent<MeshRenderer>().sharedMaterial = StunnedMat;
            _stunTimer += Time.deltaTime;
            if (_stunTimer >= StunDuration)
            {
                _isStunned = false;
                _stunTimer = 0;
            }
        }

        else
        {
            GetComponent<MeshRenderer>().sharedMaterial = DeafultMat;
        }
    }

    private void Move()
    {
        if (_isStunned || !isGrounded()) return;  
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);
    }

    public bool isGrounded()
    {
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - (transform.localScale.y / 2), transform.position.z), -Vector3.up, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y - (transform.localScale.y / 2), transform.position.z), -Vector3.up, out hit, 0.8f))
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
}
