using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TExplodeBird : TBird
{
    [SerializeField]
    private float boomRadius = 2.5f;

    [SerializeField]
    private float forceScale = 20.0f;
    protected override void FlyingSkillControl()
    {
        base.FlyingSkillControl();
    }

    protected override void CollisionSkillControl()
    {
        base.CollisionSkillControl();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, boomRadius);
        foreach (var c in colliders)
        {
            TDestructible d = c.GetComponent<TDestructible>();
            if (d)
            {
                Rigidbody2D rb = d.GetComponent<Rigidbody2D>();
                if (rb)
                {
                    rb.AddForce((c.transform.position - transform.position).normalized * forceScale, ForceMode2D.Impulse);
                }
            }
        }
    }
}
