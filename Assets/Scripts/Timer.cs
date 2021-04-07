using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    LevelHandler lh;
    public Text timeText;
    [SerializeField] float timeRemaining = 10;
    bool timerIsRunning = false;

    [SerializeField] AudioClip levelEndClip;
    [SerializeField] [Range(0, 1)] float levelEndVolume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        lh = FindObjectOfType<LevelHandler>();
        timerIsRunning = true;    
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsRunning)
        {
            if(timeRemaining > 0)
            {
                //If there is still time remaining, decrement it
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                timeText.color = Color.red;
                StopSpawning();

                if(lh.GetActiveObjects()<=0)
                {
                    AudioSource.PlayClipAtPoint(levelEndClip, Camera.main.transform.position, levelEndVolume);
                }
            }
        }
    }

    private void StopSpawning()
    {
        //Find all of our spawners and put them in an array
        ObjectSpawner[] spawnerArray = FindObjectsOfType<ObjectSpawner>();

        foreach(ObjectSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public float GetTimeRemaining()
    { return timeRemaining; }
}
