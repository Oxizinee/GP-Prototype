using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.UI;

public class Ability: ScriptableObject 
{
    public string Name;

    public virtual void Active(GameObject parent) { }

}
