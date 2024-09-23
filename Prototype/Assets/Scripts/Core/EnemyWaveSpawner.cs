using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using static IMPossible.Core.EnemyWaveSpawner;

namespace IMPossible.Core
{
    public class EnemyWaveSpawner : MonoBehaviour
    {
        [SerializeField] private Wave[] _waves;
        [SerializeField] private GameObject _eliteEnemy;

        private int _currentWave = 0;
        float _offset = 0.4f, _waveCountdown, _timeBetweenWaves = 3,_eliteEnemyTimer;

        public event Action OnEnemySpawned;

        private void Start()
        {
            _waveCountdown = _timeBetweenWaves;
        }

        private void Update()
        {

            _eliteEnemyTimer += Time.deltaTime;

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
                 if (_eliteEnemyTimer >= 30)
                {
                    Instantiate(_eliteEnemy, GetOffScreenPosition(), Quaternion.identity, transform);
                    OnEnemySpawned?.Invoke();
                    _eliteEnemyTimer = 0;
                }

            WinGame();
        }

        private void WinGame()
        {
            if (_waves.All(x => x.State == SpawnState.Done) && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                _eliteEnemyTimer = 0;
                Debug.Log("You won");
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
            _currentWave = Mathf.Min(_currentWave + 1, _waves.Length -1);
            ResetCountdown();

            yield break;
        }

        private void ResetCountdown()
        {
            _waveCountdown = _timeBetweenWaves;
        }
        private void SpawnEnemy(Wave wave)
        {
            foreach (Enemy enemy in wave.EnemiesToSpawn)
            {
                for (int i = 0; i < enemy.AmountToSpawn; i++)
                {
                    Instantiate(enemy.EnemyPrefab, GetOffScreenPosition(), Quaternion.identity, transform);
                    OnEnemySpawned?.Invoke();
                }
            }
        }

        private Vector3 GetOffScreenPosition()
        {
            Vector3 viewportPosition = Vector3.zero;

            int side = UnityEngine.Random.Range(0, 4);
            switch (side)
            {
                case 0: // Left side
                    viewportPosition = new Vector3(-_offset, UnityEngine.Random.Range(0f, 1f), Camera.main.nearClipPlane + 10);
                    break;
                case 1: // Right side
                    viewportPosition = new Vector3(1f + _offset, UnityEngine.Random.Range(0f, 1f), Camera.main.nearClipPlane + 10);
                    break;
                case 2: // Top side
                    viewportPosition = new Vector3(UnityEngine.Random.Range(0f, 1f), 1f + _offset, Camera.main.nearClipPlane + 45);
                    break;
                case 3: // Bottom side
                    viewportPosition = new Vector3(UnityEngine.Random.Range(0f, 1f), -_offset, Camera.main.nearClipPlane + 10);
                    break;
            }

            return Camera.main.ViewportToWorldPoint(viewportPosition);
        }

        [Serializable]
        public class Wave
        {
            public SpawnState State = SpawnState.Waiting;
            public Enemy[] EnemiesToSpawn;
            public float Duration;
            public float SpawnRate;
        }

        [Serializable]
        public class Enemy
        {
            public GameObject EnemyPrefab;
            public int AmountToSpawn;
        }

        public enum SpawnState
        { 
           Waiting,
           Spawning,
           Done
        }
    }
}