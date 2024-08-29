using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(menuName = "Paths/Rage")]
public class Rage : Path
{
    public float _enemiesKilled, _enemiesToLvlUp = 10, NewMovementSpeed = 5, Radius = 4;
    public bool IsSpinning;
    public LayerMask EnemyLayer;
    private GameRunner _gameRunner;
   [SerializeField] private float _deafultMovementSpeed, _timer;
    public override void Dash(GameObject parent)
    {
        parent.GetComponent<Player>().Dash();
    }

    public override void SpecialAttack(GameObject parent)
    {
       if (Input.GetMouseButtonDown(1))
        {
            IsSpinning = !IsSpinning;
        }

       if (IsSpinning)
        {
            _timer += Time.deltaTime;

            parent.GetComponent<ItemHolder>().CanUse = false;
            parent.GetComponent<Player>().CanShoot = false;
            parent.GetComponent<Player>().MovementSpeed = NewMovementSpeed;


            Collider[] enemiesInRadius = Physics.OverlapSphere(parent.transform.position, Radius, EnemyLayer);
            if (enemiesInRadius != null && _timer >= 0.5f)
            {
                foreach (Collider c in enemiesInRadius)
                {
                    c.GetComponent<HPBarBehaviour>().CurrentHP = c.GetComponent<HPBarBehaviour>().CurrentHP - 30;
                }
                _timer = 0;
            }
        }
       else
        {
            _timer =  0;
            parent.GetComponent<ItemHolder>().CanUse = true;
            parent.GetComponent<Player>().CanShoot = true;
            parent.GetComponent<Player>().MovementSpeed = _deafultMovementSpeed;
        }
    }
    public override void Passive(GameObject parent)
    {
       _enemiesKilled = _gameRunner.EnemiesKilledNumber;

        parent.GetComponent<Player>().BulletDamage = 2 + Level;


        if (_enemiesKilled >= _enemiesToLvlUp)
        {
            Level++;
            _enemiesToLvlUp = _enemiesToLvlUp + 10;
        }


        if (Level >= 1)
        {
            parent.GetComponent<Player>().BulletSpeed = 12;
            parent.GetComponent<Player>().BulletLifeSpan = 5;

            if (Level >= 2)
            {
                parent.GetComponent<Player>().BulletStunDuration = 0.8f; 

                if (Level >= 3)
                {
                    parent.GetComponent<Player>().CanPierceActive = true;

                }
            }
        }
    }

    public override void OnStart(GameObject parent)
    {
        Level = 0;
        IsSpinning = false;
        _deafultMovementSpeed = parent.GetComponent<Player>().MovementSpeed;
        _gameRunner = FindAnyObjectByType<GameRunner>();
    }
    
}
