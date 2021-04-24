using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BlowFish : EnemyFish
{
    public float horSpeed = -0.05f;
    public Vector3 initScale = new Vector3(0.5f, 0.5f, 0.5f);
    public Color initColor = Color.yellow;
    public float puffTime = 7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FishMovement();
    }
    public override void initValues()
    {
        sr.color = initColor;
        trans.localScale = initScale;
        trans.DOScale(2, puffTime);
        sr.DOColor(Color.red, puffTime).SetEase(Ease.InQuad).OnComplete(() => { Die(); }) ;

    }
    public override void FishMovement()
    {
        rb.MovePosition(new Vector2(trans.position.x + horSpeed, trans.position.y));
    }
    
   
}
