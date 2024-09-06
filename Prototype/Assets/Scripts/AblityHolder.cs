using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AblityHolder : MonoBehaviour
{
    public List<Ability> LockedAbilities = new List<Ability>();

    public List<Ability> UnlockedAbilities;

    private void Start()
    {
        UnlockedAbilities = new List<Ability>();
    }
    // Update is called once per frame
    void Update()
    {
        foreach (Ability ability in UnlockedAbilities)
        {
           ability.Active(gameObject);
                
        }

    }
}
