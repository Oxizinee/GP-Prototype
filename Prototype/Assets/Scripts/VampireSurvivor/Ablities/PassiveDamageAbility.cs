using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMPossible.Controller;

[CreateAssetMenu(menuName = "Abilities/Passive Damage")]
public class PassiveDamageAbility : Ability
{
    public float TimeBetweenBullets = 1;
    public float Damage = 4;
    public GameObject BulletPrefab;
    public LayerMask EnemyLayerMask;

    private float _timer;
    public override void Active(GameObject parent)
    {
        //Debug.Log("abilityActive");
        _timer += Time.deltaTime;

        if (_timer >= TimeBetweenBullets)
        {

            Vector3 closestEnemy = Vector3.zero;
            float closestEnemyDistance = Mathf.Infinity;

            Collider[] enemiesInRadius = Physics.OverlapSphere(parent.transform.position, 10, EnemyLayerMask);
            foreach (Collider c in enemiesInRadius)
            {
                if (c == null) continue;

                float distance = Vector3.Distance(c.transform.position, parent.transform.position);

                if (distance < closestEnemyDistance)
                {
                    closestEnemy = c.transform.position;
                    closestEnemyDistance = distance;
                }
            }

            if (closestEnemy != Vector3.zero)
            {
                GameObject go = Instantiate(BulletPrefab, new Vector3(parent.transform.position.x, parent.transform.localScale.y / 2, parent.transform.position.z), Quaternion.identity);
                Vector3 direction = closestEnemy - parent.transform.position;
                go.transform.rotation = Quaternion.LookRotation(direction);
                go.GetComponent<BulletMovement>().Damage = parent.GetComponent<Player>().PassiveDamage;
                _timer = 0;
            }
        }
    }
}
