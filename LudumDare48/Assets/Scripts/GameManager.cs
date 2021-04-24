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
        StartGame();
    }

    public void StartGame()
    {
        stepIndex = 0;
        
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
}
