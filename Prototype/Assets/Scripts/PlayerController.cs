using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float MovementSpeed = 10, JumpHeight = 8, RotationSpeedY = 200, RotationSpeedX = 230, ThrowForce = 50;
    public GameObject BlastBallPrefab, TrapPrefab;

    private CharacterController _characterController;

    private float _verticalVel, _gravity = 12, _targetYRotation;
    private Vector2 _movementInput;
    private Vector3 _moveVector, _mousePosition, _mouseInput;
    private bool _trapAbilityActive = false;
    private GameObject _selectedEnemy, _selectedTrap;
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
        ThrowEnemy();
        ShootBlastBall();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _trapAbilityActive = true;
        }

        if(_trapAbilityActive && _selectedTrap == null) 
        {
            _selectedTrap = Instantiate(TrapPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 2), Quaternion.identity);
        }
        else if(_trapAbilityActive && _selectedTrap != null && Input.GetMouseButtonDown(0)) 
        {
            _selectedTrap.GetComponent<Trap>().State = TrapState.Placed;
            _selectedTrap = null;
            _trapAbilityActive = false;
        }
    }

    private void ShootBlastBall()
    {
        if(Input.GetMouseButtonDown(1)) 
        {
            Instantiate(BlastBallPrefab, transform.position, transform.rotation);
        }
    }
    private void ThrowEnemy()
    {
        if (_trapAbilityActive) return;
        
        RaycastHit mouseRaycast;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out mouseRaycast))
            {
                if (mouseRaycast.rigidbody.tag == "Enemy")
                {
                    Debug.Log("Enemy hit");

                    _selectedEnemy = mouseRaycast.rigidbody.gameObject;

                    _mouseInput = Input.mousePosition;
                    _mouseInput.z = Camera.main.nearClipPlane + mouseRaycast.point.z;
                    _selectedEnemy.transform.parent = transform;

                    _selectedEnemy.GetComponent<EnemyController>().State = EnemyStates.Selected;

                }
            }
        }
        if (Input.GetMouseButtonUp(0) && _selectedEnemy != null)
        {
            _selectedEnemy.GetComponent<Rigidbody>().AddForce(transform.forward * ThrowForce, ForceMode.Impulse);

            _selectedEnemy.GetComponent<EnemyController>().State = EnemyStates.Walking;
            _selectedEnemy = null;
        }
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
