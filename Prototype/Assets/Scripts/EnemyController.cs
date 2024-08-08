using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;
using UnityEngine.AI;
public enum EnemyStates
{
    Walking,
        Selected
    }

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyStates State = EnemyStates.Walking;
    public Vector3 OffsetFromPlayer;
    public Transform Goal;
    public bool _isGrounded;
    public LayerMask FloorLayer;

    private NavMeshAgent _agent;
    private GameObject _player;
    private Vector3 _input;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<EnemyController>().State == EnemyStates.Selected) 
        {
            Destroy(GetComponent<NavMeshAgent>());
            GetComponent<Rigidbody>().AddForce(new Vector3(_player.transform.forward.x,transform.position.y + 1, _player.transform.forward.z) * 10, ForceMode.Impulse);
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BlastBall")
        {
            Debug.Log("BlastBall Hit");
            Destroy(GetComponent<NavMeshAgent>());
            GetComponent<Rigidbody>().AddForce(new Vector3(_player.transform.forward.x, transform.position.y + 1, _player.transform.forward.z) * 10, ForceMode.Impulse);
        }
    }
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        

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
            if (isGrounded())
            {
                if (_agent == null)
                {
                    _agent = gameObject.AddComponent<NavMeshAgent>();

                }
                _agent.destination = Goal.transform.position;

            }
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            OffsetFromPlayer = Vector3.zero;
            transform.parent = null;

        }

    }

    public bool isGrounded()
    {
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - (transform.localScale.y / 2), transform.position.z), -Vector3.up, Color.red);
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y - (transform.localScale.y / 2), transform.position.z), -Vector3.up, 0.8f, FloorLayer))
        {
            _isGrounded = true;
            return true;
        }
        else
        {
            _isGrounded = false;
            return false;
        }
    }
}
