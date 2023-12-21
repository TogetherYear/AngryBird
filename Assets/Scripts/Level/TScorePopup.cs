using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TScorePopup : TSingleton<TScorePopup>
{
    protected override void Awake()
    {
        base.Awake();
    }

    public GameObject scorePrefab;

    public List<Sprite> sprites3000;

    public List<Sprite> sprites10000;

    private Dictionary<int, List<Sprite>> scoreDict = new Dictionary<int, List<Sprite>>();

    private void Start()
    {
        scoreDict.Add(3000, sprites3000);
        scoreDict.Add(10000, sprites10000);
    }

    public void GenerateScore(Vector3 position, int type)
    {
        if (scorePrefab)
        {
            GameObject score = Instantiate(scorePrefab, position, Quaternion.identity);
            List<Sprite> current;
            if (scoreDict.TryGetValue(type, out current))
            {
                score.GetComponent<SpriteRenderer>().sprite = current[Random.Range(0, current.Count)];
                Destroy(score, 1.0f);
            }

        }
    }
}
