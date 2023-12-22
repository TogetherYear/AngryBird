using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TFinishUI : MonoBehaviour
{
    [SerializeField]
    private Animator at;

    [SerializeField]
    private CanvasGroup[] starts;

    private void Start()
    {
        Invoke("Failed", 2.0f);
    }

    public void Success(int number)
    {
        at.SetInteger("Number", number);
        at.SetBool("Success", true);
    }

    public void Failed()
    {
        // at.SetBool("Failed", true);
        Success(2);
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
