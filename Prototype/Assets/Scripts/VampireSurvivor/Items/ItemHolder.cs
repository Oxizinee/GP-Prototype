using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Item> ItemsHolding = new List<Item>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ItemsHolding != null)
        {
            foreach (var item in ItemsHolding)
            {
                item.Active(gameObject);
            }
        }
    }
}
