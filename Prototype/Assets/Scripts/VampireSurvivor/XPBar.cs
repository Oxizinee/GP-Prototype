using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image XPbar;
    public float XPCurrent = 0, XPMax = 15;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        XPbar.fillAmount =  XPCurrent/ XPMax;
    }
}
