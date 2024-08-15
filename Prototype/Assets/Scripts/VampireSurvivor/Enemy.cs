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
    public bool _isGrounded, _isStunned, _canShoot = true;
    public float Speed = 5;

    public GameObject Player, BulletPrefab;
    private Vector3 _input;
    [SerializeField]private float _stunTimer, _shootingTimer;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            _isStunned =true;
            GetComponent<HPBarBehaviour>().CurrentHP = GetComponent<HPBarBehaviour>().CurrentHP - 2;
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

    }

    private void IceEnemyBehaviour()
    {
        if (Type == EnemyType.Ice)
        {
            if (Vector3.Distance(Player.transform.position, transform.position) <= 10 && _canShoot)
            {
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
            _stunTimer += Time.deltaTime;
            if (_stunTimer >= 0.5f)
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
