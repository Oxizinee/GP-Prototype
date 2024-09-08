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
            //if (other.gameObject.tag == "Player" && other.GetComponent<ItemHolder>().ItemsHolding.Count <= 3 && !other.GetComponent<ItemHolder>().ItemsHolding.Contains(Item))
            //{
            //    other.GetComponent<ItemHolder>().ItemsHolding.Add(Item);
            //    Destroy(gameObject);
            //}
        }

        public void Setup(InventoryItem item)
        {
            Item = item;
        }
    }
}
