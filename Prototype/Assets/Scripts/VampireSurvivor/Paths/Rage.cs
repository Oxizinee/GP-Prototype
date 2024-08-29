using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Paths/Rage")]
public class Rage : Path
{
    public int _enemiesKilled, _enemiesToLvlUp = 10;
    private GameRunner _gameRunner;
    public override void Dash(GameObject parent)
    {
        parent.GetComponent<Player>().Dash();
    }

    public override void Passive(GameObject parent)
    {
       _enemiesKilled = (int)_gameRunner.EnemiesKilledNumber;

        parent.GetComponent<Player>().BulletDamage = 2 + Level;


        if (_enemiesKilled >= _enemiesToLvlUp)
        {
            Level++;
            _enemiesToLvlUp = _enemiesToLvlUp + 10;
        }
    }

    public override void OnStart()
    {
        _gameRunner = FindAnyObjectByType<GameRunner>();
    }
    
}
