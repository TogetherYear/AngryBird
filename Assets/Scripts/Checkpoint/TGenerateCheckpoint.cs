using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TGenerateCheckpoint : MonoBehaviour
{
    private void Awake()
    {
        GameObject go = Instantiate(TGameManager.Instance.levelSO.levels[TGameManager.Instance.levelSO.lastSelectLevel].checkpoints[TGameManager.Instance.levelSO.lastSelectCheckpoint].prefab);
        go.transform.SetParent(transform);
    }
}
