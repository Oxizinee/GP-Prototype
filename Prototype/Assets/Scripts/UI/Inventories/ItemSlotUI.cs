using IMPossible.Inventory;
using System;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

namespace IMPossible.UI.Inventories
{
    public class ItemSlotUI :MonoBehaviour
    {
        [SerializeField] int _index = 0;
        [SerializeField] private Image cooldownOverlay = null;

        private  IMPossible.Inventory.Inventory _inventory;
        private CooldownStorage _cooldownStorage;
        private void Awake()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            _inventory = player.GetComponent<IMPossible.Inventory.Inventory>();
            _cooldownStorage = player.GetComponent<CooldownStorage>();
        }
        private void Update()
        {
            cooldownOverlay.fillAmount = _cooldownStorage.GetFractionRemaining(GetItem());
        }

        private InventoryItem GetItem()
        {
            return _inventory.GetItem( _index );
        }
    }
}
