using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleUpgrade : GenericUpgrade
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collided with upgrade");

        if (other.GetComponent<CatController>())
        {
            Debug.Log("collided with upgrade");
            UpgradePickedUp();
            CatController.instance.UpgradePickedUp(UpgradeType);
        }

    }
}
