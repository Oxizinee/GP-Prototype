using IMPossible.Ability;
using IMPossible.Inventory;
using IMPossible.UI.Dragging;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace IMPossible.UI.Inventories
{
    [RequireComponent(typeof(Image))]
    public class ItemIconUI : DragItem<InventoryItem>
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
            cooldownOverlay.fillAmount = _cooldownStorage.GetFractionRemaining(GetAbility());
        }

        private AbilityData GetAbility()
        {
            return _inventory.GetAbilityData(_index);
        }
        public void SetItem(InventoryItem item)
        {
            var iconImage = GetComponent<Image>();
            if (item == null)
            {
                iconImage.enabled = false;
            }
            else
            {
                iconImage.enabled = true;
                iconImage.sprite = item.GetIcon();
            }
        }
    }
}
