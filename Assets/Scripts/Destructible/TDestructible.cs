using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDestructible : MonoBehaviour
{
    [SerializeField]
    private int maxHP = 20;

    private int currentHP;

    [SerializeField]
    private List<Sprite> injuredSpriteList;

    [SerializeField]
    private SpriteRenderer sr;

    [SerializeField]
    private GameObject boomPrefab;

    private int currentInjuredIndex;

    private void Start()
    {
        currentHP = maxHP;
        UpdateSprite();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        AttachDamage((int)other.relativeVelocity.magnitude);
    }

    private void GenerateBoom()
    {
        if (boomPrefab)
        {
            GameObject boom = Instantiate(boomPrefab, transform.position, Quaternion.identity);
        }
    }

    private void UpdateSprite()
    {
        if (injuredSpriteList.Count != 0)
        {
            int index = (maxHP - currentHP) / (maxHP / injuredSpriteList.Count);
            sr.sprite = injuredSpriteList[Mathf.Clamp(index, 0, injuredSpriteList.Count - 1)];
            if (currentInjuredIndex != index)
            {
                currentInjuredIndex = index;
                OnExceedDamage();
            }
        }
        else
        {
            Death();
        }
    }

    public void AttachDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP < 1)
        {
            Death();
        }
        else
        {
            UpdateSprite();
        }
    }

    public virtual void Death()
    {
        GenerateBoom();
        Destroy(gameObject);
    }

    public virtual void OnExceedDamage()
    {

    }
}
