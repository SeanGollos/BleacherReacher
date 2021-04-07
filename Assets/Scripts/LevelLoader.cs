using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    GameController gameController;
    Timer timer;

    int currentSceneIndex;
    [SerializeField] float waitBeforeLoading = 1f;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextScene()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadMainMenu()
    {
        Destroy(FindObjectOfType<GameController>());
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadFirstLevel()
    {
        Destroy(FindObjectOfType<GameController>());
        SceneManager.LoadScene(1);
    }
}
