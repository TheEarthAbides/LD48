using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private Transform trans;
    private Rigidbody2D rb;
    public float damage;
    public float horSpeed = 0.1f;
    public float vertSpeed = 0.1f;
    public bool BossSpike;
    private void Awake()
    {
        trans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        CatController.instance.myBombUsed += BombKilled;

    }
    void BombKilled()
    {
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(trans.gameObject.activeInHierarchy)
        {
            if(BossSpike)
            {
                rb.MovePosition(new Vector2(trans.position.x + horSpeed, trans.position.y));

            }
            else
            {
                if (trans.GetSiblingIndex() == 0)
                {
                    rb.MovePosition(new Vector2(trans.position.x - horSpeed, trans.position.y + vertSpeed));
                }
                else if (trans.GetSiblingIndex() == 1)
                {
                    rb.MovePosition(new Vector2(trans.position.x - horSpeed, trans.position.y - vertSpeed));
                }
                else if (trans.GetSiblingIndex() == 2)
                {
                    rb.MovePosition(new Vector2(trans.position.x + horSpeed, trans.position.y + vertSpeed));
                }
                else if (trans.GetSiblingIndex() == 3)
                {
                    rb.MovePosition(new Vector2(trans.position.x + horSpeed, trans.position.y - vertSpeed));
                }
            }
           
        }
        
    }

}
