using IMPossible.Stats;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameRunner : MonoBehaviour
{
  //  public Text EnemiesPresent, EnemiesKilled;

    public float EnemiesKilledNumber, EnemiesPresentNmber;

    [SerializeField]private float _spawnTimer, _offset = 0.3f, _bigSpawnerTimer;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
     //   EnemiesPresent.text = "Enemies Present: " + EnemiesPresentNmber;
       // EnemiesKilled.text = "Enemies Killed: " + EnemiesKilledNumber;
    }

}
