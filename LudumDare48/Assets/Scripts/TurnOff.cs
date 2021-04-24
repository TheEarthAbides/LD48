using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOff : MonoBehaviour
{
    private void Awake()
    {
        transform.gameObject.SetActive(false);
    }
}
