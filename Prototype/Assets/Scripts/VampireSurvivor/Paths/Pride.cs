using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Paths/Pride")]
public class Pride : Path
{
    public bool _canShoot = true, _canShoot2 = true;
    public float NewRateOfFire = 0.5f;
    private float _shootingDelayTimer, _shootingTimer, _shootingDelayTimer2, _shootingTimer2;

    public override void Dash(GameObject parent)
    {

    }
    public override void SpecialAttack(GameObject parent)
    {
    }
    public override void Passive(GameObject parent)
    {
        parent.GetComponent<Player>().BulletDamage = 2 + Level;

        if (Level >= 1)
        {
            ShootBullet(parent, parent.transform.position + parent.transform.right, parent.transform.rotation);

            if(Level >= 2)
            {
                parent.GetComponent<Player>().TimeBetweenBullets = NewRateOfFire;

                if (Level >= 3)
                {
                    ShootMoreBullets(parent, parent.transform.position - parent.transform.right, parent.transform.rotation);
                }
            }
        }
    }

    private void ShootMoreBullets(GameObject parent, Vector3 position, Quaternion rotation)
    {
        if (Input.GetMouseButtonDown(0) && _canShoot2)
        {

            GameObject go = Instantiate(parent.GetComponent<Player>().BulletPrefab, position, rotation);
            go.GetComponent<BulletMovement>().CanPierce = parent.GetComponent<Player>().CanPierceActive;
            go.GetComponent<BulletMovement>().Damage = parent.GetComponent<Player>().BulletDamage;
            go.GetComponent<BulletMovement>().Speed = parent.GetComponent<Player>().BulletSpeed;


            _canShoot2 = false;

        }

        if (!_canShoot2)
        {
            _shootingDelayTimer2 += Time.deltaTime;

            if (_shootingDelayTimer2 >= parent.GetComponent<Player>().TimeBetweenBullets)
            {
                _canShoot2 = true;
                _shootingDelayTimer2 = 0;
            }
        }

        if (Input.GetMouseButton(0))
        {
            _shootingTimer2 += Time.deltaTime;

            if (_shootingTimer2 >= parent.GetComponent<Player>().TimeBetweenBullets)
            {
                GameObject go = Instantiate(parent.GetComponent<Player>().BulletPrefab, position, rotation);
                go.GetComponent<BulletMovement>().CanPierce = parent.GetComponent<Player>().CanPierceActive;
                go.GetComponent<BulletMovement>().Damage = parent.GetComponent<Player>().BulletDamage;
                go.GetComponent<BulletMovement>().Speed = parent.GetComponent<Player>().BulletSpeed;
                _shootingTimer2 = 0;
            }
        }
        else
        {
            _shootingTimer2 = 0;
        }
    }

    private void ShootBullet(GameObject parent, Vector3 position, Quaternion rotation)
    {
        if (Input.GetMouseButtonDown(0) && _canShoot)
        {

            GameObject go = Instantiate(parent.GetComponent<Player>().BulletPrefab, position, rotation);
            go.GetComponent<BulletMovement>().CanPierce = parent.GetComponent<Player>().CanPierceActive;
            go.GetComponent<BulletMovement>().Damage = parent.GetComponent<Player>().BulletDamage;
            go.GetComponent<BulletMovement>().Speed = parent.GetComponent<Player>().BulletSpeed;

            _canShoot = false;

        }

        if (!_canShoot)
        {
            _shootingDelayTimer += Time.deltaTime;

            if (_shootingDelayTimer >= parent.GetComponent<Player>().TimeBetweenBullets)
            {
                _canShoot = true;
                _shootingDelayTimer = 0;
            }
        }

        if (Input.GetMouseButton(0))
        {
            _shootingTimer += Time.deltaTime;

            if (_shootingTimer >= parent.GetComponent<Player>().TimeBetweenBullets)
            {
                GameObject go = Instantiate(parent.GetComponent<Player>().BulletPrefab, position, rotation);
                go.GetComponent<BulletMovement>().CanPierce = parent.GetComponent<Player>().CanPierceActive;
                go.GetComponent<BulletMovement>().Damage = parent.GetComponent<Player>().BulletDamage;
                go.GetComponent<BulletMovement>().Speed = parent.GetComponent<Player>().BulletSpeed;
                _shootingTimer = 0;
            }
        }
        else
        {
            _shootingTimer = 0;
        }
    }
    public override void OnLevelUp(GameObject player)
    {
        if (player.GetComponent<XPBar>().Level != 0 && player.GetComponent<XPBar>().Level % 3 == 0)
        {
            Level++;
        }
    }
}
