using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPig : TDestructible
{
    protected override void Awake()
    {
        base.Awake();
        type = 10000;
    }
    public override void Death()
    {
        base.Death();
        TSlingshot.Instance.UnLoadPig(this);
    }

    public override void OnExceedDamage()
    {
        base.OnExceedDamage();
        TAudioManager.Instance.PlayAudio(TAudioType.PigCollision, transform.position);
    }
}
