using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public abstract class EnemyFish : MonoBehaviour
{
    public float damage = 100;
    public float health = 100;
    protected Transform trans;
    protected Rigidbody2D rb;
    protected SpriteRenderer sr;

    private void Awake()
    {
        trans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        FishMovement();
    }

    public virtual void FishMovement()
    {

    }

    public virtual void initValues(Transform [] _waypoints)
    {
       
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Color initColor = sr.color;
        sr.DOColor(Color.white, 0.05f).OnComplete(() => { sr.DOColor(initColor, 0.05f); }) ;
        if(health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        transform.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Bullet>())
        {
            TakeDamage(collision.GetComponent<Bullet>().damage);
            collision.gameObject.SetActive(false);
        }

    }
}
