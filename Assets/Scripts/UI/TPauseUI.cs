using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TPauseUI : MonoBehaviour
{
    [SerializeField]
    private Animator at;

    public void OnPauseClick()
    {
        at.SetBool("Show", true);
        Time.timeScale = 0.0f;
    }

    public void OnPlayClick()
    {
        at.SetBool("Show", false);
        Time.timeScale = 1.0f;
    }

    public void OnRefreshClick()
    {

    }

    public void OnLevelClick()
    {

    }

}
