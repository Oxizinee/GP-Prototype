using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IMPossible.Inventory
{
    public class Inventory : MonoBehaviour
    {
        // Start is called before the first frame update
        public List<InventoryItem> ItemsHolding = new List<InventoryItem>(3);
        public List<GameObject> IconLists = new List<GameObject>();
        public bool CanUse = true;
        void Update()
        {
            //if (ItemsHolding != null && CanUse)
            //{
            //    if (Input.GetKeyDown(KeyCode.Alpha1))
            //    {
            //        ItemsHolding[0].Active(gameObject);
            //    }

            //    if (Input.GetKeyDown(KeyCode.Alpha2))
            //    {
            //        ItemsHolding[1].Active(gameObject);
            //    }

            //    if (Input.GetKeyDown(KeyCode.Alpha3))
            //    {
            //        ItemsHolding[2].Active(gameObject);
            //    }

            //    foreach (InventoryItem item in ItemsHolding)
            //    {
            //        item.PassiveUpdate(gameObject);

            //        if (!item.IsActive)
            //        {
            //            item.Cooldown();
            //        }
            //    }

            //    for (int i = 0; i < ItemsHolding.Count; i++)
            //    {
            //        IconLists[i].GetComponent<Image>().sprite = ItemsHolding[i].Icon;
            //    }
            //}
        }
    }
}