using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TInputManager : TSingleton<TInputManager>
{

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }
}
