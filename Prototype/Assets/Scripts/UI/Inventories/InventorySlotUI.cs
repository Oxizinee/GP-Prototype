using IMPossible.Inventory;
using IMPossible.UI.Dragging;
using System.Xml.Serialization;
using UnityEngine;

namespace IMPossible.UI.Inventories
{
    public class InventorySlotUI : MonoBehaviour, IDragContainer<InventoryItem>
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

        public InventoryItem GetItem()
        {
            return _inventory.GetItem(_index);
        }

        public void RemoveItem()
        {
            _inventory.RemoveItem(_index);
        }

        public int MaxAcceptable(InventoryItem item)
        {
           if (_inventory.HasSpaceFor())
            {
                return int.MaxValue;
            }
            return 0;
        }

    }
}
