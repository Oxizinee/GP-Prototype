using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private Material _deafultMat;
    private float _positionY;
    private Vector3 _input;
    void Start()
    {
        _deafultMat = GetComponent<Renderer>().material;
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
