using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class UIManager : MonoBehaviour
{
    public TMP_Text bombCount;
    public TMP_Text pointsLabel;
    public static UIManager instance;
    public int totalPoints;
    public int totalBombs;
    private void Awake()
    {
        instance = this;
    }
    public void UpdateBombCount(int _bombs)
    {
        bombCount.text = _bombs.ToString(); ;
        bombCount.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.1f);
    }

    public void UpdatePoints(int _points)
    {
        totalPoints += _points;
        pointsLabel.text = totalPoints.ToString();
        pointsLabel.transform.localScale = Vector3.one;
        DOTween.Clear(pointsLabel.transform);
        pointsLabel.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.1f).SetLoops(1, LoopType.Yoyo) ;

    }
}
