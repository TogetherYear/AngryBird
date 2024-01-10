using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void SetLastLevel(int select)
    {
        levelSO.lastSelectLevel = select;
    }

    public void SetLastCheckpoint(int select)
    {
        levelSO.lastSelectCheckpoint = select;
    }

    public void Success(int number)
    {
        int star = Mathf.Clamp(3 - number, 1, 3);
        finishUI.Success(star);
        UpdateCurrentCheckpointStart(star);
    }

    public void Failed()
    {
        finishUI.Failed();
    }

    public void LoadSelectCheckpoint()
    {
        ShowMenu();
        TSceneManager.Instance.LoadScene(TSceneKey.Game);
    }

    public void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }

    public void RefreshCurrentLevel()
    {
        TSceneManager.Instance.RefreshCurrentScene();
        ResetUI();
    }

    public void LoadMenuLevel()
    {
        TSceneManager.Instance.LoadScene(TSceneKey.LevelSelect);
        ResetUI();
    }

    public void LoadNextLevel()
    {
        levelSO.lastSelectCheckpoint = Mathf.Clamp(levelSO.lastSelectCheckpoint + 1, 0, levelSO.levels[levelSO.lastSelectLevel].currentCheckpoint);
        TSceneManager.Instance.RefreshCurrentScene();
        ResetUI();
    }

    private void ResetUI()
    {
        pauseUI.Reset();
        finishUI.Reset();
    }

    public void UpdateCurrentCheckpointStart(int starCount)
    {
        int delta = Mathf.Max(0, starCount - levelSO.levels[levelSO.lastSelectLevel].checkpoints[levelSO.lastSelectCheckpoint].starCount);
        levelSO.levels[levelSO.lastSelectLevel].checkpoints[levelSO.lastSelectCheckpoint].starCount += delta;
        levelSO.levels[levelSO.lastSelectLevel].levelStar += delta;
        levelSO.totalStar += delta;
        if (levelSO.levels[levelSO.lastSelectLevel].currentCheckpoint == levelSO.lastSelectCheckpoint)
        {
            levelSO.levels[levelSO.lastSelectLevel].currentCheckpoint = Mathf.Clamp(levelSO.levels[levelSO.lastSelectLevel].currentCheckpoint + 1, 0, levelSO.levels[levelSO.lastSelectLevel].checkpoints.Count - 1);
        }
    }
}
