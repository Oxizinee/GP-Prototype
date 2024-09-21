using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace IMPossible.UI
{
    public class GameTimerUI : MonoBehaviour
    {
        private TextMeshProUGUI _text;
        private float _timer;
        void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        // Update is called once per frame
        void Update()
        {
            _timer += Time.deltaTime;
                
            int minutes = Mathf.FloorToInt(_timer / 60); // Get total minutes
            int seconds = Mathf.FloorToInt(_timer % 60); // Get the remaining seconds

            _text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}