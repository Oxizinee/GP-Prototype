using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleController : MonoBehaviour
{
    // Start is called before the first frame update
    public float PullStrength = 10;
    public Transform PullCenter;
    private bool _startPulling;
    private List<GameObject> _enemiesToPull = new List<GameObject>();
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && other.gameObject.GetComponent<EnemyController>().State == EnemyStates.Walking)
        {
            _enemiesToPull.Add(other.gameObject);
            _startPulling = true;
            Debug.Log("enemy in range");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (_startPulling)
        {
            foreach (var enemy in _enemiesToPull)
            {
                Vector3 direction = (PullCenter.transform.position - enemy.transform.position).normalized;
                Vector3 pullForce = direction * PullStrength;

                enemy.GetComponent<Rigidbody>().AddForce(pullForce, ForceMode.Acceleration);
            }
        }
    }
}
