using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.UI;
public enum AbilityState
{
    unlocked,
    locked
}

public class Ability: ScriptableObject 
{
    public AbilityState State = AbilityState.locked;

    public string Name;

    public virtual void Active(GameObject parent) { }

}
