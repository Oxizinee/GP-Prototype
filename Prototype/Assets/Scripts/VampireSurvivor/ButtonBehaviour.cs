using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private AblityHolder _abilityHolder;
    public int RandomAbility;
    public Text DescriptionText;
    private XPBar _xpBarScript;
    private bool _isHovered;
    private void OnEnable()
    {
        _abilityHolder = FindAnyObjectByType<AblityHolder>();
        RandomAbility = Random.Range(0, _abilityHolder.LockedAbilities.Count);

        GetComponentInChildren<Text>().text = _abilityHolder.LockedAbilities[RandomAbility].Name;
    }
   

    public void Start()
    {
        _abilityHolder = FindAnyObjectByType<AblityHolder>();
        _xpBarScript = FindAnyObjectByType<XPBar>();
    }

    private void Update()
    {
        if (_isHovered)
        {
            DescriptionText.text = _abilityHolder.LockedAbilities[RandomAbility].Description;
        }
    }
    public void OnButtonClick()
    {

        Ability abilityToUnlock = _abilityHolder.LockedAbilities[GetComponent<ButtonBehaviour>().RandomAbility];

        _abilityHolder.LockedAbilities.Remove(abilityToUnlock);
        _abilityHolder.UnlockedAbilities.Add(abilityToUnlock);

        _xpBarScript.LevelUpMenu.SetActive(false);
        _xpBarScript.Level++;
        _xpBarScript.XPCurrent = 0;
        _xpBarScript.XPMax = _xpBarScript.XPMax + 5;
        Time.timeScale = 1;
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
