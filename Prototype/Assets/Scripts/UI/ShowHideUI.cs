using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.UI
{
    public class ShowHideUI : MonoBehaviour
    {
        [SerializeField] private KeyCode _toggleKey;
        [SerializeField] GameObject _uiContainer = null;
        [SerializeField] private GameObject _levelUpScreen;
        private void Awake()
        {
            _uiContainer.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(_toggleKey))
            {
                Toggle();
            }
        }

        private void Toggle()
        {
            if (_levelUpScreen.activeSelf) return;

            bool isUIVisible = !_uiContainer.activeSelf;
            _uiContainer.SetActive(isUIVisible);

            if (isUIVisible)
            {
                Time.timeScale = 0f; 
            }
            else
            {
                Time.timeScale = 1f;  
            }
        }
    }
}
