using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.UI.Progress
{
    public class RerollAbilitiesButton : MonoBehaviour
    {
         private AbilityButtonUI[] _listOfButtons;
        public void OnClick()
        {
            foreach (var button in _listOfButtons)
            {
                button.AssignRune();
            }
        }
        private void OnEnable()
        {
            _listOfButtons = FindObjectsByType<AbilityButtonUI>(FindObjectsSortMode.None);
        }
    }
}