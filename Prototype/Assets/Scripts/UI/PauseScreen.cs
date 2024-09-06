using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public Text AvaiableAbilitiesText;
    private AblityHolder _abilityHolder;
    private string abilities;
    private void OnEnable()
    {
        _abilityHolder = FindFirstObjectByType<AblityHolder>();

        AvaiableAbilitiesText.text = string.Join(",", _abilityHolder.UnlockedAbilities);

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
