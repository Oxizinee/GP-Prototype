using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace IMPossible.Inventory
{
    public class Pickup : MonoBehaviour
    {
        public InventoryItem Item;
        private Inventory _inventory;

        private void Awake()
        {
            _inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                PickUp();
            }
        }

        public void Setup(InventoryItem item)
        {
            Item = item;
        }

        public void PickUp()
        {
            if (_inventory.HasFreeSpace() && !_inventory.AlreadyHasIt(Item))
            {
                _inventory.ItemsHolding.Add(Item);
                print(Item.GetDisplayName() + " has been picked up!");
                Destroy(gameObject);
            }
        }
    }
}
