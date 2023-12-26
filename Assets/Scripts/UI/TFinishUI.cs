using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TFinishUI : MonoBehaviour
{
    [SerializeField]
    private Animator at;

    [SerializeField]
    private CanvasGroup[] starts;

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
}
