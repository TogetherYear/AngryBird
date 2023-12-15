using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAccelerateBird : TBird
{
    protected override void FlyingSkillControl()
    {
        base.FlyingSkillControl();
        rb.velocity *= 2;
    }

    protected override void CollisionSkillControl()
    {
        base.CollisionSkillControl();
    }
}
