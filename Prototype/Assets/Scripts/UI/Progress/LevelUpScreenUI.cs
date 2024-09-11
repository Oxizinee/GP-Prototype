using IMPossible.Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.UI.Progress
{
    public class LevelUpScreenUI : MonoBehaviour
    {
        private BaseStats _baseStats; 
        private void Awake()
        {
            _baseStats = GameObject.FindGameObjectWithTag("Player").GetComponent<BaseStats>();
            _baseStats.OnLevelUp += ShowLevelUpScreen;
            gameObject.SetActive(false);
        }
        private void ShowLevelUpScreen()
        {
            Time.timeScale = 0f;
            gameObject.SetActive(true);
        }
    }
}
