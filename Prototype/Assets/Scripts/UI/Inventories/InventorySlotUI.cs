using IMPossible.Inventory;
using System.Xml.Serialization;
using UnityEngine;

namespace IMPossible.UI.Inventories
{
    public class InventorySlotUI : MonoBehaviour
    {
        [SerializeField] private ItemIconUI _icon = null;

        private Inventory.Inventory _inventory;
        [SerializeField] private int _index;

        public void Setup(Inventory.Inventory inventory, int index)
        {
            _inventory = inventory;
            _index = index;
            _icon.SetItem(_inventory.GetItem(index));
        }
        public void AddItem(InventoryItem item)
        {
            _inventory.AddItemToSlot(_index, item);
        }


    }
}
