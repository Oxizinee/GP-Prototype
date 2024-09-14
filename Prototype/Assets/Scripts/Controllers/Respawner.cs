using IMPossible.Supplies;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace IMPossible.Controller
{
    public class Respawner : MonoBehaviour
    {
        [SerializeField] private float _respawnDelay = 2;

        private float _healthRegenPercentage = 20;
        private Vector3 _respawnLocation;
        private void Awake()
        {
            GetComponent<Health>().OnDeath.AddListener(Respawn);
        }
        private void Start()
        {
            _respawnLocation = transform.position;
        }
        private void Respawn()
        {
          // StartCoroutine(RespawnRoutine());
        }

        //private IEnumerator RespawnRoutine()
        //{
        //    yield return new WaitForSeconds(_respawnDelay);
        //    Fader fader = FindObjectOfType<Fader>();

        //    yield return fader.FadeOut(fadeTime);

        //    yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        //}
    }
}