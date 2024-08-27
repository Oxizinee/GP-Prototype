using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathHolder : MonoBehaviour
{
    // Start is called before the first frame update
    public Path ChoosenPath;
    void Start()
    {
        ChoosenPath.Level = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ChoosenPath.Passive(this.gameObject);
    }
}
