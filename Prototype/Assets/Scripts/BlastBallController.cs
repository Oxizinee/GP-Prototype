using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastBallController : MonoBehaviour
{
    // Start is called before the first frame update
    public float Force = 3;

    private void OnCollisionEnter(Collision collision)
    {
            Debug.Log("Bomb Hit  +" + collision.gameObject.name);
            if (collision.rigidbody != null)
            {
                collision.rigidbody.AddForce(new Vector3(transform.forward.x, collision.transform.position.y + 1, transform.forward.z) * Force,
                    ForceMode.Impulse);
                 if (collision.gameObject.tag == "Enemy")
                    {
                         collision.gameObject.GetComponent<HPBarBehaviour>().CurrentHP = collision.gameObject.GetComponent<HPBarBehaviour>().CurrentHP - 3;
                    }
             }

            Destroy(gameObject);
    }

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
