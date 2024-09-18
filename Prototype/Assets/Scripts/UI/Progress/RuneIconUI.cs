using IMPossible.Ability;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IMPossible.UI.Progress
{
    public class RuneIconUI : MonoBehaviour
    {
        private RuneStorage _runeStorage;
        [SerializeField] private int _index;
        [SerializeField] private GameObject _levelContainer = null;
        [SerializeField] private TextMeshProUGUI _levelNumber = null;

        public void Setup(RuneStorage runeStorage, int index)
        {
            _runeStorage = runeStorage;
            _index = index;
            SetItem(GetRune(), GetLevelOFRune());

        }

        private int GetLevelOFRune()
        {
            return _runeStorage.GetLevelInSlot(_index);
        }
        private Rune GetRune()
        {
            return _runeStorage.GetRune(_index);
        }
        private void SetItem(Rune rune, int level)
        {
            var iconImage = GetComponent<Image>();
            if (rune == null)
            {
                iconImage.enabled = false;
            }
            else
            {
                iconImage.enabled = true;
                iconImage.sprite = rune.GetIcon();
            }

            if (_levelNumber)
            {
                if (level <= 1)
                {
                    _levelContainer.SetActive(false);
                }
                else
                {
                    _levelContainer.SetActive(true);
                    _levelNumber.text = level.ToString();
                    
                }
            }
        }
    }
}
