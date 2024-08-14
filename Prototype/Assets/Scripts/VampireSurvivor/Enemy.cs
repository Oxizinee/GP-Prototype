using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyStates State = EnemyStates.Walking;
    public bool _isGrounded;
    public float Speed = 5;

    private GameObject _player;
    private Vector3 _input;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded();

        if (State == EnemyStates.Selected) 
        {

            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

            _input = Input.mousePosition;
            _input.z = Camera.main.nearClipPlane + 8;
            Vector3 mouse = Camera.main.ScreenToWorldPoint(_input);
            transform.position = mouse;
        }

        if(State == EnemyStates.Walking) 
        {
            
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        }
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, Speed * Time.deltaTime);


        if(Input.GetMouseButtonDown(0)) 
        {
            GetComponent<HPBarBehaviour>().CurrentHP--;
        }
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
