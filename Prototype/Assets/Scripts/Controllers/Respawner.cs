using IMPossible.Supplies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Controller
{
    public class Respawner : MonoBehaviour
    {
        [SerializeField] private float _respawnDelay = 2;

        private float _healthRegenPercentage = 20;
        private Vector3 _respawnPosition;
        private void Awake()
        {
            GetComponent<Health>().OnDeath.AddListener(Respawn);
        }
        private void Start()
        {
            _respawnPosition = transform.position;
        }
        private void Respawn()
        {
          //  StartCoroutine(RespawnRoutine());
        }

        private IEnumerator RespawnRoutine()
        {
            yield return new WaitForSeconds(_respawnDelay);

        }
    }
}