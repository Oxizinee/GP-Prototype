using IMPossible.Ability;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace IMPossible.Inventory
{
    public class Inventory : MonoBehaviour
    {
        // Start is called before the first frame update
        public InventoryItem[] ItemsHolding;
        public bool CanUse = true;

        private int _inventorySize = 3;

        private void Awake()
        {
            ItemsHolding = new InventoryItem[_inventorySize];
        }
        public bool AlreadyHasIt(InventoryItem item)
        {
            for (int i = 0; i < ItemsHolding.Length; i++)
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
            if (ItemsHolding.GetValue(index) != null)
            {
                return ItemsHolding[index];
            }
            return null;
        }

        public AbilityData GetAbilityData(int index)
        {
            if (ItemsHolding.GetValue(index) != null)
            {
                return ItemsHolding[index].GetData();
            }
            return null;
        }


        public bool Use(int index, GameObject user)
        {
            if (ItemsHolding.GetValue(index) != null)
            {
                ItemsHolding[index].Use(user);
                return true;
            }
            return false;
        }

        public bool GetPassiveEffect(int index, GameObject user)
        {
            if (GetAbilityData(index) == null) return false;

            if (ItemsHolding.GetValue(index) != null)
            {
                ItemsHolding[index].GetPassiveEffect(user);
                return true;
            }
            return false;
        }

        public bool AddItemToSlot(int slot, InventoryItem item)
        {
            if (ItemsHolding[slot] != null)
            {
                return AddToFirstEmptySlot(item);
            }
            return true;
        }
        public bool AddToFirstEmptySlot(InventoryItem item)
        {
            int i = FindEmptySlot();

            if (i < 0)
            {
                return false;
            }

            ItemsHolding[i] = item;
            return true;
        }
        private int FindEmptySlot()
        {
            for (int i = 0; i < ItemsHolding.Length; i++)
            {
                if (ItemsHolding[i] == null)
                {
                    return i; 
                }
            }
            return -1; // returns -1 if all slots are full
        }
    }
}