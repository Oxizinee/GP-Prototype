using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaPoolBehaviour : MonoBehaviour
{
    private float _timer = 0f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<HPBarBehaviour>().CurrentHP = other.GetComponent<HPBarBehaviour>().CurrentHP - 10;
        }
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= 6)
        {
            Destroy(gameObject);
        }
    }
}
