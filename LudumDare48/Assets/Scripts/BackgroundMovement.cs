using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float horScroll = -0.001f;
    public float verScroll = 0.0003f;
    public bool tileable;
    float totalhor;
    float totalvert;
    private Vector3 initpos;
    // Start is called before the first frame update

    private void Awake()
    {
        initpos = transform.position;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalhor += horScroll;
        totalvert += verScroll;
        transform.position += new Vector3(horScroll, verScroll, 0);

        if(tileable)
        {
            if(transform.position.x < CatController.instance.transform.position.x - 60)
            {
                transform.position = new Vector3(transform.position.x - totalhor * 2, transform.position.y - totalvert * 2 + 5, transform.position.z);
                totalhor = 0;
                totalvert = 0;
            }
        }
    }


}
