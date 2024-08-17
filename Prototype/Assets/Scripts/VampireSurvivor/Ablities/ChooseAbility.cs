using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        foreach (Ability a in _abilityHolder.Abilities)
        {
            a.State = AbilityState.unlocked;
        }

        _xpBarScript.LevelUpMenu.SetActive(false);
        _xpBarScript.Level++;
        _xpBarScript.XPCurrent = 0;
        _xpBarScript.XPMax = _xpBarScript.XPMax + 5;
        Time.timeScale = 1;


    }
}
