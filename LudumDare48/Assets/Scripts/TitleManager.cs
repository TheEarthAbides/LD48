using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class TitleManager : MonoBehaviour
{
    public Transform cat;
    public Transform bubbles;

    private float initCatY;
    private float initBubblesY;
    // Start is called before the first frame update
    void Start()
    {
        initCatY = cat.transform.position.y;
        initBubblesY = bubbles.transform.position.y;

        cat.DOMoveY(initCatY + 40, 2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuad);
        //bubbles.DOMoveY(initBubblesY + 20, 1.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear).SetDelay(1);
    }

    public void LaunchGame()
    {
        SceneManager.LoadScene(2);
    }

    public void ShowSettings()
    {

    }
}
