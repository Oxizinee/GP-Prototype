using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AblityHolder : MonoBehaviour
{
    public Ability Ability;

    enum AbilityState
    {
        unlocked,
        locked
    }

    AbilityState State = AbilityState.locked;

    // Update is called once per frame
    void Update()
    {
        if (State == AbilityState.locked)
        {
            return;
        }
        else
        {
            Ability.Active();
        }
    }
}
