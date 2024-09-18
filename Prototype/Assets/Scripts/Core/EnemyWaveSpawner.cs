using System;
using System.Collections;
using UnityEngine;

namespace IMPossible.Core
{
    public class EnemyWaveSpawner : MonoBehaviour
    {
        [SerializeField] private Wave[] _waves;

        private int _currentWave = 0;
        private float _offset = 0.4f, _offsetFromClipPlane = 30, _waveCountdown, _timeBetweenWaves = 3;

        public event Action OnEnemySpawned;

        private void Start()
        {
            _waveCountdown = _timeBetweenWaves;
        }

        private void Update()
        {
            if (_waves[_currentWave].State == SpawnState.Waiting)
            {
                if (_waveCountdown <= 0)
                {
                    StartCoroutine(SpawnWave(_waves[_currentWave]));
                }
                else
                {
                    _waveCountdown -= Time.deltaTime;
                }
            }
        }

        private IEnumerator SpawnWave(Wave wave)
        {
            wave.State = SpawnState.Spawning;

            for(int i = 0;  i < wave.Duration; i++)
            {
                SpawnEnemy(wave);
                yield return new WaitForSeconds(1f/ wave.SpawnRate);
            }

            wave.State = SpawnState.Done;
            _currentWave++;
            _waveCountdown = ResetCountdown();

            yield break;
        }

        private float ResetCountdown()
        {
            return _timeBetweenWaves;
        }
        private void SpawnEnemy(Wave wave)
        {
            int randomImp = UnityEngine.Random.Range(0, wave.EnemyTypesToSpawn.Length);

            for (int i = 0; i < wave.EnemiesToSpawnAtOnce; i++)
            {
                Instantiate(wave.EnemyTypesToSpawn[randomImp], GetOffScreenPosition(), Quaternion.identity, transform);
                OnEnemySpawned?.Invoke();
            }
        }

        private Vector3 GetOffScreenPosition()
        {
            Vector3 viewportPosition = Vector3.zero;

            int side = UnityEngine.Random.Range(0, 4);
            switch (side)
            {
                case 0: // Left side
                    viewportPosition = new Vector3(-_offset, UnityEngine.Random.Range(0f, 1f), Camera.main.nearClipPlane + _offsetFromClipPlane);
                    break;
                case 1: // Right side
                    viewportPosition = new Vector3(1f + _offset, UnityEngine.Random.Range(0f, 1f), Camera.main.nearClipPlane + _offsetFromClipPlane);
                    break;
                case 2: // Top side
                    viewportPosition = new Vector3(UnityEngine.Random.Range(0f, 1f), 1f + _offset, Camera.main.nearClipPlane + _offsetFromClipPlane);
                    break;
                case 3: // Bottom side
                    viewportPosition = new Vector3(UnityEngine.Random.Range(0f, 1f), -_offset, Camera.main.nearClipPlane + _offsetFromClipPlane);
                    break;
            }

            return Camera.main.ViewportToWorldPoint(viewportPosition);
        }

        [Serializable]
        public class Wave
        {
            public SpawnState State = SpawnState.Waiting;
            public GameObject[] EnemyTypesToSpawn;
            public float Duration;
            public float SpawnRate;
            public int EnemiesToSpawnAtOnce;
        }

        public enum SpawnState
        { 
           Waiting,
           Spawning,
           Done
        }
    }
}