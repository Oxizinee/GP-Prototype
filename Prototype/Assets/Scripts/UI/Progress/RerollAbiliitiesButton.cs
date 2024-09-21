using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.UI.Progress
{
    public class RerollAbilitiesButton : MonoBehaviour
    {
         private AbilityButtonUI[] _listOfButtons;
        private int _rerollsMade;
        public void OnClick()
        {
            if (_rerollsMade < 3)
            {
                foreach (var button in _listOfButtons)
                {
                    button.AssignRune();
                }
                _rerollsMade++;
            }
        }
        private void OnEnable()
        {
            _rerollsMade = 0;
            _listOfButtons = FindObjectsByType<AbilityButtonUI>(FindObjectsSortMode.None);
        }
    }
}