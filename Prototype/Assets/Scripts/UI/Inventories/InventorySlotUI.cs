using IMPossible.Inventory;
using UnityEngine;

namespace IMPossible.UI.Inventories
{
    public class InventorySlotUI : MonoBehaviour
    {
        [SerializeField] private ItemIconUI _icon = null;

        private Inventory.Inventory _inventory;
        public void AddItem(InventoryItem item)
        {
           // _inventory.AddItemToSlot(item);
        }
    }
}
