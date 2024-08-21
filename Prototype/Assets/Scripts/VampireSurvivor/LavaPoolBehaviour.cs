using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaPoolBehaviour : MonoBehaviour
{
    private float _timer = 0f, _dmgTimer = 0;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            _dmgTimer += Time.deltaTime;

            if (_dmgTimer >= 1)
            {
                other.GetComponent<HPBarBehaviour>().CurrentHP = other.GetComponent<HPBarBehaviour>().CurrentHP - 10;
                _timer = 0;
            }
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
