using IMPossible.Ability;
using UnityEngine;

namespace IMPossible.UI.Progress
{
    public class RuneStoargeUI : MonoBehaviour
    {
        private RuneStorage _runeStorage;
        [SerializeField]private RuneIconUI[] _runeSlots;
        private void Awake()
        {
            _runeStorage = GameObject.FindWithTag("Player").GetComponent<RuneStorage>();

            _runeSlots = GetComponentsInChildren<RuneIconUI>();

            _runeStorage.OnStorageChanged += UpdateStorage;
        }
        private void Start()
        {
            UpdateStorage();
        }
        private void UpdateStorage()
        {
            for (int i = 0; i < _runeSlots.Length; i++)
            {
                _runeSlots[i].Setup(_runeStorage, i);
            }
        }

    }
}
