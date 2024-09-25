using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ShaderTest : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private SkinnedMeshRenderer[] skinndedMeshes;
    [SerializeField]Dictionary<Material, LocalKeyword> materials = new Dictionary<Material, LocalKeyword>();
    public float pulseSpeed= 4;
    public bool isBlinking;
    void Start()
    {
        skinndedMeshes = GetComponentsInChildren<SkinnedMeshRenderer>();

        foreach (var mesh in skinndedMeshes)
        {
            Shader shader = mesh.material.shader;
            materials.Add(mesh.material, new LocalKeyword(shader, "_ISBLINKING"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var m in materials)
        {
            m.Key.SetFloat("_PulseSpeed", pulseSpeed);
            m.Key.SetKeyword(m.Value, isBlinking);
        }
    }
}
