using UnityEngine;
using UnityEngine.UI;

public class HPBarBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float FullHp = 10, CurrentHP;
 
    public GameObject[] ItemsToSpawn;

    private GameRunner _gameRunner;
    private XPBar _levelScript;

    void Start()
    {
        _gameRunner = FindFirstObjectByType<GameRunner>();
        _levelScript = FindFirstObjectByType<XPBar>();
            FullHp = 8 + ((_levelScript.Level + 1) * 2) + (_gameRunner.GameTime * 0.02f);
    }

    // Update is called once per frame
    void Update()
    {
        
            if (CurrentHP <= 0)
            {
                _gameRunner.EnemiesKilledNumber++;
                _gameRunner.EnemiesPresentNmber--;
                if (GetComponent<Enemy>().Type == EnemyType.Big)
                {
                    Instantiate(ItemsToSpawn[Random.Range(0, ItemsToSpawn.Length)], transform.position, Quaternion.identity);
                }
              
            }


        
    }

}
