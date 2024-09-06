using UnityEngine;
using UnityEngine.UI;

public class HPBarBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float FullHp = 10, CurrentHP;
 
    public Transform HPpivot;
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
        
            HPpivot.localScale = new Vector3(Mathf.Clamp(CurrentHP, 0, FullHp) / FullHp,HPpivot.localScale.y, HPpivot.localScale.z);
            if (CurrentHP <= 0)
            {
                _gameRunner.EnemiesKilledNumber++;
                _gameRunner.EnemiesPresentNmber--;
                Destroy(gameObject);

                if (GetComponent<Enemy>().Type == EnemyType.Big)
                {
                    Instantiate(ItemsToSpawn[Random.Range(0, ItemsToSpawn.Length)], transform.position, Quaternion.identity);
                    GetComponent<Enemy>().Player.GetComponent<XPBar>().XPCurrent = GetComponent<Enemy>().Player.GetComponent<XPBar>().XPCurrent + 10;
                }
                else
                {
                    GetComponent<Enemy>().Player.GetComponent<XPBar>().XPCurrent = GetComponent<Enemy>().Player.GetComponent<XPBar>().XPCurrent + 2;

                }
            }


        
    }

}
