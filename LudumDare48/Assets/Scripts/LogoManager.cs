using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;
public class LogoManager : MonoBehaviour
{
    // Start is called before the first frame update
    public CanvasGroup PanelCG;
    public Animator cat;
    public TMP_Text Name;
    //public 
    void Start()
    {
        PanelCG.alpha = 0;
        Name.alpha = 0;
        PanelCG.DOFade(1, 1).OnComplete(() => { cat.SetTrigger("Meow"); Name.DOFade(1, 1).SetDelay(0.5f); }) ;
        PanelCG.DOFade(0, 0.25f).SetDelay(5).OnComplete(() => { SceneManager.LoadScene(1); });


    }

}
