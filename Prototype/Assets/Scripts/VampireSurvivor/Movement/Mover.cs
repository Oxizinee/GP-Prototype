using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Movement
{
    public class Mover : MonoBehaviour
    {
        public bool CanDash { get; private set; } = true;

        private float _verticalVel, _gravity = 12, _dashCooldown = 0;
        private Vector2 _movementInput;
        private Vector3 _moveVector;

        private void Update()
        {
            if (!CanDash)
            {
                _dashCooldown += Time.deltaTime;
                if (_dashCooldown > 2)
                {
                    _dashCooldown = 0;
                    CanDash = true;
                }
            }
        }

        public void Move(float Speed, float JumpHeight)
        {
            _movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            _moveVector = (Vector3.forward * _movementInput.y + Vector3.right * _movementInput.x) * Speed;
            _moveVector.y = _verticalVel;

            if (GetComponent<CharacterController>().isGrounded)
            {
                _verticalVel = -0.5f;
            }
            if (GetComponent<CharacterController>().isGrounded && Input.GetKey(KeyCode.Space)) //Jump
            {
                _verticalVel = JumpHeight;
            }
            else
            {
                _verticalVel -= _gravity * Time.deltaTime;
            }

            GetComponent<CharacterController>().Move(_moveVector * Time.deltaTime);
        }

        public void Dash(float DashDistance)
        {
            GetComponent<CharacterController>().Move(transform.forward * DashDistance);
            CanDash = false;
        }
        public void Rotate()
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

                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = rotation;
            }
        }
    }
}
