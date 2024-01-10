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
        TGameManager.Instance.SetTimeScale(0.0f);
    }

    public void OnPlayClick()
    {
        at.SetBool("Show", false);
        TGameManager.Instance.SetTimeScale(1.0f);
    }

    public void OnRefreshClick()
    {
        TGameManager.Instance.RefreshCurrentLevel();
    }

    public void OnLevelClick()
    {
        TGameManager.Instance.LoadMenuLevel();
    }

    public void Reset()
    {
        at.SetBool("Show", false);
        TGameManager.Instance.SetTimeScale(1.0f);
    }

}
