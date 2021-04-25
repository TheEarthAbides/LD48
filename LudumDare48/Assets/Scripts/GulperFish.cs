using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GulperFish : EnemyFish
{
    public float idleHorSpeed;
    public float idleVertSpeed;
    public float chargeSpeed = 0.1f;
    private Animator anim;
    bool charging;
    Vector3 chargeDirection;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FishMovement();

        BoundaryCheck();

    }
    public override void FishMovement()
    {
        if(!charging)
        {
            rb.MovePosition(new Vector2(trans.position.x + idleHorSpeed, trans.position.y + idleVertSpeed));

            if (trans.position.x < 3.5)
            {
                ChargePlayer();

            }

        }
        else
        {
            rb.MovePosition(new Vector2(trans.position.x + chargeDirection.x * chargeSpeed, trans.position.y + chargeDirection.y * chargeSpeed));
            RotateToPlayer();

        }


    }

    public void RotateToPlayer()
    {
        float offset = 180;
        float angle = Mathf.Atan2(chargeDirection.y, chargeDirection.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.left);
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));

    }

    public void ChargePlayer()
    {
        charging = true;
        anim.SetTrigger("Charge");

        chargeDirection = (CatController.instance.transform.position - trans.position).normalized;
    }

    public override void initValues(Transform[] _waypoints)
    {
        gameObject.SetActive(true);

        if (anim) 
        anim.SetTrigger("Reset");
        charging = false;

    }

    public override void TakeDamage(float damage)
    {
        health -= damage;
        Color initColor = sr.color;
        sr.DOColor(Color.red, 0.05f).OnComplete(() => { sr.DOColor(initColor, 0.05f); });
        if (health <= 0)
        {
            KilledByPlayer();
        }
    }

    public override void Die()
    {
        charging = false;
        if (anim)
            anim.SetTrigger("Reset");
        gameObject.SetActive(false);
        
    }
}
