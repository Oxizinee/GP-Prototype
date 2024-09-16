using IMPossible.Inventory;
using IMPossible.UI.Dragging;
using UnityEngine;

namespace IMPossible.UI.Inventories
{
    public class InventoryDropTarget : MonoBehaviour, IDragDestination<InventoryItem>
    {
        public void AddItem(InventoryItem item)
        {
            print("Drop item " + item);
            var player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<ItemDropper>().DropItem(item);
        }

        public int MaxAcceptable(InventoryItem item)
        {
            return int.MaxValue;
        }
    }
}
