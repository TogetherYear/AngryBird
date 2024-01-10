using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TFinishUI : MonoBehaviour
{
    [SerializeField]
    private Animator at;

    [SerializeField]
    private CanvasGroup[] stars;

    public void Success(int number)
    {
        at.SetInteger("Number", number);
        at.SetBool("Success", true);
    }

    public void Failed()
    {
        at.SetBool("Failed", true);
    }

    public void OnRefreshClick()
    {
        TGameManager.Instance.RefreshCurrentLevel();
    }

    public void OnLevelClick()
    {
        TGameManager.Instance.LoadMenuLevel();
    }

    public void OnNextClick()
    {
        TGameManager.Instance.LoadNextLevel();
    }

    public void Reset()
    {
        at.SetBool("Success", false);
        at.SetBool("Failed", false);
        at.SetInteger("Number", 0);
    }
}
