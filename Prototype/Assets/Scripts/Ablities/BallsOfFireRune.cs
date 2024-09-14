using IMPossible.Combat.Missle;
using UnityEngine;
namespace IMPossible.Ability
{
    public class BallsOfFireRune : Rune
    {
        [SerializeField] private LayerMask _enemyLayerMask;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private float _radius = 20;
        public override void Behaviour(GameObject user)
        {
            for (int i = 0; i < GetStat(RuneStat.NumberOfSpawners); i++)
            {
                Vector3 closestEnemy = Vector3.zero;
                float closestEnemyDistance = Mathf.Infinity;

                Collider[] enemiesInRadius = Physics.OverlapSphere(user.transform.position, _radius, _enemyLayerMask);
                foreach (Collider c in enemiesInRadius)
                {
                    if (c == null) continue;

                    float distance = Vector3.Distance(c.transform.position, user.transform.position);

                    if (distance < closestEnemyDistance)
                    {
                        closestEnemy = c.transform.position;
                        closestEnemyDistance = distance;
                    }
                }

                if (closestEnemy != Vector3.zero)
                {
                    GameObject go = Instantiate(_bulletPrefab, new Vector3(user.transform.position.x, user.transform.localScale.y / 2, user.transform.position.z), Quaternion.identity);
                    Vector3 direction = closestEnemy - user.transform.position;
                    go.transform.rotation = Quaternion.LookRotation(direction);
                    go.GetComponent<BasicBullet>().SetProperties(user.gameObject, 12, 6, 0.8f, GetStat(RuneStat.Damage), false);
                    print("Bulet Shoot");
                }
            }
        }
    }
}
