using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HornsOfMinoutaour : Item
{
   [SerializeField] private bool _canActivate = true;
   [SerializeField] private float _timer;
    public LayerMask LayerMask;
    public override void Active(GameObject parent)
    {
        if (_canActivate)
        {
            Collider[] enemiesInRadius = Physics.OverlapSphere(parent.transform.position, 10, LayerMask);
            foreach (Collider c in enemiesInRadius)
            {
                c.GetComponent<Enemy>().StunDuration = 2;
                c.GetComponent<Enemy>()._isStunned = true;
            }

            _canActivate = false;
        }

        if (!_canActivate)
        {
            _timer += Time.deltaTime;
            if (_timer > 90)
            {
                _canActivate = true;
                _timer = 0;
            }
        }
    }
}
