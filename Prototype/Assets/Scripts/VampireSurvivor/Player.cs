using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float MovementSpeed = 10, JumpHeight = 8, DashDistance = 5, DashCooldown = 2;

    private CharacterController _characterController;

    private float _verticalVel, _gravity = 12;
    private bool _canDash = true;
    private Vector2 _movementInput;
    private Vector3 _moveVector;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GetComponent<HPBarBehaviour>().CurrentHP--;
        }
    }
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotate();

        Dash();
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && _canDash)
        {
            _characterController.Move(transform.forward * DashDistance);
            _canDash = false;
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
        _moveVector = (transform.forward * _movementInput.y + Vector3.right * _movementInput.x) * MovementSpeed;
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
