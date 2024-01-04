using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TLevelSO", menuName = "AngryBird/TLevelSO", order = 0)]
public class TLevelSO : ScriptableObject
{
    public List<Level> levels = new List<Level>();

    public int totalStar;
}

[Serializable]
public class Level
{
    public string name;

    public int levelStar;

    public List<Checkpoint> checkpoints = new List<Checkpoint>();

    public int currentCheckpoint;
}

[Serializable]
public class Checkpoint
{
    public int starCount;

    public GameObject prefab;
}