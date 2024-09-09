using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathButton : MonoBehaviour
{
  //  public Path PathToChoose;
    //private ChoosenPathHolder _choosenPathHolder;

    void Start()
    {
    //    _choosenPathHolder = FindAnyObjectByType<ChoosenPathHolder>();
    }

    public void OnButtonClick()
    {
        //if (PathToChoose != null)
        //{
        //    _choosenPathHolder.Path = PathToChoose;
        //}
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
