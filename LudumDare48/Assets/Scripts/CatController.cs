using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CatController : MonoBehaviour
{
    public static CatController instance;
    Rigidbody2D rb;
    Transform trans;
    private Animator anim;
    public float health = 100;

    float vertSpeed = 0.1f;
    float horSpeed = 0.1f;
    public GameObject[] Bullets;
    public ParticleSystem[] Bombs;

    private int currentBulletIndex = 0;
    private int currentBombIndex = 0;

    public float shootCooldownTime = 0.1f;

    private float shootCooldownTimer;

    public Transform barrelLoc;

    public int bombCount;

    public delegate void BombUsed();
    public BombUsed myBombUsed;

    public float invulnTime = 0.25f;

    private SpriteRenderer sr;
    private SkinnedMeshRenderer skrBubble;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        skrBubble = GetComponentInChildren<SkinnedMeshRenderer>();
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInputs();

        invulnTime -= Time.deltaTime;

        //Debug.Log(100 * Mathf.Sin(Time.time));
        skrBubble.SetBlendShapeWeight(0, Mathf.Abs( 100 * Mathf.Sin(Time.time)));
    }

    void PlayerInputs()
    {
        float xInc = 0;
        float yInc = 0;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if(trans.position.y <= GameManager.instance.topBound.position.y)
            {
                yInc = vertSpeed;
            }
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (trans.position.y >= GameManager.instance.botBound.position.y)
            {
                yInc = -vertSpeed;
            }
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (trans.position.x >= GameManager.instance.leftBound.position.x)
            {
                xInc = -horSpeed;
            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (trans.position.x <= GameManager.instance.rightBound.position.x)
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

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            if (bombCount > 0)
            {
                UseBomb();
            }
        }
    }

    void FireWeapon()
    {
        AudioManager.instance.PlayClip(AudioManager.instance.shoot, 1);
        Bullets[currentBulletIndex].transform.position = barrelLoc.position;
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

    void UseBomb()
    {
        bombCount--;
        AudioManager.instance.PlayClip(AudioManager.instance.bomb, 1);

        if (currentBombIndex < Bombs.Length - 1)
        {
            currentBombIndex++;

        }
        else
        {
            currentBombIndex = 0;

        }
        UIManager.instance.UpdateBombCount(bombCount);

        Bombs[currentBombIndex].transform.position = trans.position;
        Bombs[currentBombIndex].gameObject.SetActive(true);
        Bombs[currentBombIndex].Play();
        if (myBombUsed != null)
        {
            myBombUsed();
        }        //myBombUsed();

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
        if(invulnTime <= 0)
        {
            AudioManager.instance.PlayClip(AudioManager.instance.hit, 1);

            health -= _damage;

            if (health <= 0)
            {
                trans.gameObject.SetActive(false);
                GameManager.instance.GameOver();
                skrBubble.gameObject.SetActive(false);

            }
            else
            {
                anim.SetTrigger("hit");
                sr.DOColor(Color.red, 0.1f).OnComplete(() => { sr.DOColor(Color.white, 0.1f); });
                invulnTime = 0.25f;

                skrBubble.SetBlendShapeWeight(1, health);
                
            }
        }
       
    }

    public void UpgradePickedUp(int _type)
    {
        AudioManager.instance.PlayClip(AudioManager.instance.bubble, 1);

        if (_type == 0)//bomb
        {
            bombCount++;
            UIManager.instance.UpdateBombCount(bombCount);
        }
        if (_type == 1)//bubbles
        {
            health = Mathf.Min(100,  health + 50);
            skrBubble.SetBlendShapeWeight(1, health);

        }
    }
}
