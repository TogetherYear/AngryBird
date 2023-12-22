using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TFinishUI : MonoBehaviour
{
    [SerializeField]
    private Animator at;

    [SerializeField]
    private CanvasGroup leftStart;

    [SerializeField]
    private CanvasGroup midStart;

    [SerializeField]
    private CanvasGroup rightStart;

    public void Success()
    {
        at.SetBool("Success", true);
    }

    public void Failed()
    {
        at.SetBool("Success", false);
    }

    public void OnRefreshClick()
    {

    }

    public void OnLevelClick()
    {

    }

    public void OnNextClick()
    {

    }
}
