using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IMPossible.Inventory
{
    public class Inventory : MonoBehaviour
    {
        // Start is called before the first frame update
        public Dictionary<int, InventoryItem> ItemsHolding = new Dictionary<int, InventoryItem>();
        public List<GameObject> UIIcons = new List<GameObject>();
        public bool CanUse = true;
        public bool HasFreeSpace()
        {
            if(ItemsHolding.Count < 3) return true;
            else
            {
                return false;
            }
        }

        public void AddIconToUI(InventoryItem item)
        {
            UIIcons[ItemsHolding.Count - 1].GetComponent<Image>().sprite = item.GetIcon();
        }
        public bool AlreadyHasIt(InventoryItem item)
        {
            for (int i = 0; i < ItemsHolding.Count; i++)
            {
                if (object.ReferenceEquals(ItemsHolding[i], item))
                {
                    return true;
                }
            }
            return false;
        }
        public void RemoveItem(InventoryItem item)
        {

        }

        //Get the item from given index 
        public InventoryItem GetItem(int index)
        {
            if (ItemsHolding.ContainsKey(index))
            {
                return ItemsHolding[index];
            }
            return null;
        }

        public bool Use(int index, GameObject user)
        {
            if (ItemsHolding.ContainsKey(index))
            {
                ItemsHolding[index].Use(user);
                return true;
            }
            return false;
        }

        public bool GetPassiveEffect(int index, GameObject user)
        {
            if (ItemsHolding[index].GetData() == null) return false;

            if (ItemsHolding.ContainsKey(index))
            {
                ItemsHolding[index].GetPassiveEffect(user);
                return true;
            }
            return false;
        }
    }
}