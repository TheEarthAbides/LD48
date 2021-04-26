using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public abstract class GenericUpgrade : MonoBehaviour
{

    private Transform trans;
    private Rigidbody2D rb;
    public float horSpeed;
    public float vertSpeed;
    private SpriteRenderer srOutline;
    public int UpgradeType;
    private void Awake()
    {
        trans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        if(trans.childCount > 0)
        srOutline = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        srOutline.DOColor(Color.white, 0.5f).SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        rb.MovePosition(new Vector2(trans.position.x + horSpeed, trans.position.y + vertSpeed));
    }

    public void UpgradePickedUp()
    {
        gameObject.SetActive(false);
    }


}
