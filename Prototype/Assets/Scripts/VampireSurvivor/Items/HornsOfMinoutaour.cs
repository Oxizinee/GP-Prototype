using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HornsOfMinoutaour : Item
{
    public LayerMask LayerMask;
    public override void Active(GameObject parent)
    {
        parent.GetComponent<Player>().HornsActive = true;
        if (IsActive)
        {
            Collider[] enemiesInRadius = Physics.OverlapSphere(parent.transform.position, 10, LayerMask);
            foreach (Collider c in enemiesInRadius)
            {
                c.GetComponent<Enemy>().StunDuration = 2;
                c.GetComponent<Enemy>()._isStunned = true;
            }

            IsActive = false;
        }

    }

    public override void Cooldown()
    {
        if (!IsActive)
        {
            CooldownTimer += Time.deltaTime;
            if (CooldownTimer > 90)
            {
                IsActive = true;
                CooldownTimer = 0;
            }
        }
    }
}
