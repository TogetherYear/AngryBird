using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TFollowTarget : TSingleton<TFollowTarget>
{
    protected override void Awake()
    {
        base.Awake();
    }

    [SerializeField]
    private Transform mCamera;

    private Transform target;

    public float smoothSpeedScale = 2.0f;

    public Vector2 horizontalRange = new Vector2(-16.0f, 48.0f);

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void Update()
    {
        if (target)
        {
            Vector3 position = mCamera.position;
            position.x = Mathf.Clamp(target.position.x, horizontalRange[0], horizontalRange[1]);
            mCamera.position = Vector3.Lerp(mCamera.position, position, Time.deltaTime * smoothSpeedScale);
        }
    }
}
