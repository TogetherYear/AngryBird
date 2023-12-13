using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBigWood : TDestructible
{
    public override void OnExceedDamage()
    {
        base.OnExceedDamage();
        TAudioManager.Instance.PlayAudio(TAudioType.WoodCollision, transform.position);
    }

    public override void Death()
    {
        base.Death();
        TAudioManager.Instance.PlayAudio(TAudioType.WoodDestroyed, transform.position);
    }
}
