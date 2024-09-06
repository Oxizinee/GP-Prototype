using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    public float TimeToLive = 1.2f;
    void Start()
    {
        Destroy(gameObject, TimeToLive);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<HPBarBehaviour>().CurrentHP = other.GetComponent<HPBarBehaviour>().CurrentHP - 100;
        }
    }

}
