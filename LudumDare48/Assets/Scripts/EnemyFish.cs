using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyFish : MonoBehaviour
{

    public float health = 100;
    private Transform trans;
    private Rigidbody2D rb;

    private void Awake()
    {
        trans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
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

    public void FishMovement()
    {

    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health < 0)
        {
            Die();
        }
    }

    public void Die()
    {
        transform.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TakeDamage(collision.GetComponent<Bullet>().damage);
        collision.gameObject.SetActive(false);
    }
}
