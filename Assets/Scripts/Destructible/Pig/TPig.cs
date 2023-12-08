using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPig : TDestructible
{
    public override void Death()
    {
        base.Death();
        TSlingshot.Instance.UnLoadPig(this);
    }
}
