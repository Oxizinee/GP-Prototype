using IMPossible.Ability;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace IMPossible.UI.Progress
{
    public class AbilityButtonUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public int RandomRune;
        public Text DescriptionText;
        private bool _isHovered;
        private LevelUpScreenUI _levelUpScreenUI;
        private void OnEnable()
        {
            _levelUpScreenUI = GetComponentInParent<LevelUpScreenUI>();

            if (_levelUpScreenUI.GetRuneList().Length != 0)
            {
                RandomRune = Random.Range(0, _levelUpScreenUI.GetRuneList().Length);
                GetComponentInChildren<Text>().text = _levelUpScreenUI.GetRuneName(RandomRune);
            }
        }

        private void Update()
        {
            OnHover();
        }

        private void OnHover()
        {
            if (_isHovered)
            {
                DescriptionText.text = _levelUpScreenUI.GetRuneList()[RandomRune].GetRuneData().RuneDescription;
            }
        }

        public void OnButtonClick()
        {
            Rune runeToUnlock = _levelUpScreenUI.GetRuneList()[RandomRune];
            _levelUpScreenUI.AddRune(runeToUnlock);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _isHovered = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _isHovered = false;
        }
    }
}