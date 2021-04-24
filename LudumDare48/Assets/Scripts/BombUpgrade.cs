using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombUpgrade : GenericUpgrade
{
    public int UpgradeType = 0;
    public void OnTriggerEnter2D (Collider2D other)
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
