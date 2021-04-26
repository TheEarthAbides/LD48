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
        horScroll *= 5;
        verScroll *= 5;
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
                //Vector3 newPos = new Vector3(transform.position.x - totalhor * 2, transform.position.y - totalvert * 2 + 5, transform.position.z);
                Vector3 newPos = new Vector3(45, -37, 13);

                Debug.Log(newPos);

                Debug.Log(totalhor);
                Debug.Log(totalvert);

                transform.position = newPos;
                totalhor = - totalhor/2;
                totalvert = - totalvert/2;


                Debug.Log(totalhor);
                Debug.Log(totalvert);
            }
        }
    }


}
