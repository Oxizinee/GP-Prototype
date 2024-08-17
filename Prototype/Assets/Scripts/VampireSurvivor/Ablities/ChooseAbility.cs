using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseAbility : MonoBehaviour
{
    private AblityHolder _abilityHolder;
    private XPBar _xpBarScript;

    public void Start()
    {
        _abilityHolder = FindAnyObjectByType<AblityHolder>();
        _xpBarScript = FindAnyObjectByType<XPBar>();
    }

    public void OnButtonClick()
    {

        Ability abilityToUnlock = _abilityHolder.LockedAbilities[gameObject.GetComponent<ButtonBehaviour>().RandomAbility];

        _abilityHolder.LockedAbilities.Remove(abilityToUnlock);
        _abilityHolder.UnlockedAbilities.Add(abilityToUnlock);

        _xpBarScript.LevelUpMenu.SetActive(false);
        _xpBarScript.Level++;
        _xpBarScript.XPCurrent = 0;
        _xpBarScript.XPMax = _xpBarScript.XPMax + 5;
        Time.timeScale = 1;
    }

}
