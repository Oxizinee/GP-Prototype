using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public string Name;
    public string Description;
    public KeyCode KeyToActivate;
    public virtual void Active(GameObject parent) { }
}
