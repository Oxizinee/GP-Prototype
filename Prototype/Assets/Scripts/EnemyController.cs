using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;
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
    public float InitialZ;


    private GameObject _player;
    private Vector3 _input;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<EnemyController>().State == EnemyStates.Selected) 
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(_player.transform.forward.x,transform.position.y + 1, _player.transform.forward.z) * 10, ForceMode.Impulse);
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BlastBall")
        {
            Debug.Log("BlastBall Hit");
            GetComponent<Rigidbody>().AddForce(new Vector3(_player.transform.forward.x, transform.position.y + 1, _player.transform.forward.z) * 10, ForceMode.Impulse);
        }
    }
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
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
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            InitialZ = 0;
            OffsetFromPlayer = Vector3.zero;
            transform.parent = null;
        }

    }
}
