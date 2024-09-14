using IMPossible.Ability;
using IMPossible.Stats;
using IMPossible.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.UI.Progress
{
    public class LevelUpScreenUI : MonoBehaviour
    {
        [SerializeField] private Rune[] _runesToUnlock;
        private RuneStorage _runeHolder;
        private BaseStats _baseStats; 
        private void Awake()
        {
            LoadAllRunes();
            _baseStats = GameObject.FindGameObjectWithTag("Player").GetComponent<BaseStats>();
            _baseStats.OnLevelUp += ShowLevelUpScreen;
            _runeHolder = GameObject.FindGameObjectWithTag("Player").GetComponent<RuneStorage>();
            gameObject.SetActive(false);
        }
        private void ShowLevelUpScreen()
        {
            Time.timeScale = 0f;
            gameObject.SetActive(true);
        }

        private void LoadAllRunes()
        {
            _runesToUnlock = Resources.LoadAll<Rune>("Runes");

            foreach (Rune go in _runesToUnlock)
            {
                Debug.Log("Loaded ScriptableObject: " + go.name);
            }
        }

        public Rune[] GetRuneList()
        {
            return _runesToUnlock;
        }

        private void HideLevelUpScreen()
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }

        public void AddRune(Rune rune)
        {
            _runeHolder.AddRune(rune);
            HideLevelUpScreen();
        }
    }
}
