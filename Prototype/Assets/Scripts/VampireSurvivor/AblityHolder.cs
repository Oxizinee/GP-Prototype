using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AblityHolder : MonoBehaviour
{
    public Ability[] Abilities;

    // Update is called once per frame
    void Update()
    {
        foreach (Ability ability in Abilities)
        {
            switch (ability.State)
            {
                case AbilityState.unlocked:
                    {
                        ability.Active(gameObject);
                    }
                    break;
                case AbilityState.locked:
                    break;
            }
        }

    }
}
