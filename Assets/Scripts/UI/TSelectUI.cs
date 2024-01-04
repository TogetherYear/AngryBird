using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSelectUI : TSingleton<TSelectUI>
{
    public GameObject levelUI;

    public GameObject checkpointUI;

    public Transform checkpointParent;

    public List<TLevelUI> levels = new List<TLevelUI>();

    public List<TCheckpointUI> checkpoints = new List<TCheckpointUI>();

    public GameObject checkpointPrefab;

    private void Start()
    {
        TGameManager.Instance.HideMenu();
        ShowLevel();
    }

    public void RefreshLevel()
    {
        foreach (TLevelUI l in levels)
        {
            l.Show(TGameManager.Instance.levelSO.totalStar);
        }
    }

    public void RefreshCheckpoint(int selectLevel)
    {
        if (checkpointParent.childCount > 0)
        {
            for (int i = 0; i < checkpointParent.childCount; i++)
            {
                Destroy(checkpointParent.GetChild(i).gameObject);
            }
        }
        checkpoints.Clear();
        for (int i = 0; i < TGameManager.Instance.levelSO.levels[selectLevel].checkpoints.Count; i++)
        {
            TCheckpointUI cp = Instantiate(checkpointPrefab).GetComponent<TCheckpointUI>();
            checkpoints.Add(cp);
            cp.SetDefaultValues(i);
            cp.Show(TGameManager.Instance.levelSO.levels[selectLevel].currentCheckpoint, TGameManager.Instance.levelSO.levels[selectLevel].checkpoints[i].starCount);
            cp.transform.SetParent(checkpointParent);
        }
    }

    public void ShowLevel()
    {
        levelUI.SetActive(true);
        checkpointUI.SetActive(false);
        RefreshLevel();
    }

    public void ShowCheckPoint(int selectLevel)
    {
        levelUI.SetActive(false);
        checkpointUI.SetActive(true);
        RefreshCheckpoint(selectLevel);
    }

    public void OnBackClick()
    {
        ShowLevel();
    }

}
