using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public string Name;
    public string Description;
    public bool IsActive = true;
    public float CooldownTimer = 0;
    public virtual void Active(GameObject parent) { }
    public virtual void Cooldown() { }

    public virtual void PassiveUpdate(GameObject parent) { }
}
