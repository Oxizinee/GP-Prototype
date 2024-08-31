using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class LavaPoolBehaviour : MonoBehaviour
{
    public float TimeToDie = 6, Damage = 10, id;
    private float _timer = 0f, _dmgTimer = 0;
    private VisualEffect _visualEffect;

    private void Start()
    {
        _visualEffect = GetComponent<VisualEffect>();
        id = Shader.PropertyToID("Duration");
        _visualEffect.SetFloat((int)id, TimeToDie);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            _dmgTimer += Time.deltaTime;

            if (_dmgTimer >= 1)
            {
                other.GetComponent<HPBarBehaviour>().CurrentHP = other.GetComponent<HPBarBehaviour>().CurrentHP - Damage;
                other.GetComponent<Enemy>().ShowFloatingText(Damage, other.gameObject);
                other.GetComponent<Enemy>().SpawnBloodSplatter();
               _dmgTimer = 0;
            }
        }
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= TimeToDie)
        {
            Destroy(gameObject);
        }
    }
}
