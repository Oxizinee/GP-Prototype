using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace IMPossible.UI.Inventories
{
    public class InventoryUI :MonoBehaviour
    {
        private Inventory.Inventory _playerInventory;
       [SerializeField] private InventorySlotUI[] _inventorySlots; 
        private void Awake()
        {
            _playerInventory = GameObject.FindWithTag("Player").GetComponent<Inventory.Inventory>();

            _inventorySlots = GetComponentsInChildren<InventorySlotUI>();

            _playerInventory.OnInventoryChanged += UpdateInventory;
        }
        private void Start()
        {
            UpdateInventory();
        }
        private void UpdateInventory()
        {
            for (int i = 0; i < _inventorySlots.Length; i++)
            {
                _inventorySlots[i].Setup(_playerInventory, i);
            }
        }

    }
}
