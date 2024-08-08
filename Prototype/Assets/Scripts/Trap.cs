using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum TrapState
{
    BeingPlaced,
    Placed
}

public class Trap : MonoBehaviour
{
    // Start is called before the first frame update
    public TrapState State = TrapState.BeingPlaced;
    public LayerMask Layer;
    public Material PlacingMat;
    public float Force = 12, Radius = 5, RotationSpeed = 240;

    private Material _deafultMat;
    private float _positionY;
    private Vector3 _input;
    void Start()
    {
        _deafultMat = GetComponent<Renderer>().material;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.tag == "Enemy" && collision.gameObject.GetComponent<EnemyController>().State != EnemyStates.Selected && State != TrapState.BeingPlaced)
        {
            Destroy(collision.gameObject.GetComponent<NavMeshAgent>());

            collision.rigidbody.AddExplosionForce(Force, transform.position, Radius, 2, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (State == TrapState.BeingPlaced)
        {
            GetComponent<Renderer>().material = PlacingMat;
        
            _input = Input.mousePosition;
            _input.z = Camera.main.nearClipPlane + 5;
            Vector3 mouse = Camera.main.ScreenToWorldPoint(_input);

            if (Input.GetAxis("Mouse ScrollWheel")!= 0)
            {
                transform.Rotate(Vector3.up, (transform.eulerAngles.y + (RotationSpeed * Input.GetAxis("Mouse ScrollWheel"))) * Time.deltaTime);
                Debug.Log(transform.eulerAngles.y);
            }

            RaycastHit hit;
            if(Physics.Raycast(transform.position,-Vector3.up, out hit,Mathf.Infinity, Layer))
            {
                if (hit.collider != null)
                {
                    _positionY = hit.point.y + (transform.localScale.y/2);
                }
            }

            transform.position = new Vector3(mouse.x, _positionY,mouse.z);
        }
        else
        {
            transform.position = transform.position;
            GetComponent<Renderer>().material = _deafultMat;
        }
    }
}
