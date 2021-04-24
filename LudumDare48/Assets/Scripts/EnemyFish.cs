using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        
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
        sr.color = Color.white;
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
