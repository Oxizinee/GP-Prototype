using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float MovementSpeed = 10, JumpHeight = 8, RotationSpeedY = 200, RotationSpeedX = 230;


    private CharacterController _characterController;

    private float _verticalVel, _gravity = 12, _targetYRotation;
    private Vector2 _movementInput, _rotateInput, _cameraRotationMinMax;
    private Vector3 _moveVector;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotate();   
    }
    private void Rotate()
    {
        _targetYRotation += -Input.GetAxis("Mouse Y") * RotationSpeedY * Time.deltaTime;
        _targetYRotation = Mathf.Clamp(_targetYRotation, -20, 20);

        transform.Rotate(0, Input.GetAxis("Mouse X") * RotationSpeedX * Time.deltaTime, 0);
        Camera.main.transform.rotation = Quaternion.Euler(_targetYRotation, Camera.main.transform.rotation.eulerAngles.y, Camera.main.transform.rotation.eulerAngles.z);
    }

    private void Movement()
    {
        _movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _moveVector = (transform.forward * _movementInput.y + transform.right * _movementInput.x) * MovementSpeed;
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
