using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSelectUI : TSingleton<TSelectUI>
{
    public GameObject levelUI;

    public GameObject checkpointUI;

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
        if (checkpointUI.transform.childCount > 0)
        {
            for (int i = 0; i < checkpointUI.transform.childCount; i++)
            {
                Destroy(checkpointUI.transform.GetChild(i).gameObject);
            }
        }
        checkpoints.Clear();
        for (int i = 0; i < TGameManager.Instance.levelSO.levels[selectLevel].checkpoints.Count; i++)
        {
            TCheckpointUI cp = Instantiate(checkpointPrefab).GetComponent<TCheckpointUI>();
            checkpoints.Add(cp);
            cp.SetDefaultValues(i);
            cp.Show(TGameManager.Instance.levelSO.levels[selectLevel].currentCheckpoint, TGameManager.Instance.levelSO.levels[selectLevel].checkpoints[i].starCount);
            cp.transform.SetParent(checkpointUI.transform);
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
}
