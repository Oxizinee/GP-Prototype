using IMPossible.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMPossible.Missle;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "Abilities/Machine Gun")]
public class MachineGunAbility : Ability
{
    public GameObject BulletPrefab;
    public float TimeBetweenBullets = 0.5f, Damage = 5, Direction1 = 90, Direction2 = -90;
    private float _timer;
    public override void Active(GameObject parent)
    {
        _timer += Time.deltaTime;

        if (_timer > TimeBetweenBullets)
        {
           GameObject go1 = Instantiate(BulletPrefab, new Vector3(parent.transform.position.x, parent.transform.localScale.y / 2, parent.transform.position.z), Quaternion.Euler(0, Direction1, 0));
           GameObject go2 = Instantiate(BulletPrefab, new Vector3(parent.transform.position.x, parent.transform.localScale.y / 2, parent.transform.position.z), Quaternion.Euler(0, Direction2,0));

            go1.GetComponent<BasicBullet>().Damage = Damage;
            go2.GetComponent<BasicBullet>().Damage = Damage;

            _timer = 0;
        }
    }
}
