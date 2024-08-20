using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float MovementSpeed = 10, JumpHeight = 8, DashDistance = 5, DashCooldown = 2, PassiveDamage = 10;
    public GameObject BulletPrefab, BombPrefab, FieldOfView;
    public Material InvincibleMat;
    public bool HornsActive;

    private CharacterController _characterController;

    private Material _deafultMat;
    private float _verticalVel, _gravity = 12, _invincibilityTimer, _shootingTimer, _bombCooldownTimer;
    private bool _canDash = true, _invincible = false, _canShootBomb = true;
    private Vector2 _movementInput;
    private Vector3 _moveVector;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && !_invincible && !collision.gameObject.GetComponent<Enemy>()._isStunned)
        {
            GetComponent<HPBarBehaviour>().CurrentHP--;

            if (HornsActive)
            {
                collision.gameObject.GetComponent<HPBarBehaviour>().CurrentHP = collision.gameObject.GetComponent<HPBarBehaviour>().CurrentHP - 60;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BulletForPlayer")
        {
            GetComponent<HPBarBehaviour>().CurrentHP--;
            Destroy(other.gameObject);
        }
    }
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _deafultMat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotate();

        Dash();
        ShootBullet();
        ShootBomb();
    }

    private void ShootBomb()
    {
        if (Input.GetMouseButtonDown(1) && _canShootBomb)
        {
            Instantiate(BombPrefab, transform.position, transform.rotation);
            _canShootBomb = false;
        }

        if (!_canShootBomb)
        {
            _bombCooldownTimer += Time.deltaTime;
            if (_bombCooldownTimer >= 3)
            {
                _canShootBomb = true;
                _bombCooldownTimer = 0;
            }
        }
    }
    private void ShootBullet()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = Instantiate(BulletPrefab, transform.position, transform.rotation);
        }

        if (Input.GetMouseButton(0))
        {
            _shootingTimer += Time.deltaTime;

            if (_shootingTimer >= 1)
            {
                GameObject go = Instantiate(BulletPrefab, transform.position, transform.rotation);
               _shootingTimer = 0;
            }
        }
        else
        {
            _shootingTimer = 0;
        }
    }
    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && _canDash)
        {
            _characterController.Move(transform.forward * DashDistance);
            _canDash = false;
            _invincible = true;
        }

        if (!_canDash)
        {
            DashCooldown -= Time.deltaTime;
            if (DashCooldown < 0)
            {
                DashCooldown = 2;
                _canDash = true;
                return;
            }
        }

        if (_invincible)
        {
            GetComponent<Renderer>().material = InvincibleMat;
            _invincibilityTimer += Time.deltaTime;
            if (_invincibilityTimer >= 0.8f)
            {
                _invincibilityTimer = 0;
                GetComponent<Renderer>().material = _deafultMat;
                _invincible = false;
            }
        }
    }


    private void Rotate()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Convert mouse position to world space, make sure to set an appropriate depth (z distance from camera)
        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);

        // Assuming the character is on a flat plane at y = 0
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distanceToPlane;

        if (plane.Raycast(ray, out distanceToPlane))
        {
            // Get the point on the plane where the mouse is pointing
            Vector3 targetPoint = ray.GetPoint(distanceToPlane);

            // Get the direction from the character to the target point
            Vector3 direction = targetPoint - transform.position;
            direction.y = 0f;  // Keep the direction in the XZ plane

            // Calculate the rotation needed to look at the target point
            Quaternion rotation = Quaternion.LookRotation(direction);

            // Apply the rotation to the character
            transform.rotation = rotation;
        }
    }

    private void Movement()
    {
        _movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _moveVector = (Vector3.forward * _movementInput.y + Vector3.right * _movementInput.x) * MovementSpeed;
        _moveVector.y = _verticalVel;

        if (_characterController.isGrounded)
        {
            _verticalVel = -0.5f;
        }
        if (_characterController.isGrounded && Input.GetKey(KeyCode.Space)) //Jump
        {
            _verticalVel = JumpHeight;
        }
        else
        {
            _verticalVel -= _gravity * Time.deltaTime;
        }

        _characterController.Move(_moveVector * Time.deltaTime);
    }
}
