using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : ScriptableObject
{
    public string Name;
    public int Level;
    public virtual void Passive() { }

}
