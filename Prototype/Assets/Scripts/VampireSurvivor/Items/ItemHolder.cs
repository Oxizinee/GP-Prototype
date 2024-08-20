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
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                ItemsHolding[0].Active(gameObject);
            }

            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                ItemsHolding[1].Active(gameObject);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ItemsHolding[2].Active(gameObject);
            }

            foreach (Item item in ItemsHolding)
            {
                if (!item.IsActive)
                {
                    item.Cooldown();
                }
            }
        }
    }
}
