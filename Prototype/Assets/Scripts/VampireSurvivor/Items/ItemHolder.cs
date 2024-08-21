using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHolder : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Item> ItemsHolding = new List<Item>();
    public List<GameObject> IconLists = new List<GameObject>();
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
                item.PassiveUpdate(gameObject);

                if (!item.IsActive)
                {
                    item.Cooldown();
                }
            }

            for (int i = 0; i < ItemsHolding.Count; i++)
            {
                IconLists[i].GetComponent<Image>().sprite = ItemsHolding[i].Icon;
            }
        }
    }
}
