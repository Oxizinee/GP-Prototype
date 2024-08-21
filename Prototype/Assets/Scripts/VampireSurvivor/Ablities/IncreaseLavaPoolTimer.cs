using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IncreaseLavaPoolTimer : Ability
{
    public LavaPoolBehaviour[] lavaPools;
    public float NewTime = 12;
    public override void Active(GameObject parent)
    {

        lavaPools = FindObjectsByType <LavaPoolBehaviour>(FindObjectsSortMode.None);
        if (lavaPools != null)
        {
            foreach(var pool in lavaPools)
            {
                pool.TimeToDie = NewTime;
            }
        }
    }
}
