using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmmisionTest : MonoBehaviour
{
    // Start is called before the first frame update
    public float value =10;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow * value);

    }
}
