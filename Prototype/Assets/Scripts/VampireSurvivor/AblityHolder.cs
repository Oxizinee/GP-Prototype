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

    AbilityState State = AbilityState.unlocked;

    // Update is called once per frame
    void Update()
    {
        switch (State)
        {
            case AbilityState.unlocked:
                Ability.Active(gameObject);
                break;
            case AbilityState.locked:
                break;
        }

    }
}
