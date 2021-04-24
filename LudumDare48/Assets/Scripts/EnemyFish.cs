using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public abstract class EnemyFish : MonoBehaviour
{
    public float damage = 100;
    public float health = 100;
    public int points = 5;
    protected Transform trans;
    protected Rigidbody2D rb;
    protected SpriteRenderer sr;

    

    private void Awake()
    {
        trans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        CatController.instance.myBombUsed += BombKilled;
    }

    // Update is called once per frame
    void Update()
    {
        FishMovement();

        BoundaryCheck();
    }

    public void BoundaryCheck()
    {
        if(trans.position.x < GameManager.instance.leftBound.position.x - 5)
        {
            Die();
        }
    }

    public virtual void FishMovement()
    {

    }

    public virtual void initValues(Transform [] _waypoints)
    {
       
    }

    public void BombKilled()
    {
        if(gameObject.activeInHierarchy)
        {
            KilledByPlayer();
        }

    }

    public void KilledByPlayer()
    {
        UIManager.instance.UpdatePoints(points);
        Die();
        UpgradeManager.instance.RollForUpgrade(trans.position);

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Color initColor = sr.color;
        sr.DOColor(Color.white, 0.05f).OnComplete(() => { sr.DOColor(initColor, 0.05f); }) ;
        if(health <= 0)
        {
            KilledByPlayer();
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
