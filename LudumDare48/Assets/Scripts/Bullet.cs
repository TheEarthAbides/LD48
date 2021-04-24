using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform trans;
    public Rigidbody2D rb;
    public float moveSpeed = 0.3f;
    public float damage = 40;
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
        if(trans.gameObject.activeSelf)
        {
            rb.MovePosition(new Vector2(trans.position.x + moveSpeed, trans.position.y));
        }
    }
}
