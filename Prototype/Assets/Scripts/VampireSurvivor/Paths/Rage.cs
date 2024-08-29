using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Paths/Rage")]
public class Rage : Path
{
    private GameRunner _gameRunner;
    public override void Dash(GameObject parent)
    {
        parent.GetComponent<Player>().Dash();
    }

    public override void Passive(GameObject parent)
    {
    }

    public override void OnLevelUp(GameObject player)
    {
        _gameRunner = FindAnyObjectByType<GameRunner>();

        if (_gameRunner.EnemiesKilledNumber % 10 == 0)
        {
            Level++;
        }
    }
}
