using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] int score = 0;

    private void Awake()
    {
        //SetUpSingleton();
        DontDestroyOnLoad(gameObject);
    }

    private void SetUpSingleton()
    {
        int numControllers = FindObjectsOfType<GameController>().Length;
        if (numControllers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(transform.root.gameObject);
        }
    }

    public int GetScore() { return score; }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
