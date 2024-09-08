using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace IMPossible.Inventory
{
    public class PickupSpawner : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private InventoryItem[] _itemsToSpawn;
        private int _randomNumber;
        void Start()
        {
            LoadAllScriptableObjects();

        }

        private void LoadAllScriptableObjects()
        {
            _itemsToSpawn = Resources.LoadAll<InventoryItem>("Items");

            foreach (ScriptableObject scriptableObject in _itemsToSpawn)
            {
                Debug.Log("Loaded ScriptableObject: " + scriptableObject.name);
            }
        }

        public void DropLoot()
        {
            _randomNumber = Random.Range(0, _itemsToSpawn.Length - 1);
            _itemsToSpawn[_randomNumber].SpawnPickup(transform.position);
        }

    }
}
