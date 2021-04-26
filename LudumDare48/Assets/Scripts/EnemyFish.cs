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
    protected Animator anim;
    protected ParticleSystem ps;
    

    private void Awake()
    {
        trans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        if(trans.childCount > 0)
        {
            ps = trans.Find("DeathParticles").GetComponent<ParticleSystem>();

        }

        if (GetComponent<Animator>())
        {
            anim = GetComponent<Animator>();
        }

        CatController.instance.myBombUsed += BombKilled;
    }

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        FishMovement();

        BoundaryCheck();
    }

    public void BoundaryCheck()
    {
        if(trans.position.x < GameManager.instance.leftBound.position.x - 6)
        {
            Die();
        }
    }

    public virtual void FishMovement()
    {

    }

    public virtual void initValues(Transform [] _waypoints)
    {
        gameObject.SetActive(true);
        if(ps)
        {
            ps.transform.parent = trans;
            ps.transform.localPosition = Vector3.zero;
            ps.gameObject.SetActive(false);
        }
  
    }

    public virtual void BombKilled()
    {
        if(gameObject.activeInHierarchy)
        {
            KilledByPlayer();
        }

    }

    public void KilledByPlayer()
    {
        Die();

        UIManager.instance.UpdatePoints(points);
        UpgradeManager.instance.RollForUpgrade(trans.position);

    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        Color initColor = sr.color;
        sr.DOColor(Color.red, 0.05f).OnComplete(() => { sr.DOColor(initColor, 0.05f); }) ;
        if(health <= 0)
        {
            KilledByPlayer();
        }
    }

    public virtual void Die()
    {
        transform.gameObject.SetActive(false);
        if(ps != null)
        {
            ps.transform.parent = null;
            ps.transform.localScale = Vector3.one;

            ps.gameObject.SetActive(true);
            ps.Play();
        }
       

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
