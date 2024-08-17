using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ChangeColorAbility : Ability
{
    public Material newColor;
    public override void Active(GameObject parent)
    {
        parent.GetComponent<MeshRenderer>().sharedMaterial = newColor;
    }
}
