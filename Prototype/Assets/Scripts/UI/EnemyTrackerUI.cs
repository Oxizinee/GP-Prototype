using IMPossible.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IMPossible.UI
{
    public class EnemyTrackerUI : MonoBehaviour
    {
        [SerializeField]private Text[] EnemyTrackerTexts;

        private int _enemiesKilledNumber, _enemiesPresentNumber;

        private EnemyWaveSpawner _enemyWaveSpawner;
        void Start()
        {
            _enemyWaveSpawner = GameObject.Find("EnemyWaveSpawner").GetComponent<EnemyWaveSpawner>();
            EnemyTrackerTexts = GetComponentsInChildren<Text>();

            _enemyWaveSpawner.OnEnemySpawned += _enemyWaveSpawner_OnEnemySpawned;
        }

        private void _enemyWaveSpawner_OnEnemySpawned()
        {
            _enemiesPresentNumber++;
            EnemyTrackerTexts[0].text = "Enemies Present " + _enemiesPresentNumber;
        }
    }
}