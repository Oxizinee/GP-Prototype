using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRunner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PauseScreen, EnemyPrefab;
    private bool _isPaused;

    private float _spawnTimer, _offset = 0.3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer >= 3)
        {
            int side = Random.Range(0, 4);
            int randomType = Random.Range(0, 2);

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
            _spawnTimer = 0;
        }
    }

    private void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isPaused = !_isPaused;
        }

        if (_isPaused)
        {
            PauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            PauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
