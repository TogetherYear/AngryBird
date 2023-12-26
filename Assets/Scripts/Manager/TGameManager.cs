using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TGameManager : TSingleton<TGameManager>
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
        InitSetting();
    }

    [SerializeField]
    private TFinishUI finishUI;

    [SerializeField]

    private TPauseUI pauseUI;

    private void InitSetting()
    {
        Application.targetFrameRate = 144;
    }

    public void Success(int number)
    {
        int start = Mathf.Clamp(3 - number, 1, 3);
        finishUI.Success(start);
    }

    public void Failed()
    {
        finishUI.Failed();
    }

    public void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }

    public void RefreshCurrentLevel()
    {

    }

    public void LoadMenuLevel()
    {

    }

    public void LoadNextLevel()
    {

    }
}
