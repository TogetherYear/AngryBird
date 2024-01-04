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

    public TLevelSO levelSO;

    [SerializeField]
    private TFinishUI finishUI;

    [SerializeField]

    private TPauseUI pauseUI;

    [SerializeField]
    private GameObject menu;

    private void InitSetting()
    {
        Application.targetFrameRate = 144;
    }

    public void ShowMenu()
    {
        menu.SetActive(true);
    }

    public void HideMenu()
    {
        menu.SetActive(false);
    }

    public void Success(int number)
    {
        int star = Mathf.Clamp(3 - number, 1, 3);
        finishUI.Success(star);
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
