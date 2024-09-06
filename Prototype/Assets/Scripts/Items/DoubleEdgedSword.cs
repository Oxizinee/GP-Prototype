using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMPossible.Controller;

[CreateAssetMenu]
public class DoubleEdgedSword : Item
{
    // Start is called before the first frame update
    public override void Active(GameObject parent)
    {
        if (IsActive)
        {
            parent.GetComponentInChildren<Player>().FieldOfView.SetActive(true);
            parent.GetComponentInChildren<Player>().FieldOfView.GetComponent<FieldOfView>().IsActive = true;

            IsActive = false;
        }
    }

    public override void Cooldown()
    {
        if(!IsActive)
        {
            CooldownTimer += Time.deltaTime;

            if(CooldownTimer > 15)
            {
                IsActive = true;
                CooldownTimer = 0;
            }
        }
    }

    public override void PassiveUpdate(GameObject parent)
    {
        parent.GetComponent<Player>().EnemyDamage = 2;
    }
}
