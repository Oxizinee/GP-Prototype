using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : ScriptableObject
{
    public string Name;
    public int Level = 0;
    public virtual void Passive(GameObject parent) { }
    public virtual void SpecialAttack(GameObject parent) { }
    public virtual void Dash(GameObject parent) { }
    public virtual void OnLevelUp(GameObject parent) { }

}
