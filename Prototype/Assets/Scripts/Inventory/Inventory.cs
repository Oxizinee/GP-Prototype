using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IMPossible.Inventory
{
    public class Inventory : MonoBehaviour
    {
        // Start is called before the first frame update
        public List<InventoryItem> ItemsHolding;
        public List<GameObject> UIIcons = new List<GameObject>();
        public bool CanUse = true;

        [SerializeField] private int _inventoryMaxSize = 3;

        private void Awake()
        {
            ItemsHolding = new List<InventoryItem>();
            ItemsHolding.Capacity = 3;
        }
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
            if (ItemsHolding[index] != null)
            {
                return ItemsHolding[index];
            }
            return null;
        }

        public bool Use(int index, GameObject user)
        {
            if (ItemsHolding[index] != null)
            {
                ItemsHolding[index].Use(user);
                return true;
            }
            return false;
        }
    }
}