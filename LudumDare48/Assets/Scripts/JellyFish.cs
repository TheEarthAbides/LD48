using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFish : EnemyFish
{
    public float horSpeed = -0.07f;
    public float verSpeed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FishMovement();

        BoundaryCheck();

    }

    public override void FishMovement()
    {
        rb.MovePosition(new Vector2(trans.position.x + horSpeed, trans.position.y + verSpeed));
    }    
}
