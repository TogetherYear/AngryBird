using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRotateBird : TBird
{
    protected override void FlyingSkillControl()
    {
        base.FlyingSkillControl();
        rb.velocity = (TExtensionTool.GetUserHoldPosition().GetWorldPosition() - transform.position).normalized * flySpeed;
    }

    protected override void CollisionSkillControl()
    {
        base.CollisionSkillControl();
    }
}
