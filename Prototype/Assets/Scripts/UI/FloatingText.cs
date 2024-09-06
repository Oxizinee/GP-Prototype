using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    // Start is called before the first frame update
    public float DestroyTime = 3;
    public Vector3 Offset = new Vector3(0,2.5f,0);
    void Start()
    {
        Destroy(gameObject, DestroyTime);

        transform.localPosition += Offset;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale -= new Vector3(0.8f, 0.8f, 0.8f) * Time.deltaTime;
    }
}
