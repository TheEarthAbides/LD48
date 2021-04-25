using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [System.Serializable]
    public class LevelStep
    {
        public EnemySpawner[] spawners;
    }

    public Transform topBound;
    public Transform leftBound;
    public Transform rightBound;
    public Transform botBound;

    public int stepIndex;
    public LevelStep[] steps;
    public float ActiveSpawners;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Invoke("StartGame", 0.5f);
        //StartGame();
    }

    public void StartGame()
    {
        stepIndex = 0;
        UIManager.instance.pointsLabel.text = "0";
        UIManager.instance.bombCount.text = "3";
        UIManager.instance.totalPoints = 0;

        for (int i = 0; i < steps[stepIndex].spawners.Length; i++)
        {
            steps[stepIndex].spawners[i].gameObject.SetActive(true);
            ActiveSpawners++;
        }
    }

    public void SpawnerDeactivated()
    {
        ActiveSpawners--;
        if(ActiveSpawners <= 0)
        {
            NextStep();
        }
    }

    public void NextStep()
    {
        stepIndex++;
        if (stepIndex < steps.Length)
        {
            for (int i = 0; i < steps[stepIndex].spawners.Length; i++)
            {
                steps[stepIndex].spawners[i].gameObject.SetActive(true);
                ActiveSpawners++;
            }
        }
        else
        {
            LevelComplete();
        }
      
    }

    public void LevelComplete()
    {

    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }

    public void RollForUpgrade(Vector3 _pos)
    {

    }
}
