using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{

    Rigidbody2D rb;
    Transform trans;

    public float health = 100;

    float vertSpeed = 0.1f;
    float horSpeed = 0.1f;
    public GameObject[] Bullets;

    private int currentBulletIndex = 0;
    public float shootCooldownTime = 0.1f;

    private float shootCooldownTimer;

    public Transform topBound;
    public Transform leftBound;
    public Transform rightBound;
    public Transform botBound;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInputs();
    }

    void PlayerInputs()
    {
        float xInc = 0;
        float yInc = 0;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if(trans.position.y <= topBound.position.y)
            {
                yInc = vertSpeed;
            }
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (trans.position.y >= botBound.position.y)
            {
                yInc = -vertSpeed;
            }
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (trans.position.x >= leftBound.position.x)
            {
                xInc = -horSpeed;
            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (trans.position.x <= rightBound.position.x)
            {
                xInc = horSpeed;
            }
        }

        rb.MovePosition(new Vector2(trans.position.x + xInc, trans.position.y + yInc));

        shootCooldownTimer += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            if(shootCooldownTimer > shootCooldownTime)
            {
                FireWeapon();
                shootCooldownTimer = 0;
            }
        }
    }

    void FireWeapon()
    {
        Bullets[currentBulletIndex].transform.position = trans.position;
        Bullets[currentBulletIndex].transform.gameObject.SetActive(true);

        if (currentBulletIndex < Bullets.Length - 1)
        {
            currentBulletIndex++;

        }
        else
        {
            currentBulletIndex = 0;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<EnemyFish>())
        {
            TakeDamage(collision.GetComponent<EnemyFish>().damage);
        }

        if(collision.GetComponent<Spike>())
        {
            TakeDamage(collision.GetComponent<Spike>().damage);
        }
    }

    private void TakeDamage(float _damage)
    {
        health -= _damage;

        if(health <= 0)
        {
            trans.gameObject.SetActive(false);
            GameManager.instance.GameOver();
        }
    }
}
