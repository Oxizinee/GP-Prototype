using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRunner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PauseScreen;
    private bool _isPaused;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isPaused = !_isPaused;
        }

        if (_isPaused)
        {
            PauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            PauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
