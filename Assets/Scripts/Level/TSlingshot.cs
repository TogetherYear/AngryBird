using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TSlingshot : TSingleton<TSlingshot>
{
    protected override void Awake()
    {
        base.Awake();
    }

    [SerializeField]
    private LineRenderer leftLineRenderer;

    [SerializeField]
    private LineRenderer rightLineRenderer;

    [SerializeField]
    private Transform leftOrigin;

    [SerializeField]
    private Transform rightOrigin;

    public Transform origin;

    private TBird dragBird;

    private List<TBird> birds;

    private List<TPig> pigs;

    private int birdIndex = -1;

    private bool isDrawing = false;

    public float maxDistance = 1.6f;

    private void Start()
    {
        ResetDraw();
        HideLineRenderer();
        FindAllBirds();
        FindAllPigs();
        LoadBird();
    }

    private void FindAllBirds()
    {
        birds = FindObjectsByType<TBird>(FindObjectsSortMode.None).ToList();
        birds.Sort((a, b) => Vector3.Distance(a.transform.position, transform.position).CompareTo(Vector3.Distance(b.transform.position, transform.position)));
    }

    private void FindAllPigs()
    {
        pigs = FindObjectsByType<TPig>(FindObjectsSortMode.None).ToList();
    }

    public void LoadBird()
    {
        birdIndex++;
        if (birdIndex < birds.Count)
        {
            birds[birdIndex].Load();
        }
        else
        {
            TGameManager.Instance.Failed();
        }
    }

    public void UnLoadPig(TPig pig)
    {
        pigs.Remove(pig);
        if (pigs.Count < 1)
        {
            TGameManager.Instance.Success();
        }
    }

    public void StartDraw(TBird b)
    {
        dragBird = b;
        isDrawing = true;
        ShowLineRenderer();
    }

    public void EndDraw()
    {
        isDrawing = false;
        ResetDraw();
        HideLineRenderer();
    }

    private void ResetDraw()
    {
        leftLineRenderer.SetPosition(0, leftOrigin.position);
        leftLineRenderer.SetPosition(1, origin.position);
        rightLineRenderer.SetPosition(0, rightOrigin.position);
        rightLineRenderer.SetPosition(1, origin.position);
    }

    private void Draw()
    {
        Vector3 target = GetPositionByDirectionOffset();
        leftLineRenderer.SetPosition(0, leftOrigin.position);
        leftLineRenderer.SetPosition(1, target);
        rightLineRenderer.SetPosition(0, rightOrigin.position);
        rightLineRenderer.SetPosition(1, target);
    }

    private Vector3 GetPositionByDirectionOffset()
    {
        Vector3 direction = (dragBird.transform.position - origin.position).normalized;
        return dragBird.transform.position + direction * dragBird.offset;
    }

    private void Update()
    {
        if (isDrawing)
        {
            Draw();
        }
    }

    private void HideLineRenderer()
    {
        leftLineRenderer.enabled = false;
        rightLineRenderer.enabled = false;
    }

    private void ShowLineRenderer()
    {
        leftLineRenderer.enabled = true;
        rightLineRenderer.enabled = true;
    }


}
