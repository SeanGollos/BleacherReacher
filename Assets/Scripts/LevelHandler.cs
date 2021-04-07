using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Will handle incrementing and decrementing active objects
public class LevelHandler : MonoBehaviour
{
    Timer timer;
    [SerializeField] int activeObjects = 0;

    [SerializeField] AudioClip levelEndClip;
    [SerializeField] [Range(0, 1)] float levelEndVolume = 0.5f;

    private void Start()
    {
        timer = FindObjectOfType<Timer>();
    }

    public int GetActiveObjects() { return activeObjects; }
    public void IncrementActiveObjects() { activeObjects++; }
    public void DecrementActiveObjects()
    {
        activeObjects--;
        if (activeObjects <= 0 && timer.GetTimeRemaining() <= 0)
        {
            AudioSource.PlayClipAtPoint(levelEndClip, Camera.main.transform.position, levelEndVolume);
            StartCoroutine(WaitThenLoad());
        }
    }

    IEnumerator WaitThenLoad()
    {
        yield return new WaitForSeconds(2);
        GetComponent<LevelLoader>().LoadNextScene();
    }
}
