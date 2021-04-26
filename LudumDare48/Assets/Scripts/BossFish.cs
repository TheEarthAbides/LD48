using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BossFish : EnemyFish
{
    public GameObject[] spikes;
    private int currentShotIndex = 0;
    public AIStates currentState;
    public float horSpeed = 0.01f;
    public float verSpeed = 0.0f;
    public float bobbingTime = 10;
    private float bobbingTimer = 5;

    public float timeBetweenShots = 0.5f;
    private float timeBetweenShotstimer = 0.5f;
    public float randomVariance = 0.2f;
    public float bobTimeRandomVariance = 2f;
    private float bobTimeSin;
    private float timesCharged;
    public enum AIStates
    {
        entering,
        bobbing,
        spinning,
        charging
    }

    // Update is called once per frame
    void Update()
    {
        if(rb)
        {
            if (currentState == AIStates.entering)
            {
                rb.MovePosition(new Vector2(trans.position.x + horSpeed, trans.position.y + verSpeed));

                if (trans.position.x < 3.5f)
                {
                    currentState = AIStates.bobbing;
                    bobbingTimer = bobbingTime + Random.Range(-bobTimeRandomVariance, bobTimeRandomVariance) + timesCharged;

                    timeBetweenShotstimer = timeBetweenShots + Random.Range(-randomVariance, randomVariance);
                    bobTimeSin = 0;
                }
            }
            else if (currentState == AIStates.bobbing)
            {
                GetComponent<CircleCollider2D>().enabled = true;

                bobTimeSin += Time.deltaTime;
                verSpeed = 3f * Mathf.Sin(bobTimeSin);

                if(timesCharged % 2 == 0)
                {
                    verSpeed *= -1;
                }
                //float yloc = 0.03f * Mathf.Sin(Time.time);

                rb.MovePosition(new Vector2(trans.position.x, verSpeed));

                bobbingTimer -= Time.deltaTime;
                timeBetweenShotstimer -= Time.deltaTime;

                if (timeBetweenShotstimer <= 0)
                {
                    ShootSpike();
                }

                if (bobbingTimer <= 0)
                {
                    currentState = AIStates.spinning;
                    trans.DORotate(new Vector3(0, 0, 80), 0.1f, RotateMode.Fast).SetLoops(20, LoopType.Incremental).SetEase(Ease.InQuad);
                    rb.DOMoveX(-20, 0.5f).SetEase(Ease.Linear).SetDelay(2).OnComplete(()=> 
                    {
                        timesCharged++;

                        currentState = AIStates.entering; 
                        horSpeed = -0.4f;
                        verSpeed = 0;
                        transform.localEulerAngles = Vector3.zero;
                        transform.position = new Vector3(trans.position.x + 30, 0, 0);
                    });
                   
                }
            }
            else if (currentState == AIStates.charging)
            {

            }

        }

    }

    public void ShootSpike()
    {
        timeBetweenShotstimer = timeBetweenShots + Random.Range(-randomVariance, randomVariance);

        spikes[currentShotIndex].transform.parent = trans;
        spikes[currentShotIndex].transform.localPosition = Vector3.zero;
        spikes[currentShotIndex].SetActive(true);
        spikes[currentShotIndex].transform.parent = null;

        if (currentShotIndex < spikes.Length - 1)
        {
            currentShotIndex++;
        }
        else
        {
            currentShotIndex = 0;
        }

    }

    public override void BombKilled()
    {
        if (gameObject.activeInHierarchy)
        {
            TakeDamage(300);
        }

    }

    public override void Die()
    {
        GameManager.instance.LevelComplete();
        Debug.LogError("LEVEL COMPLETE");
        base.Die();

    }
}
