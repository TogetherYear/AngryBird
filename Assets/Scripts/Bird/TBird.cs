using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum TBirdState
{
    Waiting,
    BeforeShoot,
    AfterShoot,
    Flying,
    Death,
}

public class TBird : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    /// <summary>
    /// 当前状态
    /// </summary>
    public TBirdState state = TBirdState.Waiting;

    /// <summary>
    /// 是否聚焦
    /// </summary>
    private bool isFocus = false;

    [SerializeField]
    protected Rigidbody2D rb;

    public float flySpeed = 15.0f;

    public float offset = 0.1f;

    public float angularDrag = 10.0f;

    private bool isCollision = false;

    private bool isFlySkill = false;

    private bool isCollisionSkill = false;

    [SerializeField]
    private GameObject boomPrefab;

    private void Awake()
    {
        state = TBirdState.Waiting;
    }

    private void Start()
    {
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void Update()
    {
        switch (state)
        {
            case TBirdState.Waiting: OnWaiting(); return;
            case TBirdState.BeforeShoot: OnBeforeShoot(); return;
            case TBirdState.AfterShoot: OnAfterShoot(); return;
            case TBirdState.Flying: OnFlying(); return;
            default: return;
        }
    }

    /// <summary>
    /// 等待状态
    /// </summary>
    public virtual void OnWaiting() { }

    /// <summary>
    /// 在弹弓中蓄力
    /// </summary>
    public virtual void OnBeforeShoot() { }

    /// <summary>
    /// 飞出弹弓 只有一瞬间
    /// </summary>
    public virtual void OnAfterShoot()
    {
        state = TBirdState.Flying;
    }

    /// <summary>
    /// 飞行中
    /// </summary>
    public virtual void OnFlying()
    {
        CalculateVelocity();
        SkillControl();
    }

    private void SkillControl()
    {
        if (TExtensionTool.IsUserHold())
        {
            if (isCollision)
            {
                if (!isCollisionSkill)
                {
                    CollisionSkillControl();
                    isCollisionSkill = true;
                }

            }
            else
            {
                if (!isFlySkill)
                {
                    FlyingSkillControl();
                    isFlySkill = true;
                }
            }
        }
    }

    protected virtual void FlyingSkillControl()
    {

    }

    protected virtual void CollisionSkillControl()
    {

    }

    /// <summary>
    /// 发射
    /// </summary>
    public virtual void Shoot()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.angularDrag = angularDrag;
        float scale = Vector3.Distance(TSlingshot.Instance.origin.position, transform.position) / TSlingshot.Instance.maxDistance;
        rb.velocity = (TSlingshot.Instance.origin.position - transform.position).normalized * flySpeed * scale;
        state = TBirdState.AfterShoot;
        TAudioManager.Instance.PlayAudio(TAudioType.BirdFlying, transform.position);
    }

    public void OnDrag(PointerEventData e)
    {
        if (state == TBirdState.BeforeShoot && isFocus)
        {
            Vector3 position = e.position.GetWorldPosition();
            if (Vector3.Distance(position, TSlingshot.Instance.origin.position) < TSlingshot.Instance.maxDistance)
            {
                transform.position = position;
            }
            else
            {
                Vector3 direction = (position - TSlingshot.Instance.origin.position).normalized;
                transform.position = TSlingshot.Instance.origin.position + direction * TSlingshot.Instance.maxDistance;
            }
        }
    }

    public void OnPointerDown(PointerEventData e)
    {
        if (state == TBirdState.BeforeShoot)
        {
            isFocus = true;
            TSlingshot.Instance.StartDraw(this);
        }
    }

    public void OnPointerUp(PointerEventData e)
    {
        if (state == TBirdState.BeforeShoot)
        {
            isFocus = false;
            TSlingshot.Instance.EndDraw();
            Shoot();
        }
    }

    public void Load()
    {
        state = TBirdState.BeforeShoot;
        transform.position = TSlingshot.Instance.origin.position;
        TFollowTarget.Instance.SetTarget(transform);
        TAudioManager.Instance.PlayAudio(TAudioType.BirdSelect, transform.position);
    }

    private void CalculateVelocity()
    {
        if (rb.velocity.magnitude < 0.1f)
        {
            state = TBirdState.Death;
            Invoke("Death", 1.0f);
        }
    }

    public virtual void Death()
    {
        Destroy(gameObject);
        GenerateBoom();
        TSlingshot.Instance.LoadBird();
    }

    private void GenerateBoom()
    {
        if (boomPrefab)
        {
            GameObject boom = Instantiate(boomPrefab, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (state == TBirdState.Flying)
        {
            isCollision = true;
            if (other.relativeVelocity.magnitude > 8.0f)
            {
                TAudioManager.Instance.PlayAudio(TAudioType.BirdCollision, transform.position);
            }
        }
    }

}


