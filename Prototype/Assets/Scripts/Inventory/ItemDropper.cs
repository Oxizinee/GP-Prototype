using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Inventory
{
    public class ItemDropper : MonoBehaviour
    {
        public void DropItem(InventoryItem item)
        {
            SpawnPickup(item);
         //   GetComponent<Inventory>().RemoveItem(item);
        }

        private void SpawnPickup(InventoryItem item)
        {
            item.SpawnPickup(transform.position);
        }
    }
}