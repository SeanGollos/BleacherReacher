using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    LevelHandler lh;

    private void Start()
    {
        lh = FindObjectOfType<LevelHandler>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        lh.DecrementActiveObjects();
        Destroy(collision.gameObject);
        //if(gameController.GetActiveObjects()<=0 && timer.GetTimeRemaining()<=0)
        //{
        //    AudioSource.PlayClipAtPoint(levelEndClip, Camera.main.transform.position, levelEndVolume);
        //}
    }
}
