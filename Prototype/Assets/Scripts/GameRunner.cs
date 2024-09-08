using IMPossible.Stats;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameRunner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PauseScreen, EnemyPrefab;
    public Text EnemiesPresent, EnemiesKilled;
    private bool _isPaused;

    public float SpawnerTimer = 3, GameTime;

    public float EnemiesKilledNumber, EnemiesPresentNmber;
    private BaseStats _baseStats;

    [SerializeField]private float _spawnTimer, _offset = 0.3f, _bigSpawnerTimer;
    void Start()
    {
        SpawnerTimer = 3;
        _baseStats = GameObject.FindWithTag("Player").GetComponent<BaseStats>();
        _baseStats.OnLevelUp += PauseGame;
    }

    // Update is called once per frame
    void Update()
    {
        GameTime += Time.deltaTime;

     //   PauseGame();
        SpawnEnemies();

        SpawnerTimer = Mathf.Clamp(SpawnerTimer - (Time.deltaTime * 0.02f),0.5f,3);

        EnemiesPresent.text = "Enemies Present: " + EnemiesPresentNmber;
        EnemiesKilled.text = "Enemies Killed: " + EnemiesKilledNumber;
    }

    private void SpawnEnemies()
    {
        _spawnTimer += Time.deltaTime;
        _bigSpawnerTimer += Time.deltaTime;

        if (_spawnTimer >= SpawnerTimer)
        {
            int side = Random.Range(0, 4);
            int randomType = Random.Range(0, 3);

            // Initialize the spawn position in viewport coordinates
            Vector3 viewportPosition = Vector3.zero;

            switch (side)
            {
                case 0: // Left side
                    viewportPosition = new Vector3(-_offset, Random.Range(0f, 1f), Camera.main.nearClipPlane + 20);
                    break;
                case 1: // Right side
                    viewportPosition = new Vector3(1f + _offset, Random.Range(0f, 1f), Camera.main.nearClipPlane + 20);
                    break;
                case 2: // Top side
                    viewportPosition = new Vector3(Random.Range(0f, 1f), 1f + _offset, Camera.main.nearClipPlane + 20);
                    break;
                case 3: // Bottom side
                    viewportPosition = new Vector3(Random.Range(0f, 1f), -_offset, Camera.main.nearClipPlane + 20);
                    break;
            }

            // Convert the viewport position to world space
            Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(viewportPosition);

            // Instantiate the object at the calculated position
            GameObject enemy = Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
            enemy.GetComponent<Enemy>().Type = (EnemyType)randomType;
            EnemiesPresentNmber++;
            _spawnTimer = 0;
        }

        if (_bigSpawnerTimer >= 30)
        {
            int side = Random.Range(0, 4);

            // Initialize the spawn position in viewport coordinates
            Vector3 viewportPosition = Vector3.zero;

            switch (side)
            {
                case 0: // Left side
                    viewportPosition = new Vector3(-_offset, Random.Range(0f, 1f), Camera.main.nearClipPlane + 20);
                    break;
                case 1: // Right side
                    viewportPosition = new Vector3(1f + _offset, Random.Range(0f, 1f), Camera.main.nearClipPlane + 20);
                    break;
                case 2: // Top side
                    viewportPosition = new Vector3(Random.Range(0f, 1f), 1f + _offset, Camera.main.nearClipPlane + 20);
                    break;
                case 3: // Bottom side
                    viewportPosition = new Vector3(Random.Range(0f, 1f), -_offset, Camera.main.nearClipPlane + 20);
                    break;
            }

            // Convert the viewport position to world space
            Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(viewportPosition);

            // Instantiate the object at the calculated position
            GameObject enemy = Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
            enemy.GetComponent<Enemy>().Type = EnemyType.Big;
            EnemiesPresentNmber++;
            _bigSpawnerTimer = 0;
        }
    }

    private void PauseGame()
    {
        
          //  PauseScreen.SetActive(true);
            //Time.timeScale = 0;
        
    }
}
