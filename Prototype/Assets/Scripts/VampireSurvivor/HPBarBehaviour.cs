using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum OwnerType
{
    Player,
    Enemy
}

public class HPBarBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public OwnerType Type;
    public float FullHp = 10, CurrentHP;
    public Image HPBar;
    public Transform HPpivot;
    public Transform HpBarGO;

    private GameRunner _gameRunner;
    private XPBar _levelScript;

    void Start()
    {
        _gameRunner = FindFirstObjectByType<GameRunner>();
        _levelScript = FindFirstObjectByType<XPBar>();

        if (Type == OwnerType.Enemy)
        {
            FullHp = 8 + ((_levelScript.Level + 1) * 2);
        }
        CurrentHP = FullHp;

    }

    // Update is called once per frame
    void Update()
    {
        if (Type == OwnerType.Player)
        {
            HPBar.fillAmount = Mathf.Clamp(CurrentHP, 0, FullHp) / FullHp;
        }
        else
        {
            HPpivot.localScale = new Vector3(Mathf.Clamp(CurrentHP, 0, FullHp) / FullHp,HPpivot.localScale.y, HPpivot.localScale.z);
            if (CurrentHP <= 0)
            {
                _gameRunner.EnemiesKilledNumber++;
                _gameRunner.EnemiesPresentNmber--;
                Destroy(gameObject);
                GetComponent<Enemy>().Player.GetComponent<XPBar>().XPCurrent++;
            }
        }


        
    }
}
