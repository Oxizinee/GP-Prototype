using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 10;
    public float Damage = 2;
    private float _timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        transform.position += transform.forward * Speed * Time.deltaTime;

        if (_timer > 9)
        {
            Destroy(gameObject);
        }
    }
}
