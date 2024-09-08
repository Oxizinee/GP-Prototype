using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Inventory
{
    [CreateAssetMenu(menuName = "Inventory/Item")]
    public class InventoryItem : ScriptableObject
    {
        [SerializeField]private string _itemID = null;
        [SerializeField]private string _displayName = null;
        [SerializeField][TextArea] private string _description = null;
        [SerializeField] private Sprite _icon = null;
        [SerializeField] private Pickup _pickup = null;

        static Dictionary<string, InventoryItem> itemLookupCache;
        public static InventoryItem GetFromID(string itemID)
        {
            if (itemLookupCache == null)
            {
                itemLookupCache = new Dictionary<string, InventoryItem>();
                var itemList = Resources.LoadAll<InventoryItem>("");
                foreach (var item in itemList)
                {
                    if (itemLookupCache.ContainsKey(item._itemID))
                    {
                        Debug.LogError(string.Format("Looks like there's a duplicate GameDevTV.UI.InventorySystem ID for objects: {0} and {1}", itemLookupCache[item._itemID], item));
                        continue;
                    }

                    itemLookupCache[item._itemID] = item;
                }
            }

            if (itemID == null || !itemLookupCache.ContainsKey(itemID)) return null;
            return itemLookupCache[itemID];
        }
        public Pickup SpawnPickup(Vector3 position)
        {
            var pickup = Instantiate(_pickup);
            pickup.transform.position = position;
            pickup.Setup(this);
            return pickup;
        }
        public Sprite GetIcon()
        {
            return _icon;
        }

        public string GetItemID()
        {
            return _itemID;
        }
        public string GetDisplayName()
        {
            return _displayName;
        }
        public string GetDescription()
        {
            return _description;
        }

    }
}